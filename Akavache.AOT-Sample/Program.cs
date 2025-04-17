// See https://aka.ms/new-console-template for more information

using System.Reactive.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Akavache;
using Akavache.Sqlite3;
using Splat;

var serializationOptions = new JsonContext().Options;

Locator.CurrentMutable.InitializeAkavache(Locator.Current); // seems to not make a difference

using var bloc = new SqlRawPersistentBlobCache("out.sqlite");

var key = "key";

var obj = new SampleObject
{
    Name = "test", Id = 1
};

// I want to use System.Text.Json
var bytes = JsonSerializer.SerializeToUtf8Bytes(obj, serializationOptions);

await bloc.Insert(key,bytes);

var resultBytes = await bloc.Get(key);
var result = JsonSerializer.Deserialize<SampleObject>(resultBytes, serializationOptions);

if (result!.Id != 1 && result.Name != "test")
{
    Console.WriteLine("ERROR");
}

Console.WriteLine("Done");


public class SampleObject
{
    public required string Name { get; set; }
    public required int Id { get; set; }
}

[JsonSerializable(typeof(SampleObject))]
public partial class JsonContext : JsonSerializerContext{}