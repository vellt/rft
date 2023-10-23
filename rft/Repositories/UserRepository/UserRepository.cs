using rft.Data;
using rft.Models;

namespace rft.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }
        public List<User> Get()
        {
            if (context.Users != null)
            {
                return context.Users.ToList();
            }
            else throw new Exception("Entity set 'DataContext.Users' is null.");
        }
    }
}
