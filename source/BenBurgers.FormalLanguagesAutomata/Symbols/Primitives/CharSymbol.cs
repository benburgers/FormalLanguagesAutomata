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
/// A character symbol.
/// </summary>
public class CharSymbol
    : ISymbol<CharSymbol, char>
{
    /// <summary>
    /// Initializes a new instance of <see cref="CharSymbol" />.
    /// </summary>
    /// <param name="value">
    /// The value of the symbol.
    /// </param>
    public CharSymbol(char value)
    {
        this.Value = value;
    }

    /// <inheritdoc />
    public char Value { get; }

    /// <inheritdoc/>
    public CharSymbol Clone()
    {
        return new CharSymbol(this.Value);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            CharSymbol cs => this.Value.Equals(cs.Value),
            char c => this.Value.Equals(c),
            _ => false
        };
    }

    /// <inheritdoc />
    public bool Equals(char other)
    {
        return this.Value.Equals(other);
    }

    /// <inheritdoc/>
    public bool Equals(ISymbol<CharSymbol, char>? other)
    {
        return other switch
        {
            null => false,
            ISymbol<CharSymbol, char> s => this.Value.Equals(s.Value)
        };
    }

    /// <summary>
    /// Determines whether this symbol and the <paramref name="other" /> are equal.
    /// </summary>
    /// <param name="other">
    /// The other <see cref="CharSymbol" /> to compare.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether the two <see cref="CharSymbol" /> are equal.
    /// </returns>
    public bool Equals(CharSymbol? other)
    {
        return other switch
        {
            null => false,
            CharSymbol { Value: { } value } => this.Value.Equals(value)
        };
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return this.Value.ToString();
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Nullable{Char}" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator char?(CharSymbol? symbol)
    {
        return symbol?.Value;
    }

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="CharSymbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The character to cast.
    /// </param>
    public static implicit operator CharSymbol?(char? symbol)
    {
        return
            symbol is null
                ? null
                : new CharSymbol(symbol.Value);
    }

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="char" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator char(CharSymbol symbol)
    {
        return symbol.Value;
    }

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="CharSymbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The character to cast.
    /// </param>
    public static implicit operator CharSymbol(char symbol)
    {
        return new CharSymbol(symbol);
    }

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
    public static bool operator ==(CharSymbol? one, CharSymbol? other)
    {
        return one?.Equals(other) ?? false;
    }

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
    public static bool operator !=(CharSymbol? one, CharSymbol? other)
    {
        return !(one?.Equals(other) ?? false);
    }
}
