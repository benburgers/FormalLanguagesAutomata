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

using System.Collections;

namespace BenBurgers.FormalLanguagesAutomata.Symbols;

/// <summary>
/// A word that contains symbols.
/// </summary>
/// <typeparam name="TSymbol">The type of the symbols in the word.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the word.</typeparam>
public class Word<TSymbol, TSymbolValue>
    : IWord<TSymbol, TSymbolValue>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Word{TSymbol, TSymbolValue}" />.
    /// </summary>
    /// <param name="symbols">
    /// The symbols in the word.
    /// </param>
    public Word(IEnumerable<TSymbol> symbols)
    {
        this.Symbols = symbols.ToArray();
    }

    /// <summary>
    /// Gets the symbols in the word.
    /// </summary>
    public IReadOnlyList<TSymbol> Symbols { get; }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            IWord<TSymbol, TSymbolValue> other => this.Equals(other),
            _ => false
        };
    }

    /// <inheritdoc />
    public bool Equals(IWord<TSymbol, TSymbolValue>? other)
    {
        if (other is null)
            return false;
        return Enumerable.SequenceEqual(this, other);
    }

    /// <inheritdoc />
    public IEnumerator<TSymbol> GetEnumerator()
    {
        return this.Symbols.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Symbols.GetEnumerator();
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        foreach (var symbol in this.Symbols)
        {
            hashCode.Add(symbol.Value);
        }
        return hashCode.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Concat(this.Symbols.Select(s => s.Value?.ToString()));
    }
}
