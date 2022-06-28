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

namespace BenBurgers.FormalLanguagesAutomata.Grammars.ContextFree;

internal class ContextFreeGrammar<TVariable, TTerminal>
    : IContextFreeGrammar<TVariable, TTerminal>
    where TVariable : Variable
    where TTerminal : Terminal
{
    public ContextFreeGrammar(
        IEnumerable<TVariable> variables,
        IEnumerable<TTerminal> terminals,
        TVariable startVariable,
        TTerminal? emptyTerminal)
    {
        this.Variables = variables as IReadOnlySet<TVariable> ?? new HashSet<TVariable>(variables);
        this.Terminals = terminals as IReadOnlySet<TTerminal> ?? new HashSet<TTerminal>(terminals);
        this.StartVariable = startVariable;
        this.EmptyTerminal = emptyTerminal;
    }

    public IReadOnlySet<TVariable> Variables { get; }

    public IReadOnlySet<TTerminal> Terminals { get; }

    public TVariable StartVariable { get; }

    public TTerminal? EmptyTerminal { get; }
}
