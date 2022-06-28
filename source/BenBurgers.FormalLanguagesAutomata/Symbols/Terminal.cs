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
/// Represents a terminal in a formal language.
/// </summary>
public abstract class Terminal : IElement
{
    /// <summary>
    /// Creates a new <see cref="Terminal" /> that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// The copy of the current instance.
    /// </returns>
    public abstract Terminal Clone();

    /// <inheritdoc/>
    public abstract override string? ToString();

    object ICloneable.Clone()
    {
        return this.Clone();
    }
}

/// <summary>
/// Initializes a new instance of <see cref="Terminal{TSymbol, TSymbolValue}" />.
/// </summary>
/// <typeparam name="TSymbol">
/// The type of symbol that represents the <see cref="Terminal{TSymbol, TSymbolValue}" />.
/// </typeparam>
/// <typeparam name="TSymbolValue">
/// The type of symbol value for the <see cref="Terminal{TSymbol, TSymbolValue}" />.
/// </typeparam>
public class Terminal<TSymbol, TSymbolValue>
    : Terminal, IEquatable<Terminal<TSymbol, TSymbolValue>>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Terminal" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol that represents the terminal.
    /// </param>
    public Terminal(TSymbol symbol)
    {
        this.Symbol = symbol;
    }

    /// <summary>
    /// Gets the symbol that represents the terminal.
    /// </summary>
    public TSymbol Symbol { get; }

    /// <summary>
    /// Creates a new <see cref="Terminal{TSymbol, TSymbolValue}" /> that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// The copy of the current instance.
    /// </returns>
    public override Terminal<TSymbol, TSymbolValue> Clone()
    {
        return new Terminal<TSymbol, TSymbolValue>((TSymbol)this.Symbol.Clone());
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Terminal<TSymbol, TSymbolValue> { } other && this.Equals(other);
    }

    /// <inheritdoc/>
    public bool Equals(Terminal<TSymbol, TSymbolValue>? other)
    {
        return other is { Symbol: { } symbol } && this.Symbol.Equals(symbol);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.Symbol.GetHashCode();
    }

    /// <inheritdoc/>
    public override string? ToString()
    {
        return this.Symbol.ToString();
    }
}
