using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets.FileSystems;

public class ResourcesFileSystem : AggregateFileSystem
{
    /// <inheritdoc />
    protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
    {
        SearchPattern.Parse(ref path, ref searchPattern);

        var entries = new SortedSet<UPath>();
        var fileSystems = new List<IFileSystem>();

        if (Fallback != null)
        {
            fileSystems.Add(Fallback);
        }

        // Query all filesystems just once
        fileSystems.AddRange(GetFileSystems().Where(x => x is not GltfFileSystem));
        var gltfFS = GetFileSystems()
                .OfType<GltfFileSystem>()
                .Where(x => path.IsInDirectory(x.SubPath, true));
        if (gltfFS.Any())
        {
            var fs = gltfFS.First();
            var gltfFSPath = new UPath(string.Join('/', path.Split().Except(fs.SubPath.Split()))).ToAbsolute();
            foreach (var item in fs.EnumeratePaths(path, searchPattern, searchOption, searchTarget))
            {
                if (entries.Contains(item)) continue;
                entries.Add(item);
            }
        }
        else
        {
            for (var i = fileSystems.Count - 1; i >= 0; i--)
            {
                var fileSystem = fileSystems[i];

                if (!fileSystem.DirectoryExists(path))
                    continue;

                foreach (var item in fileSystem.EnumeratePaths(path, searchPattern, searchOption, searchTarget))
                {
                    if (entries.Contains(item)) continue;
                    entries.Add(item);
                }
            }
        }

        // Return entries
        foreach (var entry in entries)
        {
            yield return entry;
        }
    }
}