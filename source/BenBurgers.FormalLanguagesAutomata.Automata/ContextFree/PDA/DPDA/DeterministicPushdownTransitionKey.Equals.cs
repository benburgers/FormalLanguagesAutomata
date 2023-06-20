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

public sealed partial class DeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    : IEquatable<DeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>>
{
    /// <inheritdoc />
    public bool Equals(DeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>? other) =>
        other is not null
        && this.InputSymbol.Equals(other.InputSymbol)
        && Equals(this.StackSymbol, other.StackSymbol);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is not null
        && (
            ReferenceEquals(this, obj)
            || (obj is DeterministicPushdownTransitionKey<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> other
                && this.Equals(other)));

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(this.InputSymbol);
        hashCode.Add(this.StackSymbol);
        return hashCode.ToHashCode();
    }
}
