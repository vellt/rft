using rft.Models;

namespace rft.Repositories.RegisterRepository
{
    public interface IRegisterRepository
    {
        /// <summary>
        /// Betud a felhasználó íratkozni a megadott vizsgára
        /// </summary>
        Task Create(Register regisztracio);
        /// <summary>
        /// letud íratkozni a felhasználó a vizsgáról
        /// </summary>
        Task Delete(int registracioId);
    }
}
