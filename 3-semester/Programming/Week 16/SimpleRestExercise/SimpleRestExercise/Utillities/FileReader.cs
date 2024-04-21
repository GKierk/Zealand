using System.Text.Json;

namespace SimpleRestExercise.Utillities;

public class FileReader<T>
{
    private static FileReader<T>? instance = null;
    private static readonly object padlock = new object();

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

    public async Task Save(string path, T data)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new FileNotFoundException("The specified file does not exist.");
        }

        await using FileStream createStream = File.Create(path);
        await JsonSerializer.SerializeAsync(createStream, data);
    }

    public async Task<List<T>?> Load(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new FileNotFoundException("The specified file does not exist");
        }

        await using FileStream openStream = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<List<T>>(openStream);
    }
}
