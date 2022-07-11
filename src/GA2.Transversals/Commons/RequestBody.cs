using System.IO;
using System.Threading.Tasks;

namespace GA2.Transversals.Commons
{
    public class RequestBody
    {
        public static async Task<string> ReadRquestBodyFunction(Stream body)
        {
            return await new StreamReader(body).ReadToEndAsync();
        }
    }
}
