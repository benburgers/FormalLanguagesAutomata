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

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.Stack;

/// <summary>
/// A pushdown automaton's stack symbol that is represented by a <see cref="string" />.
/// </summary>
public sealed class StringStackSymbol : IStackSymbol<StringStackSymbol>
{
    /// <summary>
    /// Initializes a new instance of <see cref="StringStackSymbol" />.
    /// </summary>
    /// <param name="name">The name of the stack symbol.</param>
    public StringStackSymbol(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// Gets the name of the stack symbol.
    /// </summary>
    public string Name { get; }

    /// <inheritdoc />
    public bool Equals(StringStackSymbol? other) =>
        other is not null
        && this.Name == other.Name;

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is not null
        && (ReferenceEquals(this, obj)
        || (obj is StringStackSymbol other
            && this.Equals(other)));

    /// <inheritdoc />
    public override int GetHashCode() => this.Name.GetHashCode();

    /// <inheritdoc />
    public override string ToString() => this.Name;

    /// <summary>
    /// Determines whether the stack symbols are equal.
    /// </summary>
    /// <param name="left">The left stack symbol to compare.</param>
    /// <param name="right">The right stack symbol to compare.</param>
    /// <returns>A value that indicates whether the stack symbols are equal.</returns>
    public static bool operator ==(StringStackSymbol? left, StringStackSymbol? right) =>
        (left is null && right is null)
        || (left is not null && left.Equals(right));

    /// <summary>
    /// Determines whether the stack symbols are not equal.
    /// </summary>
    /// <param name="left">The left stack symbol to compare.</param>
    /// <param name="right">The right stack symbol to compare.</param>
    /// <returns>A value that indicates whether the stack symbols are not equal.</returns>
    public static bool operator !=(StringStackSymbol? left, StringStackSymbol? right) =>
        (left is null && right is not null)
        || (left is not null && !left.Equals(right));
}
