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

namespace BenBurgers.FormalLanguagesAutomata.Automata.Regular.FSM.DFA;

public partial class DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>
{
    /// <summary>
    /// The language that is accepted by the deterministic finite automaton.
    /// </summary>
    private class LanguageDerived : ILanguageRegular<TInputSymbol, TSymbolValue>
    {
        private readonly DeterministicFiniteAutomatonArguments<TInputSymbol, TSymbolValue, TState> arguments;

        public LanguageDerived(
            DeterministicFiniteAutomatonArguments<TInputSymbol, TSymbolValue, TState> arguments)
        {
            this.arguments = arguments;
        }

        public bool Accepts<TWord>(TWord word) where TWord : IWord<TInputSymbol, TSymbolValue>
        {
            var automaton =
                new DeterministicFiniteAutomaton<TInputSymbol, TSymbolValue, TState>(this.arguments);
            foreach (var symbol in word)
            {
                automaton.MoveNext(symbol);
            }
            return this.arguments.StatesFinal.Contains(automaton.StateCurrent);
        }

        public async Task<bool> AcceptsAsync<TWord>(TWord word, CancellationToken cancellationToken)
            where TWord : IWord<TInputSymbol, TSymbolValue>
        {
            return await Task.Run(() => this.Accepts(word), cancellationToken);
        }
    }
}
