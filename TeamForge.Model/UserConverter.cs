using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TeamForge.Model;
using TeamForge.Model.Common;

public class UserConverter : JsonConverter<IUser>
{
    public override IUser Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<User>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, IUser value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (User)value, options);
    }
}