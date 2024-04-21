using System.Text.Json;

namespace SimpleRestExercise.Utillities;

public class FileReader<T>
{
    private static FileReader<T>? instance = null;
    private static readonly object padlock = new object();
    private static readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly string relativeFolderPath = "Data";

    public static FileReader<T>? Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new FileReader<T>();
                }

                return instance;
            }
        }
    }

    public async Task Save(string fileName, T data)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new FileNotFoundException("The specified file does not exist.");
        }

        string filePath = Path.Combine(baseDirectory, relativeFolderPath, fileName);

        await using FileStream createStream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(createStream, data);
    }

    public async Task<List<T>?> Load(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new FileNotFoundException("The specified file does not exist");
        }

        string filePath = Path.Combine(baseDirectory, relativeFolderPath, fileName);

        await using FileStream openStream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<List<T>>(openStream);
    }
}
