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

namespace BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.DFA;

public partial class DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>
    : IEquatable<DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>>
{
    /// <inheritdoc />
    public bool Equals(DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>? other) =>
        other is not null
        && this.transitions.Equals(other.transitions)
        && this.AlphabetIn.SetEquals(other.AlphabetIn)
        && this.StatesFinal.SetEquals(other.StatesFinal);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is not null
        && (
            ReferenceEquals(this, obj)
            || (obj is DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState> other
                && this.Equals(other)));

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(this.transitions);
        hashCode.Add(this.AlphabetIn);
        hashCode.Add(this.StatesFinal);
        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Determines whether the automata are equal.
    /// </summary>
    /// <param name="left">The left automaton to compare.</param>
    /// <param name="right">The right automaton to compare.</param>
    /// <returns>A value that indicates whether the automata are equal.</returns>
    public static bool operator ==(
        DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>? left,
        DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>? right) =>
        (left is null && right is null)
        || (left is not null && left.Equals(right));

    /// <summary>
    /// Determines whether the automata are not equal.
    /// </summary>
    /// <param name="left">The left automaton to compare.</param>
    /// <param name="right">The right automaton to compare.</param>
    /// <returns>A value that indicates whether the automata are equal.</returns>
    public static bool operator !=(
        DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>? left,
        DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>? right) =>
        (left is null && right is not null)
        || (left is not null && !left.Equals(right));
}
