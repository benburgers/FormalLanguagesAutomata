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

using BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.NFA;
using BenBurgers.FormalLanguagesAutomata.Symbols;
using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char;
using Xunit.Abstractions;
using TestNFA = BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.NFA.NondeterministicFiniteAutomaton<BenBurgers.FormalLanguagesAutomata.Symbols.Primitives.Char.CharSymbol, char, BenBurgers.FormalLanguagesAutomata.Automata.AutomatonLabelState>;

namespace BenBurgers.FormalLanguagesAutomata.Automata.Tests.Regular.FSM.NFA;

public sealed class NondeterministicFiniteAutomationTests
{
    private readonly ITestOutputHelper output;
    private static readonly CharSymbol SymbolA = new('a');
    private static readonly CharSymbol SymbolB = new('b');
    private static readonly CharSymbol SymbolC = new('c');
    private static readonly AutomatonLabelState StateStart = new("Start");
    private static readonly AutomatonLabelState StateA = new("A");
    private static readonly AutomatonLabelState StateB = new("B");
    private static readonly AutomatonLabelState StateEnd = new("End");
    private static readonly TestNFA Automaton1 =
        new(
            new NondeterministicFiniteAutomatonArguments<CharSymbol, char, AutomatonLabelState>(
                new HashSet<CharSymbol> { SymbolA, SymbolB, SymbolC },
                StateStart,
                new Dictionary<AutomatonLabelState, IReadOnlyDictionary<CharSymbol, IReadOnlySet<AutomatonLabelState>>>
                {
                    {
                        StateStart,
                        new Dictionary<CharSymbol, IReadOnlySet<AutomatonLabelState>>
                        {
                            {
                                SymbolA,
                                new HashSet<AutomatonLabelState> { StateA }
                            }
                        }
                    },
                    {
                        StateA,
                        new Dictionary<CharSymbol, IReadOnlySet<AutomatonLabelState>>
                        {
                            {
                                SymbolB,
                                new HashSet<AutomatonLabelState> { StateB, StateEnd }
                            }
                        }
                    },
                    {
                        StateB,
                        new Dictionary<CharSymbol, IReadOnlySet<AutomatonLabelState>>
                        {
                            {
                                SymbolC,
                                new HashSet<AutomatonLabelState> { StateEnd }
                            }
                        }
                    },
                    {
                        StateEnd,
                        new Dictionary<CharSymbol, IReadOnlySet<AutomatonLabelState>>()
                    }
                },
                new HashSet<AutomatonLabelState> { StateEnd }));

    public NondeterministicFiniteAutomationTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    public static readonly IEnumerable<object?[]> MainTestParameters =
        new[]
        {
            new object?[]
            {
                Automaton1,
                new (CharSymbol, AutomatonLabelState)[]
                {
                    (SymbolA, StateA),
                    (SymbolB, StateB),
                    (SymbolC, StateEnd)
                },
                StateEnd
            },
            new object?[]
            {
                Automaton1,
                new (CharSymbol, AutomatonLabelState)[]
                {
                    (SymbolA, StateA),
                    (SymbolB, StateEnd)
                },
                StateEnd
            }
        };

    [Theory(DisplayName = $"{nameof(NondeterministicFiniteAutomaton<CharSymbol, char, AutomatonLabelState>)} Main Tests")]
    [MemberData(nameof(MainTestParameters))]
    public void MainTests(
        TestNFA automaton,
        IReadOnlyList<(CharSymbol, AutomatonLabelState)> inputs,
        AutomatonLabelState expectedState)
    {
        var clone = (TestNFA)automaton.Clone();
        foreach (var (input, state) in inputs)
        {
            clone.MoveNext(input, state);
        }
        Assert.Equal(expectedState, clone.StateCurrent);
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
                true
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

    [Theory(DisplayName = $"{nameof(NondeterministicFiniteAutomaton<CharSymbol, char, AutomatonLabelState>)} Language Tests")]
    [MemberData(nameof(LanguageTestParameters))]
    public async Task LanguageTestsAsync(
        TestNFA automaton,
        Word<CharSymbol, char> word,
        bool acceptsExpected)
    {
        var clone = (TestNFA)automaton.Clone();
        output.WriteLine($"Testing {word}...");
        var cancellationTokenSource = new CancellationTokenSource(5000);
        var cancellationToken = cancellationTokenSource.Token;
        var acceptsActual = await clone.Language.AcceptsAsync(word, cancellationToken);
        Assert.Equal(acceptsExpected, acceptsActual);
    }
}
