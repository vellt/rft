using rft.Data;
using rft.Models;

namespace rft.Repositories.RegisterRepository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly DataContext context;

        public RegisterRepository(DataContext context)
        {
            this.context = context;
        }

        Task IRegisterRepository.Create(Register regisztracio)
        {
            throw new NotImplementedException();
        }

        Task IRegisterRepository.Delete(int registracioId)
        {
            throw new NotImplementedException();
        }
    }
}
