using Zio;

namespace SoftTouch.Assets.FileSystems;

public interface ICompositeAssetFileSystem<FileSystem,Mesh,Image,Material> : IFileSystem
{

    public static abstract FileSystem Create(IFileSystem parent, UPath assetPath);

    public Mesh? GetMesh(UPath path);
    public Material? GetMaterial(UPath path);
    public Image? GetImage(UPath path);
}

public abstract class CompositeAssetFileSystem<Mesh,Image,Material> : IFileSystem
{
    public abstract string[] Extensions {get;}

    public IFileSystem Parent {get; init;}
    public UPath FilePath {get; init;}

    public CompositeAssetFileSystem(IFileSystem parent, UPath filePath)
    {
        FilePath = filePath;
        Parent = parent;
    }

    public abstract Mesh? GetMesh(UPath path);
    public abstract Material? GetMaterial(UPath path);
    public abstract Image? GetImage(UPath path);

    public void CreateDirectory(UPath path)
    {
        throw new NotImplementedException();
    }

    public bool DirectoryExists(UPath path)
    {
        throw new NotImplementedException();
    }

    public void MoveDirectory(UPath srcPath, UPath destPath)
    {
        throw new NotImplementedException();
    }

    public void DeleteDirectory(UPath path, bool isRecursive)
    {
        throw new NotImplementedException();
    }

    public void CopyFile(UPath srcPath, UPath destPath, bool overwrite)
    {
        throw new NotImplementedException();
    }

    public void ReplaceFile(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
    {
        throw new NotImplementedException();
    }

    public long GetFileLength(UPath path)
    {
        throw new NotImplementedException();
    }

    public bool FileExists(UPath path)
    {
        throw new NotImplementedException();
    }

    public void MoveFile(UPath srcPath, UPath destPath)
    {
        throw new NotImplementedException();
    }

    public void DeleteFile(UPath path)
    {
        throw new NotImplementedException();
    }

    public Stream OpenFile(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
    {
        throw new NotImplementedException();
    }

    public FileAttributes GetAttributes(UPath path)
    {
        throw new NotImplementedException();
    }

    public void SetAttributes(UPath path, FileAttributes attributes)
    {
        throw new NotImplementedException();
    }

    public DateTime GetCreationTime(UPath path)
    {
        throw new NotImplementedException();
    }

    public void SetCreationTime(UPath path, DateTime time)
    {
        throw new NotImplementedException();
    }

    public DateTime GetLastAccessTime(UPath path)
    {
        throw new NotImplementedException();
    }

    public void SetLastAccessTime(UPath path, DateTime time)
    {
        throw new NotImplementedException();
    }

    public DateTime GetLastWriteTime(UPath path)
    {
        throw new NotImplementedException();
    }

    public void SetLastWriteTime(UPath path, DateTime time)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UPath> EnumeratePaths(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FileSystemItem> EnumerateItems(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate = null)
    {
        throw new NotImplementedException();
    }

    public bool CanWatch(UPath path)
    {
        throw new NotImplementedException();
    }

    public IFileSystemWatcher Watch(UPath path)
    {
        throw new NotImplementedException();
    }

    public string ConvertPathToInternal(UPath path)
    {
        throw new NotImplementedException();
    }

    public UPath ConvertPathFromInternal(string systemPath)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
