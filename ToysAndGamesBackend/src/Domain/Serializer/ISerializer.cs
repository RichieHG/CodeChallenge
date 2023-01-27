using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Serializer
{
    public interface ISerializer
    {
        T Deserialize<T>(string input);
        string Serialize<T>(T input);
        byte[] SerializeToByteArray<T>(T input);
    }
}
