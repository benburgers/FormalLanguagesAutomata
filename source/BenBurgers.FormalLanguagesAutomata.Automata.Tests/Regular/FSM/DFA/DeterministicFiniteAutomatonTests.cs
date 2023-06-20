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

using BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.DFA;
using BenBurgers.FormalLanguagesAutomata.Symbols;
using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;
using TestDFA = BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.DFA.DeterministicFiniteAutomaton<BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char.CharSymbol, char, BenBurgers.FormalLanguagesAutomata.Automata.AutomatonLabelState>;

namespace BenBurgers.FormalLanguagesAutomata.Automata.Tests.Regular.FSM.DFA;

public sealed class DeterministicFiniteAutomatonTests
{
    private static readonly CharSymbol SymbolA = new('a');
    private static readonly CharSymbol SymbolB = new('b');
    private static readonly CharSymbol SymbolC = new('c');
    private static readonly AutomatonLabelState StateStart = new("Start");
    private static readonly AutomatonLabelState StateA = new("A");
    private static readonly AutomatonLabelState StateB = new("B");
    private static readonly AutomatonLabelState StateEnd = new("End");
    private static readonly TestDFA Automaton1 =
        new(
            new DeterministicFiniteAutomatonArguments<CharSymbol, char, AutomatonLabelState>(
                new HashSet<CharSymbol> { SymbolA, SymbolB, SymbolC },
                StateStart,
                new Dictionary<AutomatonLabelState, IReadOnlyDictionary<CharSymbol, AutomatonLabelState?>>
                {
                    {
                        StateStart,
                        new Dictionary<CharSymbol, AutomatonLabelState?>
                        {
                            { SymbolA, StateA }
                        }
                    },
                    {
                        StateA,
                        new Dictionary<CharSymbol, AutomatonLabelState?>
                        {
                            { SymbolB, StateB }
                        }
                    },
                    {
                        StateB,
                        new Dictionary<CharSymbol, AutomatonLabelState?>
                        {
                            { SymbolC, StateEnd }
                        }
                    },
                    {
                        StateEnd,
                        new Dictionary<CharSymbol, AutomatonLabelState?>()
                    }
                },
                new HashSet<AutomatonLabelState> { StateEnd })
            );

    public static readonly IEnumerable<object?[]> MainTestParameters =
        new[]
        {
            new object?[]
            {
                Automaton1,
                new CharSymbol[]
                {
                    SymbolA
                },
                StateA
            },
            new object?[]
            {
                Automaton1,
                new CharSymbol[]
                {
                    SymbolA,
                    SymbolB
                },
                StateB
            }
        };

    [Theory(DisplayName = $"{nameof(DeterministicFiniteAutomaton<CharSymbol, char, AutomatonLabelState>)} Main Tests")]
    [MemberData(nameof(MainTestParameters))]
    public void MainTests(
        TestDFA automaton,
        IReadOnlyList<CharSymbol> inputs,
        AutomatonLabelState expectedState)
    {
        foreach (var input in inputs)
        {
            automaton.MoveNext(input);
        }
        Assert.Equal(expectedState, automaton.StateCurrent);
    }

    public static readonly IEnumerable<object?[]> LanguageTestParameters =
        new[]
        {
            new object?[]
            {
                Automaton1,
                new Word<CharSymbol, char>(
                    new CharSymbol[]
                    {
                        SymbolA,
                        SymbolB,
                        SymbolC
                    }),
                true
            },
            new object?[]
            {
                Automaton1,
                new Word<CharSymbol, char>(
                    new CharSymbol[]
                    {
                        SymbolA,
                        SymbolB
                    }),
                false
            },
            new object?[]
            {
                Automaton1,
                new Word<CharSymbol, char>(
                    new CharSymbol[]
                    {
                        SymbolA,
                        SymbolC
                    }),
                false
            }
        };

    [Theory(DisplayName = $"{nameof(DeterministicFiniteAutomaton<CharSymbol, char, AutomatonLabelState>)} Language Tests")]
    [MemberData(nameof(LanguageTestParameters))]
    public async Task LanguageTestsAsync(
        TestDFA automaton,
        Word<CharSymbol, char> word,
        bool acceptsExpected)
    {
        var cancellationToken = CancellationToken.None;
        var acceptsActual = await automaton.Language.AcceptsAsync(word, cancellationToken);
        Assert.Equal(acceptsExpected, acceptsActual);
    }
}
