using rft.Models;

namespace rft.Repositories.RegisterRepository
{
    public interface IRegisterRepository
    {
        public List<Register> Get();
        /// <summary>
        /// Betud a felhasználó íratkozni a megadott vizsgára, és a vizsgát adja vissza,a mire beíratkozott
        /// </summary>
        public Exam Post(Register regisztracio);
        /// <summary>
        /// letud íratkozni a felhasználó a vizsgáról
        /// </summary>
        public void Delete(int registracioId);
    }
}
