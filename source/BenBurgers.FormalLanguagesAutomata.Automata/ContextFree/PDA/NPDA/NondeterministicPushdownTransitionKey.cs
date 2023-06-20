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
/// A nondeterministic pushdown transition's key.
/// </summary>
/// <typeparam name="TInputSymbol">The type of input symbols in the automaton.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of value of an input symbol in the automaton.</typeparam>
/// <typeparam name="TState">The type of state in the automaton.</typeparam>
/// <typeparam name="TStackSymbol">The type of symbols on the stack in the automaton.</typeparam>
public sealed partial class NondeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TStackSymbol : IStackSymbol<TStackSymbol>
{
    /// <summary>
    /// Initializes a new instance of <see cref="NondeterministicPushdownTransitionKey{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}" />.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="inputSymbol">The input symbol.</param>
    /// <param name="stackSymbol">The stack symbol.</param>
    public NondeterministicPushdownTransitionKey(
        TState state,
        TInputSymbol inputSymbol,
        TStackSymbol? stackSymbol)
    {
        this.State = state;
        this.InputSymbol = inputSymbol;
        this.StackSymbol = stackSymbol;
    }

    /// <summary>
    /// Gets the state.
    /// </summary>
    public TState State { get; }

    /// <summary>
    /// Gets the input symbol.
    /// </summary>
    public TInputSymbol InputSymbol { get; }

    /// <summary>
    /// Gets the stack symbol.
    /// </summary>
    public TStackSymbol? StackSymbol { get; }
}
