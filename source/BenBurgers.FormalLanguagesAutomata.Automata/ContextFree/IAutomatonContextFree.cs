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

using BenBurgers.FormalLanguagesAutomata.Languages.ContextFree;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree;

/// <summary>
/// A context-free automaton.
/// </summary>
/// <typeparam name="TSymbol">The type of symbols in the automaton.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the automaton.</typeparam>
/// <typeparam name="TState">The type of states in the automaton.</typeparam>
public interface IAutomatonContextFree<TSymbol, TSymbolValue, TState>
    : IAutomaton<TSymbol, TSymbolValue, TState>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
    where TState : AutomatonState
{
    /// <summary>
    /// Gets the language that is accepted by the automaton.
    /// </summary>
    ILanguageContextFree<TSymbol, TSymbolValue> Language { get; }

    /// <summary>
    /// Gets the final states.
    /// </summary>
    IReadOnlySet<TState> StatesFinal { get; }
}
