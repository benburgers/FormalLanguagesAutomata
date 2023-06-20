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


/* Unmerged change from project 'BenBurgers.FormalLanguagesAutomata.Automata (net7.0)'
Before:
using BenBurgers.FormalLanguagesAutomata.Languages.ContextFree;
After:
using BenBurgers;
using BenBurgers.FormalLanguagesAutomata;
using BenBurgers.FormalLanguagesAutomata.Automata;
using BenBurgers.FormalLanguagesAutomata.Automata.ContextFree;
using BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA;
using BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA;
using BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA.Stack;
using BenBurgers.FormalLanguagesAutomata.Languages.ContextFree;
*/
using BenBurgers.FormalLanguagesAutomata.Languages.ContextFree;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Automata.ContextFree.PDA;

/// <summary>
/// A pushdown automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of input symbols in the pushdown automaton.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of value of an input symbol in the pushdown automaton.</typeparam>
/// <typeparam name="TState">The type of state in the pushdown automaton.</typeparam>
/// <typeparam name="TStackSymbol">The type of stack symbol in the pushdown automaton.</typeparam>
public abstract class PushdownAutomaton<TInputSymbol, TInputSymbolValue, TState, TStackSymbol>
    : IAutomatonContextFree<TInputSymbol, TInputSymbolValue, TState>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
    where TState : AutomatonState
{
    /// <inheritdoc />
    public abstract ILanguageContextFree<TInputSymbol, TInputSymbolValue> Language { get; }

    /// <inheritdoc />
    public abstract IReadOnlySet<TInputSymbol> AlphabetIn { get; }

    /// <inheritdoc />
    public abstract IReadOnlySet<TState> States { get; }

    /// <inheritdoc />
    public abstract TState StateCurrent { get; }

    /// <inheritdoc />
    public abstract IReadOnlySet<TState> StatesFinal { get; }

    /// <inheritdoc />
    public abstract object Clone();
}

/// <summary>
/// A pushdown automaton.
/// </summary>
/// <typeparam name="TInputSymbol">The type of input symbols.</typeparam>
/// <typeparam name="TInputSymbolValue">The type of the value of an input symbol.</typeparam>
public abstract class PushdownAutomaton<TInputSymbol, TInputSymbolValue>
    : PushdownAutomaton<TInputSymbol, TInputSymbolValue, AutomatonLabelState, char>
    where TInputSymbol : ISymbol<TInputSymbol, TInputSymbolValue>
{
}
