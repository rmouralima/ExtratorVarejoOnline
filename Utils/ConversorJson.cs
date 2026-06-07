using ExtratorVarejoOnline.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExtratorVarejoOnline.Utils
{
    public static class ConversorJsonContasReceber
    {
        public static List<ContasReceber> Converter(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateTimeCustomConverter() }
            };

            return JsonSerializer.Deserialize<List<ContasReceber>>(json, options);
        }


    }

    public static class ConversorJsonContasPagar
    {
        public static List<ContasPagar> Converter(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateTimeCustomConverter() }
            };

            return JsonSerializer.Deserialize<List<ContasPagar>>(json, options);
        }


    }
    public class DateTimeCustomConverter : JsonConverter<DateTime>
    {
        private readonly string formato = "dd-MM-yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valor = reader.GetString();
            return DateTime.ParseExact(valor, formato, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(formato));
        }
    }

    public static class ConversorJsonTerceiros
    {
        public static List<Terceiro> Converter(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateTimeCustomConverter() }
            };

            return JsonSerializer.Deserialize<List<Terceiro>>(json, options);
        }


    }

    public static class ConversorJsonContasContabeis
    {
        public static List<ContasContabeis> Converter(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateTimeCustomConverter() }
            };

            return JsonSerializer.Deserialize<List<ContasContabeis>>(json, options);
        }


    }

}
