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

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.DPDA;

public sealed partial class DeterministicPushdownTransitionResult<TState, TStackSymbol>
    : IEquatable<DeterministicPushdownTransitionResult<TState, TStackSymbol>>
{
    /// <inheritdoc />
    public bool Equals(DeterministicPushdownTransitionResult<TState, TStackSymbol>? other) =>
        other is not null
        && Equals(this.StackSymbol, other.StackSymbol)
        && Equals(this.State, other.State);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is not null
        && (ReferenceEquals(this, obj)
        || (obj is DeterministicPushdownTransitionResult<TState, TStackSymbol> other
            && this.Equals(other)));

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(this.StackSymbol);
        hashCode.Add(this.State);
        return hashCode.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString() =>
        $"({this.StackSymbol?.ToString() ?? "∅"}, {this.State})";

    /// <summary>
    /// Determines whether the transition results are equal.
    /// </summary>
    /// <param name="left">The left result to compare.</param>
    /// <param name="right">The right result to compare.</param>
    /// <returns>A value that indicates whether the results are equal.</returns>
    public static bool operator ==(
        DeterministicPushdownTransitionResult<TState, TStackSymbol>? left,
        DeterministicPushdownTransitionResult<TState, TStackSymbol>? right) =>
        Equals(left, right);

    /// <summary>
    /// Determines whether the transition results are not equal.
    /// </summary>
    /// <param name="left">The left result to compare.</param>
    /// <param name="right">The right result to compare.</param>
    /// <returns>A value that indicates whether the results are not equal.</returns>
    public static bool operator !=(
        DeterministicPushdownTransitionResult<TState, TStackSymbol>? left,
        DeterministicPushdownTransitionResult<TState, TStackSymbol>? right) =>
        !Equals(left, right);
}
