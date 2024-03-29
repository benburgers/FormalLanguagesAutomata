﻿/*
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

using BenBurgers.FormalLanguagesAutomata.Exceptions;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Exceptions;

/// <summary>
/// An exception that is thrown if an unexpected error occurs while processing a formal grammar.
/// </summary>
public class GrammarException
    : FormalLanguagesAutomataException
{
    /// <summary>
    /// Initializes a new instance of <see cref="GrammarException" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// The inner exception.
    /// </param>
    internal GrammarException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
