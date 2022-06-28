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

using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Grammars;

/// <summary>
/// Parses grammar definitions.
/// </summary>
/// <typeparam name="TGrammar">
/// The type of grammar.
/// </typeparam>
/// <typeparam name="TVariable">
/// The type of variable in the grammar.
/// </typeparam>
/// <typeparam name="TTerminal">
/// The type of terminal in the grammar.
/// </typeparam>
public interface IGrammarParser<TGrammar, TVariable, TTerminal>
    where TGrammar : IGrammar<TVariable, TTerminal>
    where TVariable : Variable
    where TTerminal : Terminal
{
    /// <summary>
    /// Parses a grammar from <paramref name="stream" />.
    /// </summary>
    /// <param name="stream">
    /// The stream from which to parse the grammar.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// The parsed grammar.
    /// </returns>
    Task<TGrammar> ParseAsync(Stream stream, CancellationToken cancellationToken);

    /// <summary>
    /// Parses a grammar from <paramref name="streamReader" />.
    /// </summary>
    /// <param name="streamReader">
    /// The stream reader from which to parse the grammar.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// The parsed grammar.
    /// </returns>
    Task<TGrammar> ParseAsync(StreamReader streamReader, CancellationToken cancellationToken);
}