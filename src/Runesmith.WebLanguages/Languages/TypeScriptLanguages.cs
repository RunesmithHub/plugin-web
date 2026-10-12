using System.Composition;
using Runesmith.Sdk.Languages;

namespace Runesmith.WebLanguages.Languages;

/// <summary>TypeScript and TypeScript React: their files, highlighting, comments and brackets.</summary>
public sealed class TypeScriptLanguages
{
    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Typescript { get; } = new("typescript", "TypeScript")
    {
        Extensions = [".ts"],
        ScopeName = "source.ts",
        LineComment = "//",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(LanguageDefinition))]
    public LanguageDefinition Typescriptreact { get; } = new("typescriptreact", "TypeScript React")
    {
        Extensions = [".tsx"],
        ScopeName = "source.tsx",
        LineComment = "//",
        BlockComment = ("/*", "*/"),
        Brackets = [('{', '}'), ('[', ']'), ('(', ')')],
        Icon = "file-code",
    };

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition TypescriptGrammar { get; } = GrammarFiles.Find("source.ts", "typescriptbasics/TypeScript.tmLanguage.json");

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition TypescriptreactGrammar { get; } = GrammarFiles.Find("source.tsx", "typescriptbasics/TypeScriptReact.tmLanguage.json");

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition DocumentationInjectionTsGrammar { get; } = GrammarFiles.Find("documentation.injection.ts", "typescriptbasics/jsdoc.ts.injection.tmLanguage.json");

    [Export(typeof(GrammarDefinition))]
    public GrammarDefinition DocumentationInjectionJsJsxGrammar { get; } = GrammarFiles.Find("documentation.injection.js.jsx", "typescriptbasics/jsdoc.js.injection.tmLanguage.json");
}
