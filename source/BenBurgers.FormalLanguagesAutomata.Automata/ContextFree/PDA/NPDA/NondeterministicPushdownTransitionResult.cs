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

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.NPDA;

/// <summary>
/// A result of a transition in a nondeterminisitic pushdown automaton.
/// </summary>
/// <typeparam name="TState">The type of states in the nondeterministic pushdown automaton.</typeparam>
/// <typeparam name="TStackSymbol">The type of symbols on the stack of a nondeterministic pushdown automaton.</typeparam>
public sealed partial class NondeterministicPushdownTransitionResult<TState, TStackSymbol>
    where TStackSymbol : IStackSymbol<TStackSymbol>
{
    /// <summary>
    /// Initializes a new instance of <see cref="NondeterministicPushdownTransitionResult{TState, TStackSymbol}" />.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="stackSymbol">The stack symbol.</param>
    public NondeterministicPushdownTransitionResult(TState state, TStackSymbol? stackSymbol)
    {
        this.State = state;
        this.StackSymbol = stackSymbol;
    }

    /// <summary>
    /// Gets the state.
    /// </summary>
    public TState State { get; }

    /// <summary>
    /// Gets the stack symbol.
    /// </summary>
    public TStackSymbol? StackSymbol { get; }

    /// <summary>
    /// Deconstructs the <see cref="NondeterministicPushdownTransitionResult{TState, TStackSymbol}" />.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="stackSymbol">The stack symbol.</param>
    public void Deconstruct(out TState state, out TStackSymbol? stackSymbol)
    {
        state = this.State;
        stackSymbol = this.StackSymbol;
    }
}
