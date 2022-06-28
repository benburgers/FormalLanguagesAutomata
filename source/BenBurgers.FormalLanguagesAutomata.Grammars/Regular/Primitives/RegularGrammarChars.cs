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
using BenBurgers.FormalLanguagesAutomata.Symbols.Primitives;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Regular.Primitives;

/// <summary>
/// A regular grammar of characters.
/// </summary>
public class RegularGrammarChars
    : RegularGrammar<CharVariable, CharTerminal>
{
    /// <summary>
    /// Initializes a new instance of <see cref="RegularGrammarChars" />.
    /// </summary>
    /// <param name="variables">
    /// The set of variables in this regular grammar.
    /// </param>
    /// <param name="terminals">
    /// The set of terminals in this regular grammar.
    /// </param>
    /// <param name="productionRules">
    /// The production rules in this regular grammar.
    /// </param>
    /// <param name="startVariable">
    /// The start variable in this regular grammar.
    /// </param>
    /// <param name="emptyTerminal">
    /// The empty terminal in this regular grammar.
    /// </param>
    public RegularGrammarChars(
        IReadOnlySet<CharVariable> variables,
        IReadOnlySet<CharTerminal> terminals,
        IReadOnlyDictionary<CharVariable, IReadOnlyCollection<IReadOnlyList<IElement>>> productionRules,
        CharVariable startVariable,
        CharTerminal? emptyTerminal)
        : base(variables, terminals, productionRules, startVariable, emptyTerminal)
    {
    }
}
