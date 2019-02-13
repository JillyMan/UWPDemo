using System.Threading.Tasks;

namespace FilmsDataAccessLayer.Networking
{
    public interface INet
    {
        Task<string> GetJson(string uri);
        Task<T> GetObject<T>(string uri);
    }
}
