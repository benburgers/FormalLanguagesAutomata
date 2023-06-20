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

using BenBurgers.FormalLanguagesAutomata.Automata.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Languages.Regular;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.DFA;

/// <summary>
/// A deterministic finite automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of symbols in the deterministic finite automaton.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the deterministic finite automaton.</typeparam>
/// <typeparam name="TState">The type of a state in the deterministic finite automaton.</typeparam>
public partial class DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>
    : FiniteStateMachine<TInputSymbol, TSymbolValue, TState>,
    IAutomatonDeterministic<TInputSymbol, TSymbolValue, TState>
    where TInputSymbol : ISymbol<TInputSymbol, TSymbolValue>
    where TState : AutomatonState
{
    private readonly IReadOnlyDictionary<TState, IReadOnlyDictionary<TInputSymbol, TState?>> transitions;
    private TState stateCurrent;

    /// <summary>
    /// Initializes a new instance of <see cref="DeterministicFiniteAutomaton{TSymbol, TSymbolValue, TState}" />.
    /// </summary>
    /// <param name="arguments">The constructor arguments.</param>
    /// <exception cref="AutomatonIllegalInitialStateException{TState}">
    /// An <see cref="AutomatonIllegalInitialStateException{TState}" /> is thrown if the initial state is not a recognised state.
    /// </exception>
    /// <exception cref="AutomatonIllegalFinalStatesException{TState}">
    /// An <see cref="AutomatonIllegalFinalStatesException{TState}" /> is thrown if any final states are not recognised states.
    /// </exception>
    public DeterministicFiniteAutomaton(
        DeterministicFiniteAutomatonArguments<TInputSymbol, TSymbolValue, TState> arguments)
    {
        this.AlphabetIn = arguments.AlphabetIn;
        this.States = arguments.Transitions.Keys.ToHashSet();
        InitialState<TState>.ThrowIfIllegal(this.States, arguments.StateInitial);
        this.stateCurrent = arguments.StateInitial;
        this.transitions = arguments.Transitions;
        FinalStates<TState>.ThrowIfIllegal(this.States, arguments.StatesFinal);
        this.StatesFinal = arguments.StatesFinal;
        this.Language = new LanguageDerived(arguments);
    }

    /// <inheritdoc />
    public override IReadOnlySet<TInputSymbol> AlphabetIn { get; }

    /// <inheritdoc />
    public override ILanguageRegular<TInputSymbol, TSymbolValue> Language { get; }

    /// <inheritdoc />
    public override IReadOnlySet<TState> States { get; }

    /// <inheritdoc />
    public override TState StateCurrent => this.stateCurrent;

    /// <inheritdoc />
    public override IReadOnlySet<TState> StatesFinal { get; }

    /// <inheritdoc />
    public override object Clone()
    {
        return new DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>(
            new DeterministicFiniteAutomatonArguments<TInputSymbol, TSymbolValue, TState>(
                this.AlphabetIn,
                this.stateCurrent,
                this.transitions,
                this.StatesFinal));
    }

    /// <summary>
    /// Move to the next state.
    /// </summary>
    /// <param name="inputSymbol">The input symbol.</param>
    /// <returns>The next state.</returns>
    public TState? MoveNext(TInputSymbol inputSymbol)
    {
        if (!this.transitions.TryGetValue(this.stateCurrent, out var transition) || transition is null)
            return default;
        if (!transition.TryGetValue(inputSymbol, out var stateNew) || stateNew is null)
            return default;
        this.stateCurrent = stateNew;
        return stateNew;
    }

    /// <inheritdoc />
    public TState? PeekNextState(TInputSymbol symbol)
    {
        if (!this.transitions.TryGetValue(this.stateCurrent, out var transition) || transition is null)
            return null;
        return transition.TryGetValue(symbol, out var stateNext) && stateNext is not null
            ? stateNext
            : null;
    }
}
