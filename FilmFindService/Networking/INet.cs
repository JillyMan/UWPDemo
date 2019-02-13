using System.Threading.Tasks;

namespace FilmFindService.Networking
{
    public interface INet
    {
        Task<string> GetJson(string uri);
        Task<T> GetObject<T>(string uri);
    }
}
