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

namespace BenBurgers.FormalLanguagesAutomata.Automata;

/// <summary>
/// An automaton's state.
/// </summary>
public abstract class AutomatonState
{
    /// <summary>
    /// Initializes a new instance of <see cref="AutomatonState" />.
    /// </summary>
    /// <param name="id">The unique identifier of the state.</param>
    protected AutomatonState(Guid id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Gets the unique identifier of the state.
    /// </summary>
    public Guid Id { get; }

    /// <inheritdoc cref="object.Equals(object?)" />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            AutomatonState { Id: { } id } => this.Id.Equals(id),
            _ => false
        };
    }

    /// <inheritdoc cref="object.GetHashCode" />
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
