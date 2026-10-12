using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>CoffeeScript: its files, highlighting, comments and brackets.</summary>
public sealed class CoffeeScriptLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Coffeescript { get; } = new("coffeescript", "CoffeeScript")
    {
        Extensions = [".coffee", ".cson", ".iced"],
        ScopeName = "source.coffee",
        LineComment = "#",
        BlockComment = ("###", "###"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition CoffeescriptGrammar { get; } = GrammarFiles.Find("source.coffee", "coffeescript/coffeescript.tmLanguage.json");
}
