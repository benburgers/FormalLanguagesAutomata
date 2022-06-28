/*
 * © 2022-2023 Ben Burgers and contributors.
 * Licensed under GNU Affero General Public License version 3.0
 */

using BenBurgers.FormalLanguagesAutomata.Grammars.Exceptions;
using BenBurgers.FormalLanguagesAutomata.Symbols;

namespace BenBurgers.FormalLanguagesAutomata.Grammars.Regular;

/// <summary>
/// A regular grammar or Type-3 grammar according to the Chomsky hierarchy of formal grammars.
/// </summary>
/// <typeparam name="TVariable">
/// The type of variables in the regular grammar.
/// </typeparam>
/// <typeparam name="TTerminal">
/// The type of terminals in the regular grammar.
/// </typeparam>
/// <remarks>
///     <para>
///         <b>Note</b>:
///     </para>
///     <para>
///         Right-regular grammars are in the format of:
///         <code>
///             A → a
///             B → bC
///             C → cD
///         </code>
///     </para>
///     <para>
///         Left-regular grammars are in the format of:
///         <code>
///             A → a
///             B → Cb
///             C → Dc
///         </code>
///     </para>
///     <para>
///         If an empty terminal is specified, the grammar is nondeterministic.
///     </para>
/// </remarks>
public interface IRegularGrammar<TVariable, TTerminal>
    : IGrammar<TVariable, TTerminal>
    where TVariable : Variable
    where TTerminal : Terminal
{
    /// <summary>
    /// Gets the linearity of the regular grammar.
    /// </summary>
    Linearity Linearity { get; }

    /// <summary>
    /// A function that implements the production rules for this grammar.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <b>Note</b>:
    ///     </para>
    ///     <para>
    ///         Right-regular grammars are in the format of:
    ///         <code>
    ///             A → a
    ///             B → bC
    ///             C → cD
    ///         </code>
    ///     </para>
    ///     <para>
    ///         Left-regular grammars are in the format of:
    ///         <code>
    ///             A → a
    ///             B → Cb
    ///             C → Dc
    ///         </code>
    ///     </para>
    ///     <para>
    ///         If an empty terminal is specified, the grammar is nondeterministic.
    ///     </para>
    /// </remarks>
    IReadOnlyDictionary<TVariable, IReadOnlyCollection<IReadOnlyList<IElement>>> ProductionRules { get; }

    /// <summary>
    /// Creates a function that takes in a variable and returns a disjunction of lists of elements that are produced by the variable.
    /// </summary>
    /// <returns>
    /// A function that takes in a variable and returns a disjunction of lists of elements that are produced by the variable.
    /// </returns>
    /// <exception cref="GrammarException">
    /// A <see cref="GrammarException" /> is thrown if preconditions for creating the function were not met.
    /// </exception>
    Func<TVariable, IReadOnlyCollection<IReadOnlyList<IElement>>> CreateProducer();
}