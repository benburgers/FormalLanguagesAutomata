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

namespace BenBurgers.FormalLanguagesAutomata.Grammars.ContextFree;

/// <summary>
/// A Context-Free Grammar (CFG) or Type-2 grammar according to the Chomsky hierarchy of formal grammars.
/// </summary>
/// <typeparam name="TVariable">
/// The type of variable in the Context-Free Grammar.
/// </typeparam>
/// <typeparam name="TTerminal">
/// The type of terminal in the Context-Free Grammar.
/// </typeparam>
/// <remarks>
///     <para>
///         <b>Note</b>:    
///     </para>
///     <para>
///         A Context-Free Grammar (CFG) is in the format of:
///         <code>
///             A → α
///         </code>
///         Where α can be a sequence of any length (except 0) of either a variable or a terminal symbol.
///     </para>
/// </remarks>
public interface IContextFreeGrammar<TVariable, TTerminal>
    : IGrammar<TVariable, TTerminal>
    where TVariable : Variable
    where TTerminal : Terminal
{
}
