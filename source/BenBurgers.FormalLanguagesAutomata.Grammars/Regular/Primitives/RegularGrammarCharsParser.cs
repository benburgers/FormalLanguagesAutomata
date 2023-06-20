/*
 * This file is part of Ben Burgers Formal Languages and Automata.
 *
 * Ben Burgers Formal Languages and Automata is free software: 
 * you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 *
 * Ben Burgers Formal Languages and Automata is distributed in the hope that it will be useful, 
 * but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with Ben Burgers Formal Languages and Automata. 
 * If not, see <https://www.gnu.org/licenses/>.
 */

using BenBurgers.FormalLanguagesAutomata.Grammars.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Grammars.Regular.Primitives.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Symbols;
using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;
using System.Collections.ObjectModel;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Regular.Primitives;

/// <summary>
/// Parses definitions for regular grammars that consist of <see cref="char" /> variables and terminals.
/// </summary>
public class RegularGrammarCharsParser
    : IGrammarParser<RegularGrammarChars, CharVariable, CharTerminal>
{
    /// <summary>
    /// Initializes a new instance of <see cref="RegularGrammarCharsParser" />.
    /// </summary>
    /// <param name="startVariable">
    /// A predefined start variable.
    /// </param>
    /// <param name="emptyTerminal">
    /// A predefined empty terminal, if applicable.
    /// </param>
    public RegularGrammarCharsParser(
        CharVariable startVariable,
        CharTerminal? emptyTerminal)
    {
        this.StartVariable = startVariable;
        this.EmptyTerminal = emptyTerminal;
    }

    /// <summary>
    /// Gets the predefined start variable for regular grammars to be parsed.
    /// </summary>
    public CharVariable StartVariable { get; }

    /// <summary>
    /// Gets the predefined empty terminal, if applicable, for regular grammars to be parsed.
    /// </summary>
    public CharTerminal? EmptyTerminal { get; }

    /// <inheritdoc/>
    public async Task<RegularGrammarChars> ParseAsync(Stream stream, CancellationToken cancellationToken)
    {
        var streamReader = new StreamReader(stream);
        return await ParseAsync(streamReader, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RegularGrammarChars> ParseAsync(StreamReader streamReader, CancellationToken cancellationToken)
    {
        var variables = new HashSet<CharVariable>();
        var terminals = new HashSet<CharTerminal>();
        var productionRules = new Dictionary<CharVariable, Collection<List<IElement>>>();
        var lineCounter = 0;
#if NET6_0
        while ((await streamReader.ReadLineAsync()) is { } line)
#endif
#if NET7_0
        while ((await streamReader.ReadLineAsync(cancellationToken)) is { } line)
#endif
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            ++lineCounter;
            if (string.IsNullOrWhiteSpace(line))
            {
                continue; // ignore empty lines
            }

            // Build production
            CharVariable? inputVariable = null;
            List<IElement>? production = null;

            var enumerator = line.GetEnumerator();
            var positionCounter = 0;
            while (enumerator.MoveNext())
            {
                ++positionCounter;
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                switch (enumerator.Current)
                {
                    // Input variable
                    case var c when char.IsWhiteSpace(c):
                        break; // ignore whitespaces
                    case var c when inputVariable is null && char.IsUpper(c):
                        inputVariable = new CharVariable(c);
                        variables.Add(inputVariable);
                        break;
                    case var c when inputVariable is null && !char.IsUpper(c):
                        throw new GrammarParserException(ExceptionMessages.InputVariableExpected, lineCounter, positionCounter);
                    case SpecialCharacters.Production when inputVariable is not null && production is null:
                        production = new List<IElement>();
                        break;
                    case SpecialCharacters.Production when inputVariable is null || production is not null:
                        throw new GrammarParserException(ExceptionMessages.ProductionSymbolUnexpected, lineCounter, positionCounter);
                    case var c when inputVariable is not null && production is not null && char.IsUpper(c):
                        var nextVariable = new CharVariable(c);
                        production.Add(nextVariable);
                        variables.Add(nextVariable);
                        break;
                    case var c when inputVariable is not null && production is not null && char.IsLower(c):
                        var nextTerminal = new CharTerminal(c);
                        production.Add(nextTerminal);
                        terminals.Add(nextTerminal);
                        break;
                    default:
                        throw new GrammarParserException(ExceptionMessages.SymbolOrStateUnexpected, lineCounter, positionCounter);
                }
            }

            // Merge production rule
            if (inputVariable is null || production is null)
            {
                throw new GrammarParserException(ExceptionMessages.ProductionRuleReadFailed, lineCounter, positionCounter);
            }
            else if (productionRules.TryGetValue(inputVariable, out var productionsExisting))
            {
                productionsExisting.Add(production);
            }
            else
            {
                productionRules.Add(inputVariable, new Collection<List<IElement>> { production });
            }
        }
        var productionRulesResult =
            productionRules
                .Select(pr => (pr.Key, Value: (IReadOnlyCollection<IReadOnlyList<IElement>>)pr.Value))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        return new RegularGrammarChars(variables, terminals, productionRulesResult, this.StartVariable, this.EmptyTerminal);
    }
}