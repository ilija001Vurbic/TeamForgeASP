using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TeamForge.Model;
using TeamForge.Model.Common;

public class PlayerConverter : JsonConverter<IPlayer>
{
    public override IPlayer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<Player>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, IPlayer value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (Player)value, options);
    }
}
