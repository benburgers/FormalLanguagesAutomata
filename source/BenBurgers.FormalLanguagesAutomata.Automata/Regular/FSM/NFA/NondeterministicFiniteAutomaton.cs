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

namespace BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.NFA;

/// <summary>
/// A nondeterministic finite automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of symbols in the nondeterministic finite automaton.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of value of a symbol in the nondeterministic finite automaton.</typeparam>
/// <typeparam name="TState">The type of a state in the nondeterministic finite automaton.</typeparam>
public partial class NondeterministicFiniteAutomaton<TInputSymbol, TInputSymbolValue, TState>
    : FiniteStateMachine<TInputSymbol, TInputSymbolValue, TState>,
    IAutomatonNondeterministic<TInputSymbol, TInputSymbolValue, TState>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TState : AutomatonState
{
    private readonly IReadOnlyDictionary<TState, IReadOnlyDictionary<TInputSymbol, IReadOnlySet<TState>>> transitions;
    private TState stateCurrent;

    /// <summary>
    /// Initializes a new instance of <see cref="NondeterministicFiniteAutomaton{TSymbol, TSymbolValue, TState}" />.
    /// </summary>
    /// <param name="arguments">The constructor arguments.</param>
    /// <exception cref="AutomatonIllegalInitialStateException{TState}">
    /// An <see cref="AutomatonIllegalInitialStateException{TState}" /> is thrown if the initial state is not a recognised state.
    /// </exception>
    /// <exception cref="AutomatonIllegalFinalStatesException{TState}">
    /// An <see cref="AutomatonIllegalFinalStatesException{TState}" /> is thrown if any final states are not recognised states.
    /// </exception>
    public NondeterministicFiniteAutomaton(
        NondeterministicFiniteAutomatonArguments<TInputSymbol, TInputSymbolValue, TState> arguments)
    {
        this.AlphabetIn = arguments.AlphabetIn;
        this.States = arguments.Transitions.Keys.ToHashSet();
        InitialState<TState>.ThrowIfIllegal(this.States, arguments.StateInitial);
        this.stateCurrent = arguments.StateInitial;
        this.transitions = arguments.Transitions;
        FinalStates<TState>.ThrowIfIllegal(this.States, arguments.StatesFinal);
        this.StatesFinal = arguments.StatesFinal;
        this.Language = new LanguageDerived(this);
    }

    /// <inheritdoc />
    public override IReadOnlySet<TInputSymbol> AlphabetIn { get; }

    /// <inheritdoc />
    public override ILanguageRegular<TInputSymbol, TInputSymbolValue> Language { get; }

    /// <inheritdoc />
    public override IReadOnlySet<TState> States { get; }

    /// <inheritdoc />
    public override TState StateCurrent => this.stateCurrent;

    /// <inheritdoc />
    public override IReadOnlySet<TState> StatesFinal { get; }

    /// <inheritdoc />
    public override object Clone()
    {
        return new NondeterministicFiniteAutomaton<TInputSymbol, TInputSymbolValue, TState>(
            new NondeterministicFiniteAutomatonArguments<TInputSymbol, TInputSymbolValue, TState>(
                this.AlphabetIn,
                this.stateCurrent,
                this.transitions,
                this.StatesFinal));
    }

    /// <inheritdoc />
    public TState? MoveNext(TInputSymbol symbol, TState state)
    {
        if (!this.transitions.TryGetValue(this.stateCurrent, out var transition) || transition is null)
            return default;
        if (transition.TryGetValue(symbol, out var statesNext) && statesNext.Contains(state))
        {
            this.stateCurrent = state;
            return state;
        }
        return default;
    }

    /// <inheritdoc />
    public IReadOnlySet<TState> PeekNextStates(TInputSymbol symbol)
    {
        if (!this.transitions.TryGetValue(this.stateCurrent, out var transition))
            return new HashSet<TState>();
        return transition.TryGetValue(symbol, out var statesNext)
            ? statesNext
            : new HashSet<TState>();
    }
}
