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

using BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.Stack;
using BenBurgers.FormalLanguagesAutomata.Symbols;
using System.Collections.ObjectModel;

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.DPDA;

/// <summary>
/// Transitions for a <see cref="DeterministicPushdownAutomaton{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}" />.
/// </summary>
/// <typeparam name="TInputSymbol">The type of input symbols for the automaton.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of value of a symbol for the automaton.</typeparam>
/// <typeparam name="TState">The type of states in the automaton.</typeparam>
/// <typeparam name="TStackSymbol">The type of stack symbols in the automaton's stack.</typeparam>
public sealed partial class DeterministicPushdownTransitions<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    : ReadOnlyDictionary<
        DeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>,
        DeterministicPushdownTransitionResult<TState, TStackSymbol>>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TStackSymbol : IStackSymbol<TStackSymbol>
{
    /// <summary>
    /// Initializes a new instance of <see cref="DeterministicPushdownTransitions{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}" />.
    /// </summary>
    /// <param name="transitions">The transitions.</param>
    public DeterministicPushdownTransitions(Dictionary<
        DeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>,
        DeterministicPushdownTransitionResult<TState, TStackSymbol>> transitions)
        : base(transitions)
    {
    }
}
