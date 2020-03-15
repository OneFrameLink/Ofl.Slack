using Ofl.Slack.BlockKit.Blocks;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ofl.Slack.Serialization.Text.Json
{
    // TODO: Move to Ofl.Text.Json
    internal class PolymorphicReadOnlyCollectionJsonConverter<T> : JsonConverter<IReadOnlyCollection<T>>
    {
        public override IReadOnlyCollection<T> Read(
            ref Utf8JsonReader reader, 
            Type typeToConvert, 
            JsonSerializerOptions options
        )
            => throw new NotImplementedException();

        public override void Write(
            Utf8JsonWriter writer,
            IReadOnlyCollection<T> value, 
            JsonSerializerOptions options
        )
        {
            // Validate parameters.
            if (writer == null) throw new ArgumentNullException(nameof(writer));
            if (options == null) throw new ArgumentNullException(nameof(options));

            // If the value is null, write null.
            if (value == null)
            {
                // Write null and get out.
                writer.WriteNullValue();
                return;
            }

            // Write the array start.
            writer.WriteStartArray();

            // Cycle through the items.
            foreach (T item in value)
            {
                // If the item is null, write null,
                // else write the item.
                if (item is null)
                    writer.WriteNullValue();
                else
                    JsonSerializer.Serialize(writer, item, item.GetType(), options);
            }

            // Finish the array.
            writer.WriteEndArray();
        }
    }
}
