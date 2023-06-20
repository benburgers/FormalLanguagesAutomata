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
/// An automaton's state with a label.
/// </summary>
public class AutomatonLabelState
    : AutomatonState
{
    /// <summary>
    /// Initializes a new instance of <see cref="AutomatonLabelState" />.
    /// </summary>
    /// <param name="id">The unique identifier of the state.</param>
    /// <param name="label">The label of the state.</param>
    public AutomatonLabelState(Guid id, string label)
        : base(id)
    {
        this.Label = label;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="AutomatonLabelState" />.
    /// </summary>
    /// <param name="label">The label of the state.</param>
    public AutomatonLabelState(string label)
        : this(Guid.NewGuid(), label)
    {
    }

    /// <summary>
    /// Gets the state's label.
    /// </summary>
    public string Label { get; }
}
