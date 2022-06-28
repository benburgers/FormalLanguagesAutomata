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
using BenBurgers.FormalLanguagesAutomata.Symbols;
using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Tests.Regular.Primitives;

public class RegularGrammarCharsTests
{
    [Fact]
    public void ToStringTest()
    {
        // Arrange
        const string Expected =
@"A → Bx
B → Cy
C → z";
        var variables = new HashSet<CharVariable>
        {
            'A', 'B', 'C'
        };
        var terminals = new HashSet<CharTerminal>
        {
            'x', 'y', 'z'
        };
        var productionRules = new Dictionary<CharVariable, IReadOnlyCollection<IReadOnlyList<IElement>>>
        {
            { 'A', new [] { new List<IElement> { new CharVariable('B'), new CharTerminal('x') } } },
            { 'B', new [] { new List<IElement> { new CharVariable('C'), new CharTerminal('y') } } },
            { 'C', new [] { new List<IElement> { new CharTerminal('z') } } }
        };
        var grammar = new RegularGrammarChars(variables, terminals, productionRules, 'A', null);

        // Act
        var grammarString = grammar.ToString();

        // Assert
        Assert.NotNull(grammarString);
        Assert.Equal(Expected, grammarString);
    }
}