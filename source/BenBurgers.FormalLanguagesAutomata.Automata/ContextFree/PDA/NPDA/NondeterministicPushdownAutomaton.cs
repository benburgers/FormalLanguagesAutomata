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
using BenBurgers.FormalLanguagesAutomata.Languages.ContextFree;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.NPDA;

public partial class NondeterministicPushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    : PushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>,
    IAutomatonNondeterministic<TInputSymbol, TInputSymbolValue, TState>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TState : AutomatonState
    where TStackSymbol : IStackSymbol<TStackSymbol>
{
    private readonly NondeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> arguments;
    private readonly Stack<TStackSymbol> stack;
    private TState stateCurrent;

    public NondeterministicPushdownAutomaton(
        NondeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> arguments)
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
                        .SelectMany(v => v.Select(r => r.State)))
                .ToHashSet();
    }

    public override ILanguageContextFree<TInputSymbol, TInputSymbolValue> Language => throw new NotImplementedException();

    /// <inheritdoc />
    public override IReadOnlySet<TInputSymbol> AlphabetIn =>
        this.arguments.AlphabetIn;

    /// <inheritdoc />
    public override IReadOnlySet<TState> States { get; }

    /// <inheritdoc />
    public override TState StateCurrent => this.stateCurrent;

    /// <inheritdoc />
    public override IReadOnlySet<TState> StatesFinal => throw new NotImplementedException();

    private NondeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> CreateTransitionKey(
        TInputSymbol inputSymbol,
        TStackSymbol? stackSymbol) =>
        new(this.stateCurrent, inputSymbol, stackSymbol);

    /// <inheritdoc />
    public override object Clone()
    {
        var automaton = new NondeterministicPushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>(this.arguments);
        automaton.stateCurrent = this.stateCurrent;
        return automaton;
    }

    /// <inheritdoc />
    public TState? MoveNext(TInputSymbol inputSymbol, TState state, TStackSymbol stackSymbol)
    {
        this.stack.TryPeek(out var stackSymbol);
        var transitionKey = this.CreateTransitionKey(inputSymbol, stackSymbol);
        if (!this.arguments.Transitions.TryGetValue(transitionKey, out var transitionResult) || transitionResult is null)
            return null;
        
    }

    /// <inheritdoc />
    public IReadOnlySet<TState> PeekNextStates(TInputSymbol inputSymbol)
    {
        throw new NotImplementedException();
    }
}
