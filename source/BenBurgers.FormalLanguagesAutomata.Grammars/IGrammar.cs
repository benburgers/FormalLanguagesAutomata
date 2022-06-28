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
/// A formal grammar.
/// </summary>
/// <typeparam name="TVariable">
/// The type of variables in the grammar.
/// </typeparam>
/// <typeparam name="TTerminal">
/// The type of terminals in the grammar.
/// </typeparam>
public interface IGrammar<TVariable, TTerminal>
    where TVariable : Variable
    where TTerminal : Terminal
{
    /// <summary>
    /// Gets the variables in the grammar.
    /// </summary>
    IReadOnlySet<TVariable> Variables { get; }

    /// <summary>
    /// Gets the terminals in the grammar.
    /// </summary>
    IReadOnlySet<TTerminal> Terminals { get; }

    /// <summary>
    /// Gets the start variable in the grammar.
    /// </summary>
    TVariable StartVariable { get; }

    /// <summary>
    /// Gets the empty terminal in the grammar, if applicable.
    /// </summary>
    TTerminal? EmptyTerminal { get; }
}