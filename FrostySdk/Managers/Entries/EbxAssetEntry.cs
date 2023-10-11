using System;
using System.Collections.Generic;
using Frosty.Sdk.Profiles;

namespace Frosty.Sdk.Managers.Entries;

public class EbxAssetEntry : AssetEntry
{
    public override string AssetType => "ebx";

    public int NameHash;
    
    /// <summary>
    /// The <see cref="Guid"/> of this <see cref="EbxAssetEntry"/>.
    /// </summary>
    public Guid Guid;
    
    /// <summary>
    /// <see cref="Guid"/>s of the <see cref="EbxAssetEntry"/>s this <see cref="EbxAssetEntry"/> depends on.
    /// </summary>
    public readonly HashSet<Guid> DependentAssets = new();

    public EbxAssetEntry(string inName, Sha1 inSha1, long inOriginalSize)
        : base(inSha1, inOriginalSize)
    {
        Name = inName;
        NameHash = Utils.Utils.HashString(inName, true);
    }
    
    public EbxAssetEntry(string inName, int inNameHash, Sha1 inSha1, long inOriginalSize)
        : base(inSha1, inOriginalSize)
    {
        Name = inName;
        NameHash = inNameHash;
    }
    
    public IEnumerable<Guid> EnumerateDependencies()
    {
        foreach (Guid guid in DependentAssets)
        {
            yield return guid;
        }
    }
}