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

namespace BenBurgers.FormalLanguagesAutomata.Symbols;

/// <summary>
/// A symbol.
/// </summary>
/// <typeparam name="TSymbolValue">The type of value of the symbol.</typeparam>
public class Symbol<TSymbolValue>
    : ISymbol<Symbol<TSymbolValue>, TSymbolValue>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Symbol{TSymbolValue}" />.
    /// </summary>
    /// <param name="value">The value of the symbol.</param>
    public Symbol(TSymbolValue value)
    {
        this.Value = value;
    }

    /// <inheritdoc />
    public TSymbolValue Value { get; }

    /// <inheritdoc />
    public virtual object Clone()
    {
        return new Symbol<TSymbolValue>(this.Value);
    }

    /// <inheritdoc />
    public bool Equals(ISymbol<Symbol<TSymbolValue>, TSymbolValue>? other)
    {
        return other switch
        {
            null => false,
            _ when ReferenceEquals(this, other) => true,
            { Value: { } otherValue } => this.Value?.Equals(otherValue) ?? false,
            _ => false
        };
    }

    /// <inheritdoc />
    public bool Equals(TSymbolValue? other)
    {
        return other switch
        {
            null => false,
            _ when ReferenceEquals(this.Value, other) => true,
            { } otherValue => this.Value?.Equals(otherValue) ?? false
        };
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            ISymbol<Symbol<TSymbolValue>, TSymbolValue> other => this.Equals(other),
            TSymbolValue other => this.Equals(other),
            _ => false
        };
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return this.Value?.GetHashCode() ?? 0;
    }

    /// <inheritdoc />
    public override string? ToString()
    {
        return this.Value?.ToString();
    }

    /// <summary>
    /// Determines whether <paramref name="one" /> and <paramref name="other" /> are equal.
    /// </summary>
    /// <param name="one">One to compare.</param>
    /// <param name="other">The other to compare.</param>
    /// <returns>A <see cref="bool" /> that indicates whether the two are equal.</returns>
    public static bool operator ==(Symbol<TSymbolValue>? one, TSymbolValue? other) =>
        Equals(one, other);

    /// <summary>
    /// Determines whether <paramref name="one" /> and <paramref name="other" /> are not equal.
    /// </summary>
    /// <param name="one">One to compare.</param>
    /// <param name="other">The other to compare.</param>
    /// <returns>A <see cref="bool" /> that indicates whether the two are not equal.</returns>
    public static bool operator !=(Symbol<TSymbolValue>? one, TSymbolValue? other) =>
        !Equals(one, other);
    
    /// <summary>
    /// Determines whether <paramref name="one" /> and <paramref name="other" /> are equal.
    /// </summary>
    /// <param name="one">One to compare.</param>
    /// <param name="other">The other to compare.</param>
    /// <returns>A <see cref="bool" /> that indicates whether the two are equal.</returns>
    public static bool operator ==(TSymbolValue? one, Symbol<TSymbolValue>? other) =>
        Equals(one, other);

    /// <summary>
    /// Determines whether <paramref name="one" /> and <paramref name="other" /> are not equal.
    /// </summary>
    /// <param name="one">One to compare.</param>
    /// <param name="other">The other to compare.</param>
    /// <returns>A <see cref="bool" /> that indicates whether the two are not equal.</returns>
    public static bool operator !=(TSymbolValue? one, Symbol<TSymbolValue>? other) =>
        !Equals(one, other);
}
