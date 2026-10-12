using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>Handlebars: its files, highlighting, comments and brackets.</summary>
public sealed class HandlebarsLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Handlebars { get; } = new("handlebars", "Handlebars")
    {
        Extensions = [".handlebars", ".hbs", ".hjs"],
        ScopeName = "text.html.handlebars",
        BlockComment = ("{{!--", "--}}"),
        Brackets = [('<', '>'), ('{', '}'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition HandlebarsGrammar { get; } = GrammarFiles.Find("text.html.handlebars", "handlebars/Handlebars.tmLanguage.json");
}
