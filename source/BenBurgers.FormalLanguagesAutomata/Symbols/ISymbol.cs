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

namespace BenBurgers.FormalLanguagesAutomata.Symbols;

/// <summary>
/// A symbol in a formal language.
/// </summary>
/// <typeparam name="TSymbol">
/// The type of symbol.
/// </typeparam>
/// <typeparam name="TSymbolValue">
/// The type of value for the symbol.
/// </typeparam>
public interface ISymbol<TSymbol, TSymbolValue>
    :
    ICloneable,
    IEquatable<ISymbol<TSymbol, TSymbolValue>>,
    IEquatable<TSymbolValue>
{
    /// <summary>
    /// Gets the value of the symbol.
    /// </summary>
    TSymbolValue Value { get; }
}
