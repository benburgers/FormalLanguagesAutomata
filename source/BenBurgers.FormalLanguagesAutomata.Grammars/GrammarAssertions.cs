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

using BenBurgers.FormalLanguagesAutomata.Grammars.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Grammars.Regular;
using BenBurgers.FormalLanguagesAutomata.Grammars.Regular.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Grammars;

/// <summary>
/// Assertions for valid grammars.
/// </summary>
internal static class GrammarAssertions
{
    /// <summary>
    /// Asserts that the specified <paramref name="variable" /> is a member of <paramref name="variables" />.
    /// </summary>
    /// <typeparam name="TVariable">
    /// The type of variable.
    /// </typeparam>
    /// <param name="variables">
    /// The set of variables that should contain <paramref name="variable" />.
    /// </param>
    /// <param name="variable">
    /// The variable of which to assert its membership of <paramref name="variables" />.
    /// </param>
    /// <param name="errorMessage">
    /// The error message to produce if the assertion fails.
    /// </param>
    /// <exception cref="GrammarValidationException">
    /// A <see cref="GrammarValidationException" /> is thrown if the <paramref name="variable" /> is not a member of <paramref name="variables" />.
    /// </exception>
    internal static void VariableMembership<TVariable>(
        IReadOnlySet<TVariable> variables,
        TVariable variable,
        string errorMessage)
        where TVariable : Variable
    {
        if (!variables.Contains(variable))
        {
            throw new GrammarValidationException(errorMessage);
        }
    }

    /// <summary>
    /// Asserts that the specified <paramref name="terminal" /> is a member of <paramref name="terminals" />.
    /// </summary>
    /// <typeparam name="TTerminal">
    /// The type of terminal.
    /// </typeparam>
    /// <param name="terminals">
    /// The set of terminals that should contain <paramref name="terminal" />.
    /// </param>
    /// <param name="terminal">
    /// The terminal for which to assert its membership of <paramref name="terminals" />.
    /// If <paramref name="terminal" /> is <c>null</c>, the assertion succeeds as it presumes the terminal is optional.
    /// </param>
    /// <param name="errorMessage">
    /// The error message to produce if the assertion fails.
    /// </param>
    /// <exception cref="GrammarValidationException">
    /// A <see cref="GrammarValidationException" /> is thrown if <paramref name="terminal" /> is not a member of <paramref name="terminals" />.
    /// </exception>
    internal static void TerminalMembership<TTerminal>(
        IReadOnlySet<TTerminal> terminals,
        TTerminal? terminal,
        string errorMessage)
        where TTerminal : Terminal
    {
        if (terminal is { } t && !terminals.Contains(t))
        {
            throw new GrammarValidationException(errorMessage);
        }
    }

    internal static void TerminalMembershipOrEmpty<TTerminal>(
        IReadOnlySet<TTerminal> terminals,
        TTerminal? emptyTerminal,
        TTerminal terminal,
        string errorMessage)
        where TTerminal : Terminal
    {
        if (terminal == emptyTerminal)
        {
            // A → ε
            return;
        }
        // A → a
        TerminalMembership(terminals, terminal, errorMessage);
    }

    internal static void RegularProduction<TVariable, TTerminal>(
        IReadOnlySet<TVariable> variables,
        IReadOnlySet<TTerminal> terminals,
        IReadOnlyList<IElement> production,
        ref Linearity linearity)
        where TVariable : Variable
        where TTerminal : Terminal
    {
        for (var i = 0; i < production.Count; i++)
        {
            switch (production[i])
            {
                case TVariable variableElement:
                    VariableMembership(variables, variableElement, ExceptionMessages.VariableIsNotAMember);
                    if (i == 0)
                    {
                        if (linearity == Linearity.Undetermined)
                        {
                            // A → Bxxxxxx
                            linearity = Linearity.LeftLinear;
                        }
                        if (linearity != Linearity.LeftLinear)
                        {
                            throw new GrammarValidationException(ExceptionMessages.ProductionIsNotRegular);
                        }
                    }
                    else if (linearity == Linearity.LeftLinear)
                    {
                        throw new GrammarValidationException(ExceptionMessages.ProductionIsNotRegular);
                    }
                    break;
                case TTerminal terminalElement:
                    TerminalMembership(terminals, terminalElement, ExceptionMessages.TerminalIsNotAMember);
                    if (i == 0)
                    {
                        if (linearity == Linearity.Undetermined)
                        {
                            // A → xxxxxxB
                            linearity = Linearity.RightLinear;
                        }
                        if (linearity != Linearity.RightLinear)
                        {
                            throw new GrammarValidationException(ExceptionMessages.ProductionIsNotRegular);
                        }
                    }
                    else if (linearity == Linearity.RightLinear)
                    {
                        throw new GrammarValidationException(ExceptionMessages.ProductionIsNotRegular);
                    }
                    break;
                default:
                    throw new GrammarValidationException(ExceptionMessages.ElementIsNotValid);
            }
        }
    }
}
