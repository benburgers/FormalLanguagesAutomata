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

namespace BenBurgers.FormalLanguagesAutomata.Automata.Exceptions;

/// <summary>
/// An exception that is thrown if an automaton receives one or more final states that are not recognised.
/// </summary>
/// <typeparam name="TState">The type of state.</typeparam>
public sealed class AutomatonIllegalFinalStatesException<TState>
    : AutomatonException
{
    internal AutomatonIllegalFinalStatesException(IReadOnlySet<TState> states, IReadOnlySet<TState> statesFinal)
        : base(CreateExceptionMessage(states, statesFinal))
    {
    }

    private static string CreateExceptionMessage(IReadOnlySet<TState> states, IReadOnlySet<TState> statesFinal)
    {
        var statesIllegal = string.Join(", ", statesFinal.Where((fn) => !states.Contains(fn)).ToArray());
        return string.Format(ExceptionMessages.IllegalFinalStates, statesIllegal);
    }
}
