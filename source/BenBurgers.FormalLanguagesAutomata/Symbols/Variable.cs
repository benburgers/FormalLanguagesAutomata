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
/// Represents a variable in a formal grammar.
/// </summary>
public abstract class Variable : IElement
{
    /// <inheritdoc/>
    public abstract Variable Clone();

    /// <inheritdoc/>
    public abstract override string? ToString();

    object ICloneable.Clone()
    {
        return this.Clone();
    }
}

/// <summary>
/// Represents a variable in a formal grammar.
/// </summary>
/// <typeparam name="TSymbol">
/// The type of symbol for the variable.
/// </typeparam>
/// <typeparam name="TSymbolValue">
/// The type of symbol value for the variable.
/// </typeparam>
public class Variable<TSymbol, TSymbolValue>
    : Variable, IEquatable<Variable<TSymbol, TSymbolValue>>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Variable" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol that represents the variable.
    /// </param>
    public Variable(TSymbol symbol)
    {
        this.Symbol = symbol;
    }

    /// <summary>
    /// Gets the symbol that represents the variable.
    /// </summary>
    public TSymbol Symbol { get; }

    /// <summary>
    /// Creates a new <see cref="Variable{TSymbol, TSymbolValue}" /> that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// The copy of the current instance.
    /// </returns>
    public override Variable<TSymbol, TSymbolValue> Clone()
    {
        return new Variable<TSymbol, TSymbolValue>((TSymbol)this.Symbol.Clone());
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Variable<TSymbol, TSymbolValue> { } other && this.Equals(other);
    }

    /// <inheritdoc/>
    public bool Equals(Variable<TSymbol, TSymbolValue>? other)
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
