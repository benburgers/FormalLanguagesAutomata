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

internal static class FinalStates<TState>
{
    internal static void ThrowIfIllegal(IReadOnlySet<TState> states, IReadOnlySet<TState> statesFinal)
    {
        if (statesFinal.Any((sf) => !states.Contains(sf)))
            throw new AutomatonIllegalFinalStatesException<TState>(states, statesFinal);
    }
}
