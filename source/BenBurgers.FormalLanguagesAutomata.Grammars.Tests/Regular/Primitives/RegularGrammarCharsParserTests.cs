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

using BenBurgers.FormalLanguagesAutomata.Grammars.Regular.Primitives;
using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;
using System.Text;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Tests.Regular.Primitives;

public class RegularGrammarCharsParserTests
{
    [Fact]
    public async Task ParseTestAsync()
    {
        // Arrange
        var startVariable = new CharVariable('S');
        var input = @"
S → A
A → Bb
B → C
C → a
";
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
        var parser = new RegularGrammarCharsParser(startVariable, null);

        // Act
        var grammar = await parser.ParseAsync(memoryStream, CancellationToken.None);

        // Assert
        Assert.NotNull(grammar);
    }
}