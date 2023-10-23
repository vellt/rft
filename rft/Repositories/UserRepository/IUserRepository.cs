using rft.Models;

namespace rft.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public List<User> Get();
    }
}
