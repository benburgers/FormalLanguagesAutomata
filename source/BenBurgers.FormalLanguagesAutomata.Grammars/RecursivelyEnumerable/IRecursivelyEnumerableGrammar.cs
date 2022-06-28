﻿/*
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

namespace BenBurgers.FormalLanguagesAutomata.Grammars.RecursivelyEnumerable;

/// <summary>
/// A recursively enumerable grammar.
/// </summary>
/// <typeparam name="TVariable">
/// The type of variable in the recursively enumerable grammar.
/// </typeparam>
/// <typeparam name="TTerminal">
/// The type of terminal in the recursively enumerable grammar.
/// </typeparam>
public interface IRecursivelyEnumerableGrammar<TVariable, TTerminal>
    : IGrammar<TVariable, TTerminal>
    where TVariable : Variable
    where TTerminal : Terminal
{
}