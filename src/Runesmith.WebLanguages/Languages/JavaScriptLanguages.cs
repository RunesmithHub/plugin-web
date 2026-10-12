using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>JavaScript React and JavaScript: their files, highlighting, comments and brackets.</summary>
public sealed class JavaScriptLanguages
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Javascriptreact { get; } = new("javascriptreact", "JavaScript React")
    {
        Extensions = [".jsx"],
        ScopeName = "source.js.jsx",
        LineComment = "//",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Javascript { get; } = new("javascript", "JavaScript")
    {
        Extensions = [".js", ".es6", ".mjs", ".cjs", ".pac"],
        FileNames = ["jakefile"],
        ScopeName = "source.js",
        LineComment = "//",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition JavascriptreactGrammar { get; } = GrammarFiles.Find("source.js.jsx", "javascript/JavaScriptReact.tmLanguage.json");

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition JavascriptGrammar { get; } = GrammarFiles.Find("source.js", "javascript/JavaScript.tmLanguage.json");
}
