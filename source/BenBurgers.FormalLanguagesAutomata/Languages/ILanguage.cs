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

using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Languages;

/// <summary>
/// A formal language.
/// </summary>
/// <typeparam name="TSymbol">The type of symbol in the language.</typeparam>
/// <typeparam name="TSymbolValue">The type of value that is associated with the symbol.</typeparam>
public interface ILanguage<TSymbol, TSymbolValue>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
{
    /// <summary>
    /// Determines whether <paramref name="word" /> is accepted by the language.
    /// </summary>
    /// <typeparam name="TWord">The type of words accepted by the language.</typeparam>
    /// <param name="word">The word to check.</param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether <paramref name="word" /> is accepted by the language.
    /// </returns>
    bool Accepts<TWord>(TWord word)
        where TWord : IWord<TSymbol, TSymbolValue>;

    /// <summary>
    /// Determines whether <paramref name="word" /> is accepted by the language.
    /// </summary>
    /// <typeparam name="TWord">The type of words accepted by the language.</typeparam>
    /// <param name="word">The word to check.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>
    /// An awaitable task with a <see cref="bool" /> that indicates whether <paramref name="word" /> is accepted by the language.
    /// </returns>
    Task<bool> AcceptsAsync<TWord>(TWord word, CancellationToken cancellationToken)
        where TWord : IWord<TSymbol, TSymbolValue>;
}