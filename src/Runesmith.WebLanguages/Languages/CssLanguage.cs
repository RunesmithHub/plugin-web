using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>CSS: its files, highlighting, comments and brackets.</summary>
public sealed class CssLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Css { get; } = new("css", "CSS")
    {
        Extensions = [".css"],
        ScopeName = "source.css",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "braces",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition CssGrammar { get; } = GrammarFiles.Find("source.css", "css/css.tmLanguage.json");
}
