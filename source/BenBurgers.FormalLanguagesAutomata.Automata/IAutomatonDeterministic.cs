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
/// A deterministic automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of symbols in the automaton.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the automaton.</typeparam>
/// <typeparam name="TState">The type of states in the automaton.</typeparam>
public interface IAutomatonDeterministic<TInputSymbol, TSymbolValue, TState>
    : IAutomaton<TInputSymbol, TSymbolValue, TState>
    where TInputSymbol : ISymbol<TInputSymbol, TSymbolValue>
    where TState : AutomatonState
{
    /// <summary>
    /// Peeks the next state if the input would be the specified <paramref name="symbol" />.
    /// </summary>
    /// <param name="symbol">The input symbol.</param>
    /// <returns>The resulting state if the input would be the specified <paramref name="symbol" />.</returns>
    TState? PeekNextState(TInputSymbol symbol);

    /// <summary>
    /// Move to the next state.
    /// </summary>
    /// <param name="symbol">The input symbol.</param>
    /// <returns>The next state.</returns>
    TState? MoveNext(TInputSymbol symbol);
}
