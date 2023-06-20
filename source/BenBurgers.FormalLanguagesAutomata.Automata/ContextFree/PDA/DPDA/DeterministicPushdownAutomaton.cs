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
using BenBurgers.FormalLanguagesAutomata.Automata.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Languages.ContextFree;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.DPDA;

/// <summary>
/// A deterministic pushdown automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of input symbols of the automaton.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of value of an input symbol of the automaton.</typeparam>
/// <typeparam name="TState">The type of state of the automaton.</typeparam>
/// <typeparam name="TStackSymbol">The type of stack symbol of the automaton.</typeparam>
public partial class DeterministicPushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    : PushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>,
    IAutomatonDeterministic<TInputSymbol, TInputSymbolValue, TState>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TState : AutomatonState
    where TStackSymbol : IStackSymbol<TStackSymbol>
{
    private readonly DeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> arguments;
    private readonly Stack<TStackSymbol> stack;
    private TState stateCurrent;

    /// <summary>
    /// Initializes a new instance of <see cref="DeterministicPushdownAutomaton{TInputSymbol, TInputSymbolValue, TState, TStackSymbol}" />.
    /// </summary>
    /// <param name="arguments">The constructor arguments.</param>
    /// <exception cref="AutomatonIllegalInitialStateException{TState}">
    /// An <see cref="AutomatonIllegalInitialStateException{TState}" /> is thrown if the initial state is not a recognised state.
    /// </exception>
    /// <exception cref="AutomatonIllegalFinalStatesException{TState}">
    /// An <see cref="AutomatonIllegalFinalStatesException{TState}" /> is thrown if any final states are not recognised states.
    /// </exception>
    public DeterministicPushdownAutomaton(
        DeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> arguments)
    {
        this.arguments = arguments;
        this.States =
            arguments
                .Transitions
                .Keys
                .Select(k => k.State)
                .Union(
                    arguments
                        .Transitions
                        .Values
                        .Select(v => v.State))
                .ToHashSet();
        InitialState<TState>.ThrowIfIllegal(this.States, arguments.StateInitial);
        this.stateCurrent = arguments.StateInitial;
        FinalStates<TState>.ThrowIfIllegal(this.States, arguments.StatesFinal);
        this.stack = new Stack<TStackSymbol>();
    }

    /// <inheritdoc />
    public override ILanguageContextFree<TInputSymbol, TInputSymbolValue> Language =>
        new LanguageDerived(this.arguments);

    /// <inheritdoc />
    public override IReadOnlySet<TInputSymbol> AlphabetIn =>
        this.arguments.AlphabetIn;

    /// <inheritdoc />
    public override IReadOnlySet<TState> States { get; }

    /// <inheritdoc />
    public override TState StateCurrent => this.stateCurrent;

    /// <inheritdoc />
    public override IReadOnlySet<TState> StatesFinal => this.arguments.StatesFinal;

    private DeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> CreateTransitionKey(
        TInputSymbol inputSymbol,
        TStackSymbol? stackSymbol) =>
        new(this.stateCurrent, inputSymbol, stackSymbol);

    /// <inheritdoc />
    public override object Clone() =>
        new DeterministicPushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>(this.arguments)
        {
            stateCurrent = this.stateCurrent
        };

    /// <inheritdoc />
    public TState? MoveNext(TInputSymbol symbol)
    {
        this.stack.TryPeek(out var stackSymbol);
        var transitionKey = this.CreateTransitionKey(symbol, stackSymbol);
        if (!this.arguments.Transitions.TryGetValue(transitionKey, out var transitionResult) || transitionResult is null)
            return null;
        var (stateNext, stackSymbolNext) = transitionResult;
        if (stackSymbol is not null && stackSymbolNext is null)
            this.stack.Pop();
        if (stackSymbolNext is { })
            this.stack.Push(stackSymbolNext);
        this.stateCurrent = stateNext;
        return stateNext;
    }

    /// <inheritdoc />
    public TState? PeekNextState(TInputSymbol symbol)
    {
        this.stack.TryPeek(out var stackSymbol);
        var transitionKey = this.CreateTransitionKey(symbol, stackSymbol);
        if (!this.arguments.Transitions.TryGetValue(transitionKey, out var transitionResult) || transitionResult is null)
            return null;
        var (stateNext, _) = transitionResult;
        return stateNext;
    }
}
