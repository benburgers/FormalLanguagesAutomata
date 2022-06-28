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

namespace BenBurgers.FormalLanguagesAutomata.Symbols.Primitives;

/// <summary>
/// An integer symbol.
/// </summary>
public class Int32Symbol
    : ISymbol<Int32Symbol, int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Int32Symbol" />.
    /// </summary>
    /// <param name="value">
    /// The value of the symbol.
    /// </param>
    public Int32Symbol(int value)
    {
        this.Value = value;
    }

    /// <inheritdoc/>
    public int Value { get; }

    /// <summary>
    /// Creates a new <see cref="Int32Symbol" /> that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// The copy of the current instance.
    /// </returns>
    public Int32Symbol Clone()
    {
        return new Int32Symbol(this.Value);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            ISymbol<Int32Symbol, int> { Value: { } value } => this.Value.Equals(value),
            int i => this.Value.Equals(i),
            _ => false
        };

    /// <inheritdoc/>
    public bool Equals(int other) => this.Value.Equals(other);

    /// <inheritdoc/>
    public bool Equals(ISymbol<Int32Symbol, int>? other) =>
        other switch
        {
            null => false,
            ISymbol<Int32Symbol, int> s => this.Value.Equals(s.Value)
        };

    /// <summary>
    /// Determines whether the two <see cref="Int32Symbol" /> are equal.
    /// </summary>
    /// <param name="other">
    /// The other <see cref="Int32Symbol" /> to compare for equality.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether this symbol is equal to <paramref name="other" />.
    /// </returns>
    public bool Equals(Int32Symbol? other)
    {
        return other switch
        {
            null => false,
            Int32Symbol s => this.Value.Equals(s.Value)
        };
    }

    /// <inheritdoc/>
    public override int GetHashCode() => this.Value.GetHashCode();

    object ICloneable.Clone() => this.Clone();

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Nullable{Int32}" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator int?(Int32Symbol? symbol) => symbol?.Value;

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Int32Symbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The integer to cast.
    /// </param>
    public static implicit operator Int32Symbol?(int? symbol) =>
        symbol is null
            ? null
            : new Int32Symbol(symbol.Value);

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="int" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator int(Int32Symbol symbol) => symbol.Value;

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Int32Symbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The integer to cast.
    /// </param>
    public static implicit operator Int32Symbol(int symbol) => new(symbol);

    /// <summary>
    /// Determines whether <paramref name="one" /> and <paramref name="other" /> are equal.
    /// </summary>
    /// <param name="one">
    /// One to compare for equality.
    /// </param>
    /// <param name="other">
    /// Another to compare for equality.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether the symbols are equal.
    /// </returns>
    public static bool operator ==(Int32Symbol? one, Int32Symbol? other) => one?.Equals(other) ?? false;

    /// <summary>
    /// Determines whether <paramref name="one" /> and <paramref name="other" /> are equal.
    /// </summary>
    /// <param name="one">
    /// One to compare for equality.
    /// </param>
    /// <param name="other">
    /// Another to compare for equality.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether the symbols are not equal.
    /// </returns>
    public static bool operator !=(Int32Symbol? one, Int32Symbol? other) => !(one?.Equals(other) ?? false);
}
