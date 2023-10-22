using rft.Models;

namespace rft.Repositories.ExamRepository
{
    public interface IExamRepository
    {
        /// <summary>
        /// Kilistázza az összes vizsgát, és a vizsgákban lévő tanulókat is
        /// </summary>
        Task<IEnumerable<Exam>> Get();

        /// <summary>
        /// Kilistázza az adott vizsgát és a benne lévő tanulókat is
        /// </summary>
        Task<Exam> Get(int examId);

        /// <summary>
        /// Elkészít egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        Task Create(Exam book, User user);
        /// <summary>
        /// Frissít egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        Task Update(Exam book, User user);
        /// <summary>
        /// Töröl egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        Task Delete(int examId, User user);
    }
}
