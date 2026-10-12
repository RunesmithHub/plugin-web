using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>Pug: its files, highlighting, comments and brackets.</summary>
public sealed class PugLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Jade { get; } = new("jade", "Pug")
    {
        Extensions = [".pug", ".jade"],
        ScopeName = "text.pug",
        LineComment = "//-",
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition JadeGrammar { get; } = GrammarFiles.Find("text.pug", "pug/pug.tmLanguage.json");
}
