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
/// A word with characters.
/// </summary>
public sealed class CharWord
    : Word<CharSymbol, char>
{
    /// <summary>
    /// Initializes a new instance of <see cref="CharWord" />.
    /// </summary>
    /// <param name="symbols">
    /// The symbols in the word.
    /// </param>
    public CharWord(IEnumerable<CharSymbol> symbols)
        : base(symbols)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="CharWord" />.
    /// </summary>
    /// <param name="symbols">
    /// The symbols in the word.
    /// </param>
    public CharWord(IEnumerable<char> symbols)
        : this(symbols.Select(s =>  new CharSymbol(s)))
    {
    }
}
