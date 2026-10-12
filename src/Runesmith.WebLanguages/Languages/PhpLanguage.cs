using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>PHP: its files, highlighting, comments and brackets.</summary>
public sealed class PhpLanguage
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Php { get; } = new("php", "PHP")
    {
        Extensions = [".php", ".php4", ".php5", ".phtml", ".ctp"],
        ScopeName = "source.php",
        LineComment = "//",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition PhpGrammar { get; } = GrammarFiles.Find("source.php", "php/php.tmLanguage.json");

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition TextHtmlPhpGrammar { get; } = GrammarFiles.Find("text.html.php", "php/html.tmLanguage.json");
}
