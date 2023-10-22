using rft.Models;

namespace rft.Repositories.ExamRepository
{
    public interface IExamRepository
    {
        /// <summary>
        /// Kilistázza az összes vizsgát, és a vizsgákban lévő tanulókat is
        /// </summary>
        public List<Exam> Get();

        /// <summary>
        /// Kilistázza az adott vizsgát és a benne lévő tanulókat is
        /// </summary>
        public Task<Exam?> Get(int examId);

        /// <summary>
        /// Elkészít egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        public Task<Exam> Create(Exam exam, User user);
        /// <summary>
        /// Frissít egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        public Task Update(Exam exam, User user);
        /// <summary>
        /// Töröl egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        public Task Delete(int examId, User user);
    }
}
