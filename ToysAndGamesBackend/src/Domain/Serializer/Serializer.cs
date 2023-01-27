using System.Text;
using System.Text.Json;

namespace Domain.Serializer
{
    public class Serializer : ISerializer
    {
        private readonly Encoding _encoding = new UTF8Encoding(false);

        public Serializer()
        {
        }
        public T Deserialize<T>(string input)
        {
            return JsonSerializer.Deserialize<T>(input) ?? throw new InvalidOperationException();
        }

        public string Serialize<T>(T input)
        {
            return JsonSerializer.Serialize(input);
        }

        public byte[] SerializeToByteArray<T>(T input)
        {
            return Encoding.UTF8.GetBytes(Serialize<T>(input));
        }
    }
}
