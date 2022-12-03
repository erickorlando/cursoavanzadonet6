namespace GalaxyApp.Entidades;

public class AppSettings
{
    public StorageConfiguration StorageConfiguration { get; set; } = default!;

}

public class StorageConfiguration
{
    public string Path { get; set; } = default!;
    public string PublicUrl { get; set; } = default!;
}