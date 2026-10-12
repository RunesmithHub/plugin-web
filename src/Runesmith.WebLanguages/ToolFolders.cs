using System.Composition;
using Runesmith.Sdk.Workspace;

namespace Runesmith.WebLanguages;

/// <summary>Leaves the folder npm installs packages into out of the Explorer, Quick Open and search.</summary>
[Export(typeof(IFileExcludeContributor))]
public sealed class ToolFolders : IFileExcludeContributor
{
    public IEnumerable<string> Globs => ["**/node_modules"];
}
