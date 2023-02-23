using CookieCore.Services.Abstractions;

namespace CookieCore.Services.Extensions;

/// <summary>
///     An extension <see cref="class" /> which provides wrapper functions for <see cref="IFile" />
/// </summary>
public static class FileExtensions
{
    /// <summary>
    ///     Reads an <see cref="IFile" />'s into a <see cref="byte" /> buffer and returns it
    /// </summary>
    /// <param name="file">The <see cref="IFile" /> to be read</param>
    /// <returns>The <paramref name="file" />'s contents as <see cref="byte" />s</returns>
    public static async Task<byte[]?> ReadAllBytes(this IFile file)
    {
        var stream = await file.OpenStreamForReadAsync();

        if (stream == null) return await Task.FromResult<byte[]?>(null);

        var fileProperties = await file.GetPropertiesAsync();
        var buffer = new byte[fileProperties.Size];

        using (stream)
        {
            stream.Read(buffer, 0, buffer.Length);
        }

        return buffer;
    }
}