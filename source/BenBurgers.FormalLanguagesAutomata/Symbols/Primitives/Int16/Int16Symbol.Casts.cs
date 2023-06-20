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

namespace BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Int16;

public sealed partial class Int16Symbol
{
    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Nullable{Int16}" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator short?(Int16Symbol? symbol) => symbol?.Value;

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Int16Symbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The integer to cast.
    /// </param>
    public static implicit operator Int16Symbol?(short? symbol) =>
        symbol is null
            ? null
            : new Int16Symbol(symbol.Value);

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Nullable{Int16}" />.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to cast.
    /// </param>
    public static implicit operator short(Int16Symbol symbol) => symbol.Value;

    /// <summary>
    /// Implicitly casts the <paramref name="symbol" /> to an equivalent <see cref="Int16Symbol" />.
    /// </summary>
    /// <param name="symbol">
    /// The integer to cast.
    /// </param>
    public static implicit operator Int16Symbol(short symbol) => new(symbol);
}
