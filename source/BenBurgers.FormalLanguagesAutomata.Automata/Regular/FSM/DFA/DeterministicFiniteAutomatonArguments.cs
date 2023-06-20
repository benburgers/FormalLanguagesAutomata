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

namespace BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.DFA;

/// <summary>
/// Constructor arguments for a deterministic finite automaton.
/// </summary>
/// <typeparam name="TSymbol">The type of symbols in the nondeterministic finite automaton.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the nondeterministic finite automaton.</typeparam>
/// <typeparam name="TState">The type of a state in the deterministic finite automaton.</typeparam>
public sealed class DeterministicFiniteAutomatonArguments<TSymbol, TSymbolValue, TState>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
{
    /// <summary>
    /// Initializes a new instance of <see cref="DeterministicFiniteAutomatonArguments{TSymbol, TSymbolValue, TState}" />.
    /// </summary>
    /// <param name="alphabetIn">The input alphabet.</param>
    /// <param name="stateInitial">The initial state of the automaton.</param>
    /// <param name="transitions">The transitions of the automaton.</param>
    /// <param name="statesFinal">The final states of the automaton.</param>
    public DeterministicFiniteAutomatonArguments(
        IReadOnlySet<TSymbol> alphabetIn,
        TState stateInitial,
        IReadOnlyDictionary<TState, IReadOnlyDictionary<TSymbol, TState?>> transitions,
        IReadOnlySet<TState> statesFinal)
    {
        this.AlphabetIn = alphabetIn;
        this.StateInitial = stateInitial;
        this.Transitions = transitions;
        this.StatesFinal = statesFinal;
    }

    /// <inheritdoc cref="DeterministicFiniteAutomaton{TSymbol, TSymbolValue, TState}.AlphabetIn" />
    public IReadOnlySet<TSymbol> AlphabetIn { get; }

    /// <summary>
    /// Gets the initial state of an automaton.
    /// </summary>
    public TState StateInitial { get; }

    /// <summary>
    /// Gets the transitions of the automaton.
    /// </summary>
    public IReadOnlyDictionary<TState, IReadOnlyDictionary<TSymbol, TState?>> Transitions { get; }

    /// <inheritdoc cref="DeterministicFiniteAutomaton{TSymbol, TSymbolValue, TState}.StatesFinal" />
    public IReadOnlySet<TState> StatesFinal { get; }
}
