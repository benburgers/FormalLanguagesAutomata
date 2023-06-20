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

using BenBurgers.FormalLanguagesAutomata.Grammars.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Grammars.Regular;
using BenBurgers.FormalLanguagesAutomata.Symbols;
using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;
using System.Collections.ObjectModel;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Tests.Regular;

public class RegularGrammarTests
{
    [Fact]
    public void GrammarNotRegularTest()
    {
        // Arrange
        var aVariable = new Variable<CharSymbol, char>('A');
        var bVariable = new Variable<CharSymbol, char>('B');
        var variables = new HashSet<Variable<CharSymbol, char>>
        {
            aVariable,
            bVariable
        };
        var aTerminal = new Terminal<CharSymbol, char>('a');
        var bTerminal = new Terminal<CharSymbol, char>('b');
        var terminals = new HashSet<Terminal<CharSymbol, char>>
        {
            aTerminal,
            bTerminal
        };
        var productionRules = new Dictionary<Variable<CharSymbol, char>, IReadOnlyCollection<IReadOnlyList<IElement>>>
        {
            {
                aVariable, // A -> a | AB | bB
                new ReadOnlyCollection<IReadOnlyList<IElement>>(new []
                {
                    new List<IElement>
                    {
                        aTerminal
                    },
                    new List<IElement>
                    {
                        aVariable,
                        bVariable
                    },
                    new List<IElement>
                    {
                        bTerminal,
                        bVariable
                    }
                })
            }
        };

        // Act / Assert
        Assert.Throws<GrammarValidationException>(() =>
        {
            new RegularGrammar<Variable<CharSymbol, char>, Terminal<CharSymbol, char>>(
                variables,
                terminals,
                productionRules,
                aVariable,
                null);
        });
    }

    [Fact]
    public void ProducerDeterministicTest()
    {
        // Arrange
        var aVariable = new Variable<CharSymbol, char>('A');
        var bVariable = new Variable<CharSymbol, char>('B');
        var variables = new HashSet<Variable<CharSymbol, char>>
        {
            aVariable,
            bVariable
        };
        var aTerminal = new Terminal<CharSymbol, char>('a');
        var bTerminal = new Terminal<CharSymbol, char>('b');
        var terminals = new HashSet<Terminal<CharSymbol, char>>
        {
            aTerminal,
            bTerminal
        };
        var productionRules = new Dictionary<Variable<CharSymbol, char>, IReadOnlyCollection<IReadOnlyList<IElement>>>
        {
            {
                aVariable, // A -> a | bB
                new ReadOnlyCollection<IReadOnlyList<IElement>>(new []
                {
                    new List<IElement>
                    {
                        aTerminal
                    },
                    new List<IElement>
                    {
                        bTerminal,
                        bVariable
                    }
                })
            }
        };
        var grammar =
            new RegularGrammar<Variable<CharSymbol, char>, Terminal<CharSymbol, char>>(
                variables,
                terminals,
                productionRules,
                aVariable,
                null);

        // Act
        var producer = grammar.CreateProducer();
        var aProduction = producer(aVariable);

        // Assert
        Assert.NotEmpty(aProduction);
        var rule1 = aProduction.Take(1).Single();
        var rule1element1 = rule1[0] as Terminal<CharSymbol, char>;
        Assert.Equal<char?>('a', rule1element1?.Symbol);
        var rule2 = aProduction.Skip(1).Take(1).Single();
        var rule2element1 = rule2[0] as Terminal<CharSymbol, char>;
        Assert.Equal<char?>('b', rule2element1?.Symbol);
        var rule2element2 = rule2[1] as Variable<CharSymbol, char>;
        Assert.Equal<char?>('B', rule2element2?.Symbol);
    }
}
