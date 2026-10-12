using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>HTML: its files, highlighting, comments and brackets.</summary>
public sealed class HtmlLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Html { get; } = new("html", "HTML")
    {
        Extensions = [".html", ".htm", ".shtml", ".xhtml", ".xht", ".mdoc", ".jsp", ".asp", ".aspx", ".jshtm", ".volt", ".ejs", ".rhtml"],
        ScopeName = "text.html.derivative",
        BlockComment = ("<!--", "-->"),
        Brackets = [('<', '>'), ('{', '}'), ('(', ')')],
        Icon = "code",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition TextHtmlBasicGrammar { get; } = GrammarFiles.Find("text.html.basic", "html/html.tmLanguage.json");

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition HtmlGrammar { get; } = GrammarFiles.Find("text.html.derivative", "html/html-derivative.tmLanguage.json");
}
