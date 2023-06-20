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

namespace BenBurgers.FormalLanguagesAutomata.Automata;

/// <summary>
/// A nondeterministic automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of symbols in the automaton.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the automaton.</typeparam>
/// <typeparam name="TState">The type of states in the automaton.</typeparam>
public interface IAutomatonNondeterministic<TInputSymbol, TSymbolValue, TState>
    : IAutomaton<TInputSymbol, TSymbolValue, TState>
    where TInputSymbol : ISymbol<TInputSymbol, TSymbolValue>
    where TState : AutomatonState
{
    /// <summary>
    /// Peeks the next state(s) if the input would be the specified <paramref name="inputSymbol" />.
    /// </summary>
    /// <param name="inputSymbol">The input symbol.</param>
    /// <returns>The resulting state(s) if the input would be the specified <paramref name="inputSymbol" />.</returns>
    IReadOnlySet<TState> PeekNextStates(TInputSymbol inputSymbol);

    /// <summary>
    /// Move to the next state indicated.
    /// </summary>
    /// <param name="inputSymbol">The input symbol.</param>
    /// <param name="state">The desired next state.</param>
    /// <returns>The next state, or <c>null</c> if <paramref name="state" /> is invalid for the current state and <paramref name="inputSymbol" />.</returns>
    TState? MoveNext(TInputSymbol inputSymbol, TState state);
}
