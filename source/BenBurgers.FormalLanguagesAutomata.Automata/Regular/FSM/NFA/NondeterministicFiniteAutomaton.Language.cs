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

using BenBurgers.FormalLanguagesAutomata.Languages.Regular;
using BenBurgers.FormalLanguagesAutomata.Symbols;
using System.Collections.Concurrent;

namespace BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.NFA;

public partial class NondeterministicFiniteAutomaton<TInputSymbol, TInputSymbolValue, TState>
{
    private class LanguageDerived : ILanguageRegular<TInputSymbol, TInputSymbolValue>
    {
        private readonly NondeterministicFiniteAutomaton<TInputSymbol, TInputSymbolValue, TState> automaton;

        public LanguageDerived(NondeterministicFiniteAutomaton<TInputSymbol, TInputSymbolValue, TState> automaton)
        {
            this.automaton = automaton;
        }

        public bool Accepts<TWord>(TWord word) where TWord : IWord<TInputSymbol, TInputSymbolValue>
        {
            var cts = new CancellationTokenSource();
            var ct = cts.Token;
            return this.AcceptsAsync(word, ct).Result;
        }

        public async Task<bool> AcceptsAsync<TWord>(TWord word, CancellationToken cancellationToken)
            where TWord : IWord<TInputSymbol, TInputSymbolValue>
        {
            if (word.Symbols.Count == 0)
                return automaton.StatesFinal.Contains(automaton.StateCurrent);
            for (var i = 0; i < word.Symbols.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var symbol = word.Symbols[i];
                var statesNext = automaton.PeekNextStates(symbol);
                switch (statesNext)
                {
                    case { Count: 0 }:
                        return automaton.StatesFinal.Contains(automaton.stateCurrent);
                    case { Count: 1 }:
                        automaton.MoveNext(symbol, statesNext.First());
                        break;
                    case { Count: > 1 }:
                        {
                            var results = new ConcurrentBag<bool>();
                            Parallel.ForEach(
                                statesNext, // TODO if allow null-transitions (= create configuration option), append current state
                                new ParallelOptions { CancellationToken = cancellationToken },
                                async (s, p) =>
                                {
                                    cancellationToken.ThrowIfCancellationRequested();
                                    var a = (NondeterministicFiniteAutomaton<TInputSymbol, TInputSymbolValue, TState>)automaton.Clone();
                                    a.MoveNext(symbol, s);
                                    var accepts = await a.Language.AcceptsAsync(new Word<TInputSymbol, TInputSymbolValue>(word.Skip(i)), cancellationToken);
                                    results.Add(accepts);
                                    if (accepts)
                                        p.Break();
                                });
                            return results.Any(r => r == true);
                        }
                }
            }
            return await Task.FromResult(automaton.StatesFinal.Contains(automaton.StateCurrent));
        }
    }
}
