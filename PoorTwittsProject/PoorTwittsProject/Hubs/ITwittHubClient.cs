using System.Threading.Tasks;

namespace PoorTwittsProject.Hubs
{
    public interface ITwittHubClient
    {
        Task NewTwitt();
    }
}
