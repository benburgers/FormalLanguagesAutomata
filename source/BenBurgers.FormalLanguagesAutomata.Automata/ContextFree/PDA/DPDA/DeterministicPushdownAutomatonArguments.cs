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

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.DPDA;

/// <summary>
/// Constructor arguments for a deterministic pushdown automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of symbols in the input alphabet.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of value of a symbol in the input alphabet.</typeparam>
/// <typeparam name="TState">The type of state in the deterministic finite automaton.</typeparam>
/// <typeparam name="TStackSymbol">The type of symbols in the stack.</typeparam>
public sealed class DeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TStackSymbol : IStackSymbol<TStackSymbol>
{
    /// <summary>
    /// Initializes a new instance of <see cref="DeterministicPushdownAutomatonArguments{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}" />.
    /// </summary>
    /// <param name="alphabetIn">The input alphabet.</param>
    /// <param name="stateInitial">The initial state of the automaton.</param>
    /// <param name="transitions">The transitions of the automaton.</param>
    /// <param name="statesFinal">The final states of the automaton.</param>
    public DeterministicPushdownAutomatonArguments(
        IReadOnlySet<TInputSymbol> alphabetIn,
        TState stateInitial,
        DeterministicPushdownTransitions<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> transitions,
        IReadOnlySet<TState> statesFinal)
    {
        this.AlphabetIn = alphabetIn;
        this.StateInitial = stateInitial;
        this.Transitions = transitions;
        this.StatesFinal = statesFinal;
    }

    /// <inheritdoc cref="DeterministicPushdownAutomaton{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}.AlphabetIn" />
    public IReadOnlySet<TInputSymbol> AlphabetIn { get; }

    /// <summary>
    /// Gets the initial state of the automaton.
    /// </summary>
    public TState StateInitial { get; }

    /// <summary>
    /// Gets the transitions of the automaton.
    /// </summary>
    public DeterministicPushdownTransitions<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> Transitions { get; }
    
    /// <inheritdoc cref="DeterministicPushdownAutomaton{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}.StatesFinal" />.
    public IReadOnlySet<TState> StatesFinal { get; }
}
