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

namespace BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;

/// <summary>
/// A terminal that contains a <see cref="char" /> value.
/// </summary>
public class CharTerminal
    : Terminal<CharSymbol, char>
{
    /// <summary>
    /// Initializes a new instance of <see cref="CharTerminal" />.
    /// </summary>
    /// <param name="symbol">
    /// The <see cref="CharSymbol" /> value.
    /// </param>
    public CharTerminal(CharSymbol symbol)
        : base(symbol)
    {
    }

    /// <summary>
    /// Casts a <paramref name="value" /> of type <see cref="char" /> to a <see cref="CharTerminal" />.
    /// </summary>
    /// <param name="value">
    /// The value to cast.
    /// </param>
    public static implicit operator CharTerminal(char value) => new(value);

    /// <summary>
    /// Casts a <paramref name="terminal" /> of type <see cref="CharTerminal" /> to a <see cref="char" />.
    /// </summary>
    /// <param name="terminal">
    /// The terminal to cast.
    /// </param>
    public static implicit operator char(CharTerminal terminal) => terminal.Symbol.Value;
}