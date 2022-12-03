using GalaxyApp.Entidades;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GalaxyApp.Servicios;

public class FileUploader : IFileUploader
{
    private readonly IOptions<AppSettings> _options;
    private readonly ILogger<FileUploader> _logger;

    public FileUploader(IOptions<AppSettings> options, ILogger<FileUploader> logger)
    {
        _options = options;
        _logger = logger;
    }

    public async Task<string> UploadFileAsync(string? base64, string? fileName)
    {
        if (string.IsNullOrEmpty(base64) || string.IsNullOrEmpty(fileName))
            return string.Empty;

        try
        {
            var bytes = Convert.FromBase64String(base64);

            var path = Path.Combine(_options.Value.StorageConfiguration.Path, fileName);

            await File.WriteAllBytesAsync(path, bytes);

            return $"{_options.Value.StorageConfiguration.PublicUrl}{fileName}";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al subir archivo {Message}", ex.Message);
            return string.Empty;
        }
    }
}