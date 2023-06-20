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

using BenBurgers.FormalLanguagesAutomata.Languages.ContextFree;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.DPDA;

public partial class DeterministicPushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
{
    private class LanguageDerived
        : ILanguageContextFree<TInputSymbol, TInputSymbolValue>
    {
        private readonly DeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> arguments;

        public LanguageDerived(DeterministicPushdownAutomatonArguments<TInputSymbol, TInputSymbolValue, TState, TStackSymbol> arguments)
        {
            this.arguments = arguments;
        }

        public bool Accepts<TWord>(TWord word) where TWord : IWord<TInputSymbol, TInputSymbolValue>
        {
            var automaton = new DeterministicPushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>(this.arguments);
            foreach (var symbol in word)
            {
                automaton.MoveNext(symbol);
            }
            return automaton.StatesFinal.Contains(automaton.StateCurrent);
        }

        public Task<bool> AcceptsAsync<TWord>(TWord word, CancellationToken cancellationToken)
            where TWord : IWord<TInputSymbol, TInputSymbolValue> =>
            Task.Run(() => this.Accepts(word), cancellationToken);
    }
}
