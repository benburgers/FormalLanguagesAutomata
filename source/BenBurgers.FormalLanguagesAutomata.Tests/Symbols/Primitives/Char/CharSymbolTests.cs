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

using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;

namespace BenBurgers.FormalLanguagesAutomata.Tests.Symbols.Primitives.Char;

public sealed class CharSymbolTests
{
    public static readonly IEnumerable<object?[]> CastTestParameters =
        new[]
        {
            new object?[] { new CharSymbol('a'), 'a' },
            new object?[] { new CharSymbol('b'), 'b' }
        };

    [Theory(DisplayName = $"{nameof(CharSymbol)} Cast")]
    [MemberData(nameof(CastTestParameters))]
    public void CastTests(CharSymbol symbol, char value)
    {
        CharSymbol castFromValue = value;
        Assert.Equal(symbol, castFromValue);
        char castToValue = symbol;
        Assert.Equal(value, castToValue);
    }

    public static readonly IEnumerable<object?[]> ToStringTestParameters =
        new[]
        {
            new object?[] { new CharSymbol('a'), "a" },
            new object?[] { new CharSymbol('b'), "b" }
        };

    [Theory(DisplayName = $"{nameof(CharSymbol)} :: {nameof(CharSymbol.ToString)}")]
    [MemberData(nameof(ToStringTestParameters))]
    public void ToStringTests(CharSymbol symbol, string expected)
    {
        var actual = symbol.ToString();
        Assert.Equal(expected, actual);
    }
}
