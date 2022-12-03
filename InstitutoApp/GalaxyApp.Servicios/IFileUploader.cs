namespace GalaxyApp.Servicios;

public interface IFileUploader
{
    Task<string> UploadFileAsync(string? base64, string? fileName);
}