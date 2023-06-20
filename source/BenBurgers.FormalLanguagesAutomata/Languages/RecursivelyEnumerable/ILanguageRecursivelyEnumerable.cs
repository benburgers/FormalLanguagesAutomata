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

namespace BenBurgers.FormalLanguagesAutomata.Languages.RecursivelyEnumerable;

/// <summary>
/// A recursively enumerable language.
/// </summary>
/// <typeparam name="TSymbol">The type of symbols in the language.</typeparam>
/// <typeparam name="TSymbolValue">The type of value of a symbol in the language.</typeparam>
public interface ILanguageRecursivelyEnumerable<TSymbol, TSymbolValue>
    : ILanguage<TSymbol, TSymbolValue>
    where TSymbol : ISymbol<TSymbol, TSymbolValue>
{
}
