using System.Composition.Hosting;
using System.Text.Json;
using Runesmith.Sdk.Languages;
using Runesmith.Sdk.Workspace;
using Runesmith.WebLanguages.Languages;
using TextMateSharp.Grammars;
using TextMateSharp.Internal.Grammars.Reader;
using TextMateSharp.Internal.Themes.Reader;
using TextMateSharp.Internal.Types;
using TextMateSharp.Registry;
using TextMateSharp.Themes;

namespace Runesmith.WebLanguages.Tests;

/// <summary>Loads the plugin's parts the way Runesmith does and checks each language and its grammar.</summary>
public sealed class LanguageTests : IDisposable
{
    private readonly CompositionHost container = new ContainerConfiguration().WithAssembly(typeof(CoffeeScriptLanguage).Assembly).CreateContainer();
    private readonly List<LanguageDefinition> languages;
    private readonly List<GrammarDefinition> grammars;

    public LanguageTests()
    {
        languages = [.. container.GetExports<LanguageDefinition>()];
        grammars = [.. container.GetExports<GrammarDefinition>()];
    }

    public void Dispose() => container.Dispose();

    [Fact]
    public void BringsItsLanguages() => Assert.Equal(
        ["coffeescript", "css", "handlebars", "html", "jade", "javascript", "javascriptreact", "less", "php", "scss", "typescript", "typescriptreact"],
        languages.Select(language => language.Id).Order(StringComparer.Ordinal));

    [Fact]
    public void EveryLanguageHasANameItsFilesAndAGrammar() => Assert.All(languages, language =>
    {
        Assert.False(string.IsNullOrWhiteSpace(language.Name));
        Assert.True(language.Extensions.Count + language.FileNames.Count > 0, language.Id);
        Assert.All(language.Extensions, extension => Assert.StartsWith(".", extension, StringComparison.Ordinal));
        Assert.Contains(grammars, grammar => grammar.ScopeName == language.ScopeName);
        Assert.NotEmpty(language.Brackets);
    });

    [Fact]
    public void BringsEachGrammarOnce()
    {
        Assert.Equal(17, grammars.Count);
        Assert.Equal(grammars.Count, grammars.Select(grammar => grammar.ScopeName).Distinct(StringComparer.Ordinal).Count());
    }

    [Fact]
    public void EveryGrammarFileIsThereAndNamesItsScope() => Assert.All(grammars, grammar =>
    {
        Assert.True(File.Exists(grammar.FilePath), grammar.FilePath);
        using var json = JsonDocument.Parse(File.ReadAllText(grammar.FilePath), new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip, AllowTrailingCommas = true });
        Assert.Equal(grammar.ScopeName, json.RootElement.GetProperty("scopeName").GetString());
    });

    [Fact]
    public void TheHighlightingEngineReadsEveryGrammar()
    {
        var registry = new Registry(new Locator(grammars));

        Assert.All(grammars, definition =>
        {
            var grammar = registry.LoadGrammar(definition.ScopeName);
            Assert.NotNull(grammar);
            Assert.NotEmpty(grammar.TokenizeLine("a = \"text\" + 1 // <b>note</b> # end", null, TimeSpan.FromSeconds(10)).Tokens);
        });
    }

    [Fact]
    public void LeavesThePackagesFolderOut() =>
        Assert.Equal(["**/node_modules"], container.GetExports<IFileExcludeContributor>().SelectMany(contributor => contributor.Globs));

    /// <summary>Finds the plugin's grammars by scope, as Runesmith does; a scope the plugin does not bring has no grammar.</summary>
    private sealed class Locator(List<GrammarDefinition> grammars) : IRegistryOptions
    {
        private const string Theme = """{ "name": "Test", "tokenColors": [ { "settings": { "foreground": "#000000", "background": "#ffffff" } } ] }""";

        public IRawGrammar GetGrammar(string scopeName)
        {
            if (grammars.Find(grammar => grammar.ScopeName == scopeName) is not { } grammar)
                return null!;

            using var reader = new StreamReader(grammar.FilePath);
            return GrammarReader.ReadGrammarSync(reader);
        }

        public ICollection<string> GetInjections(string scopeName) => null!;

        public IRawTheme GetTheme(string scopeName) => null!;

        public IRawTheme GetDefaultTheme()
        {
            using var reader = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(Theme)));
            return ThemeReader.ReadThemeSync(reader);
        }
    }
}
