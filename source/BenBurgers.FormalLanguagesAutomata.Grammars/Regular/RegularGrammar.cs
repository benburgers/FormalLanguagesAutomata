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
using BenBurgers.FormalLanguagesAutomata.Grammars.Regular.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Regular;

/// <summary>
/// A regular formal grammar.
/// </summary>
/// <typeparam name="TVariable">
/// The type of variables in the grammar.
/// </typeparam>
/// <typeparam name="TTerminal">
/// The type of terminals in the grammar.
/// </typeparam>
public class RegularGrammar<TVariable, TTerminal>
    : IRegularGrammar<TVariable, TTerminal>
    where TVariable : Variable
    where TTerminal : Terminal
{
    private Linearity linearity;

    private void AssertRegularGrammar()
    {
        GrammarAssertions.VariableMembership(this.Variables, this.StartVariable, ExceptionMessages.VariablesDoesNotContainStartVariable);
        GrammarAssertions.TerminalMembership(this.Terminals, this.EmptyTerminal, ExceptionMessages.TerminalsDoesNotContainEmptyTerminal);

        // Assert productions respect membership and a regular grammar.
        foreach (var productionRule in this.ProductionRules)
        {
            foreach (var production in productionRule.Value)
            {
                if (production.Count == 0)
                {
                    throw new GrammarValidationException(ExceptionMessages.ProductionIsEmpty);
                }
                if (production.Count == 1)
                {
                    if (production[0] is TVariable variable)
                    {
                        GrammarAssertions.VariableMembership(this.Variables, variable, ExceptionMessages.ProductionRegularVariableTerminalOrExpected);
                        continue;
                    }
                    if (production[0] is TTerminal terminal)
                    {
                        GrammarAssertions.TerminalMembershipOrEmpty(this.Terminals, this.EmptyTerminal, terminal, ExceptionMessages.ProductionRegularVariableTerminalOrExpected);
                        continue;
                    }
                    throw new GrammarValidationException(ExceptionMessages.ProductionRegularVariableTerminalOrExpected);
                }
                if (production.Count >= 2)
                {
                    GrammarAssertions.RegularProduction(this.Variables, this.Terminals, production, ref this.linearity);
                }
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of <see cref="RegularGrammar{TVariable, TTerminal}" />.
    /// </summary>
    /// <param name="variables">
    /// The variables in the grammar.
    /// </param>
    /// <param name="terminals">
    /// The terminals in the grammar.
    /// </param>
    /// <param name="productionRules">
    /// The production rules for the grammar.
    /// </param>
    /// <param name="startVariable">
    /// The start variable in the grammar.
    /// </param>
    /// <param name="emptyTerminal">
    /// The empty terminal in the grammar, if applicable.
    /// </param>
    public RegularGrammar(
        IReadOnlySet<TVariable> variables,
        IReadOnlySet<TTerminal> terminals,
        IReadOnlyDictionary<TVariable, IReadOnlyCollection<IReadOnlyList<IElement>>> productionRules,
        TVariable startVariable,
        TTerminal? emptyTerminal)
    {
        this.Variables = new HashSet<TVariable>(variables);
        this.Terminals = new HashSet<TTerminal>(terminals);
        this.ProductionRules = productionRules;
        this.StartVariable = startVariable;
        this.EmptyTerminal = emptyTerminal;
        this.AssertRegularGrammar();
    }

    /// <inheritdoc />
    public IReadOnlySet<TVariable> Variables { get; }

    /// <inheritdoc />
    public IReadOnlySet<TTerminal> Terminals { get; }

    /// <inheritdoc />
    public TVariable StartVariable { get; }

    /// <inheritdoc />
    public TTerminal? EmptyTerminal { get; }

    /// <inheritdoc />
    public Linearity Linearity => this.linearity;

    /// <inheritdoc />
    public IReadOnlyDictionary<TVariable, IReadOnlyCollection<IReadOnlyList<IElement>>> ProductionRules { get; }

    /// <inheritdoc/>
    public virtual Func<TVariable, IReadOnlyCollection<IReadOnlyList<IElement>>> CreateProducer()
    {
        return this.Producer;
    }

    /// <summary>
    /// A default implementation of a producer function that takes in a variable and returns a disjunction of lists of elements that are produced by the variable.
    /// </summary>
    /// <param name="variable">
    /// The input variable.
    /// </param>
    /// <returns>
    /// A disjunction of lists of elements that are produced by the variable.
    /// </returns>
    /// <exception cref="GrammarException">
    /// A <see cref="GrammarException" /> is thrown if the specified variable does not have productions in this grammar.
    /// </exception>
    protected IReadOnlyCollection<IReadOnlyList<IElement>> Producer(TVariable variable)
    {
        if (!this.ProductionRules.TryGetValue(variable, out var productions))
        {
            throw new GrammarException(ExceptionMessages.VariableDoesNotHaveProductions);
        }
        return productions;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        string ProductionToString(IReadOnlyList<IElement> elements)
        {
            return elements.Select(e => e.ToString() ?? string.Empty).Aggregate((previous, next) => previous + next);
        }

        string ProductionsToString(IReadOnlyCollection<IReadOnlyList<IElement>> productions)
        {
            return productions.Select(p => ProductionToString(p)).Aggregate((previous, next) => previous + next);
        }

        return
            this
                .ProductionRules
                .Select(kvp => $"{kvp.Key} {SpecialCharacters.Production} {ProductionsToString(kvp.Value)}")
                .Aggregate((previous, next) => previous + Environment.NewLine + next);
    }
}