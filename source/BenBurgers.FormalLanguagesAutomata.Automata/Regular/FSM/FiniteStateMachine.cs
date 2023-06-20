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

using BenBurgers.FormalLanguagesAutomata.Languages.Regular;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM;

/// <summary>
/// A finite state machine.
/// </summary>
/// <typeparam name="TSymbol">The type of symbols in the finite state machine.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the finite state machine.</typeparam>
/// <typeparam name="TState">The type of state in the finite state machine.</typeparam>
public abstract class FiniteStateMachine<TSymbol, TSymbolValue, TState>
    : IAutomatonRegular<TSymbol, TSymbolValue, TState>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
    where TState : AutomatonState
{
    /// <inheritdoc />
    public abstract ILanguageRegular<TSymbol, TSymbolValue> Language { get; }

    /// <inheritdoc />
    public abstract IReadOnlySet<TSymbol> AlphabetIn { get; }

    /// <inheritdoc />
    public abstract IReadOnlySet<TState> States { get; }

    /// <inheritdoc />
    public abstract TState StateCurrent { get; }

    /// <inheritdoc />
    public abstract IReadOnlySet<TState> StatesFinal { get; }

    /// <inheritdoc />
    public abstract object Clone();
}

/// <summary>
/// A finite state machine.
/// </summary>
/// <typeparam name="TSymbol">The type of symbols in the finite state machine.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the finite state machine.</typeparam>
public abstract class FiniteStateMachine<TSymbol, TSymbolValue>
    : FiniteStateMachine<TSymbol, TSymbolValue, AutomatonLabelState>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
{
}