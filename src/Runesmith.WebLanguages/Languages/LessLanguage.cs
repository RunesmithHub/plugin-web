using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>Less: its files, highlighting, comments and brackets.</summary>
public sealed class LessLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Less { get; } = new("less", "Less")
    {
        Extensions = [".less"],
        ScopeName = "source.css.less",
        LineComment = "//",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "braces",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition LessGrammar { get; } = GrammarFiles.Find("source.css.less", "less/less.tmLanguage.json");
}
