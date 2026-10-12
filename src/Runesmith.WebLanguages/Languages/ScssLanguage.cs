using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>SCSS: its files, highlighting, comments and brackets.</summary>
public sealed class ScssLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Scss { get; } = new("scss", "SCSS")
    {
        Extensions = [".scss"],
        ScopeName = "source.css.scss",
        LineComment = "//",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "braces",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition ScssGrammar { get; } = GrammarFiles.Find("source.css.scss", "scss/scss.tmLanguage.json");

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition SourceSassdocGrammar { get; } = GrammarFiles.Find("source.sassdoc", "scss/sassdoc.tmLanguage.json");
}
