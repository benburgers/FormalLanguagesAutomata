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

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.NPDA;

/// <summary>
/// Constructor arguments for a <see cref="NondeterministicPushdownAutomaton{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}" />.
/// </summary>
/// <typeparam name="TInputSymbol">The type of input symbols of the automaton.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of value of an input symbol of the automaton.</typeparam>
/// <typeparam name="TState">The type of state of the automaton.</typeparam>
/// <typeparam name="TStackSymbol">The type of stack symbol of the automaton.</typeparam>
public sealed class NondeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TStackSymbol : IStackSymbol<TStackSymbol>
{
    /// <summary>
    /// Initializes a new instance of <see cref="NondeterministicPushdownAutomatonArguments{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}" />.
    /// </summary>
    /// <param name="alphabetIn">The input alphabet.</param>
    /// <param name="stateInitial">The initial state of the automaton.</param>
    /// <param name="transitions">The transitions of the automaton.</param>
    /// <param name="statesFinal">The final states of the automaton.</param>
    public NondeterministicPushdownAutomatonArguments(
        IReadOnlySet<TInputSymbol> alphabetIn,
        TState stateInitial,
        NondeterministicPushdownTransitions<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> transitions,
        IReadOnlySet<TState> statesFinal)
    {
        this.AlphabetIn = alphabetIn;
        this.StateInitial = stateInitial;
        this.Transitions = transitions;
        this.StatesFinal = statesFinal;
    }


    /// <inheritdoc cref="NondeterministicPushdownAutomaton{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}.AlphabetIn" />
    public IReadOnlySet<TInputSymbol> AlphabetIn { get; }

    /// <summary>
    /// Gets the initial state of the automaton.
    /// </summary>
    public TState StateInitial { get; }

    /// <summary>
    /// Gets the transitions of the automaton.
    /// </summary>
    public NondeterministicPushdownTransitions<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> Transitions { get; }

    /// <inheritdoc cref="NondeterministicPushdownAutomaton{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}.StatesFinal" />.
    public IReadOnlySet<TState> StatesFinal { get; }
}
