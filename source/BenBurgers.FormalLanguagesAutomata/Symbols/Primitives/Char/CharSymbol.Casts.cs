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

namespace BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;

public sealed partial class CharSymbol
{
    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Nullable{Char}" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator char?(CharSymbol? symbol)
    {
        return symbol?.Value;
    }

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="CharSymbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The character to cast.
    /// </param>
    public static implicit operator CharSymbol?(char? symbol)
    {
        return
            symbol is null
                ? null
                : new CharSymbol(symbol.Value);
    }

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="char" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator char(CharSymbol symbol)
    {
        return symbol.Value;
    }

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="CharSymbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The character to cast.
    /// </param>
    public static implicit operator CharSymbol(char symbol)
    {
        return new CharSymbol(symbol);
    }
}