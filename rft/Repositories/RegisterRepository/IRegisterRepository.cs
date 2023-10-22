using rft.Models;

namespace rft.Repositories.RegisterRepository
{
    public interface IRegisterRepository
    {
        /// <summary>
        /// Betud a felhasználó íratkozni a megadott vizsgára
        /// </summary>
        public Task Create(Register regisztracio);
        /// <summary>
        /// letud íratkozni a felhasználó a vizsgáról
        /// </summary>
        public Task Delete(int registracioId);
    }
}
