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

namespace BenBurgers.FormalLanguagesAutomata.Symbols.Programmability;

/// <summary>
/// Represents an action symbol in a formal grammar.
/// </summary>
/// <typeparam name="TInput">
/// The type of input that the action accepts.
/// </typeparam>
public class ActionSymbol<TInput>
    : ISymbol<ActionSymbol<TInput>, ActionSymbolValue<TInput>>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ActionSymbolValue{TInput}" />.
    /// </summary>
    /// <param name="value"></param>
    public ActionSymbol(ActionSymbolValue<TInput> value)
    {
        this.Value = value;
    }

    /// <inheritdoc/>
    public ActionSymbolValue<TInput> Value { get; }

    /// <summary>
    /// Creates a new <see cref="ActionSymbol{TInput}" /> that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// The copy of the current instance.
    /// </returns>
    public ActionSymbol<TInput> Clone()
    {
        return new ActionSymbol<TInput>(this.Value);
    }

    /// <inheritdoc/>
    public bool Equals(ISymbol<ActionSymbol<TInput>, ActionSymbolValue<TInput>>? other)
    {
        return other switch
        {
            null => false,
            ISymbol<ActionSymbol<TInput>, ActionSymbolValue<TInput>> { Value: { } Id } => this.Value.Id.Equals(Id)
        };
    }

    /// <inheritdoc/>
    public bool Equals(ActionSymbolValue<TInput>? other)
    {
        return other switch
        {
            null => false,
            ActionSymbolValue<TInput> { Id: { } id } => this.Value.Id.Equals(id)
        };
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
    /// Implicitly casts <paramref name="action" /> to <see cref="ActionSymbol{TInput}" />.
    /// </summary>
    /// <param name="action">
    /// The action enclosed by the symbol.
    /// </param>
    public static implicit operator ActionSymbol<TInput>(Action<TInput> action)
    {
        var id = Guid.NewGuid();
        var label = id.ToString();
        return new(new ActionSymbolValue<TInput>(Guid.NewGuid(), label, action));
    }

    /// <summary>
    /// Implicitly casts <paramref name="symbol" /> to <see cref="Action{TInput}" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator Action<TInput>(ActionSymbol<TInput> symbol) =>
        symbol.Value.Action;

    /// <summary>
    /// Implicitly casts <paramref name="value" /> to <see cref="ActionSymbol{TInput}" />.
    /// </summary>
    /// <param name="value">
    /// The value to cast.
    /// </param>
    public static implicit operator ActionSymbol<TInput>(ActionSymbolValue<TInput> value) =>
        new(value);

    /// <summary>
    /// Implicitly casts <paramref name="symbol" /> to <see cref="ActionSymbolValue{TInput}" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator ActionSymbolValue<TInput>(ActionSymbol<TInput> symbol) =>
        symbol.Value;
}
