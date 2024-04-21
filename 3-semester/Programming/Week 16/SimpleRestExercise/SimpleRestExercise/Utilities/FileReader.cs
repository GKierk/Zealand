using System.Text.Json;

namespace SimpleRestExercise.Utilities;

public class FileReader<T>
{
    private static readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly string relativeFolderPath = "Data";


    public async Task SaveAsync(string fileName, T data)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new FileNotFoundException("File name cannot be null or empty.");
        }

        string filePath = Path.Combine(baseDirectory, relativeFolderPath, fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"{filePath} does not exist");
        }

        await using FileStream createStream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(createStream, data);
    }

    public async Task<List<T>?> LoadAsync(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new FileNotFoundException("File name cannot be null or empty.");
        }

        string filePath = Path.Combine(baseDirectory, relativeFolderPath, fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"{filePath} does not exist");
        }

        await using FileStream openStream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<List<T>>(openStream);
    }
}
