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
/// A value of an action symbol.
/// </summary>
/// <typeparam name="TInput">
/// The type of input that the action accepts.
/// </typeparam>
public class ActionSymbolValue<TInput>
    :
    ICloneable,
    IEquatable<ActionSymbolValue<TInput>>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ActionSymbolValue{TInput}" />.
    /// </summary>
    /// <param name="id">
    /// The identifier that identifiers the action symbol value.
    /// </param>
    /// <param name="label">
    /// The label for the <see cref="ActionSymbolValue{TInput}" />.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    public ActionSymbolValue(Guid id, string label, Action<TInput> action)
    {
        this.Id = id;
        this.Label = label;
        this.Action = action;
    }

    /// <summary>
    /// Gets the unique identifier for the action symbol value.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the label for the action symbol value.
    /// </summary>
    public string Label { get; }

    /// <summary>
    /// Gets the action for the action symbol value.
    /// </summary>
    public Action<TInput> Action { get; }

    /// <summary>
    /// Creates a new <see cref="ActionSymbolValue{TInput}" /> that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// The copy of the current instance.
    /// </returns>
    public ActionSymbolValue<TInput> Clone()
    {
        return new ActionSymbolValue<TInput>(this.Id, this.Label, this.Action);
    }

    /// <inheritdoc/>
    public bool Equals(ActionSymbolValue<TInput>? other)
    {
        return other is { Id: { } id } && this.Id.Equals(other.Id);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return this.Label;
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }
}
