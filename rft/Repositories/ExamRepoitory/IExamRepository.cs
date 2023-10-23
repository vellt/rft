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
        public Exam Get(int examId);

        /// <summary>
        /// Elkészít egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        public Exam Post(Exam exam, int userID);
        /// <summary>
        /// Frissít egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        public Exam Put(Exam exam, int userID);
        /// <summary>
        /// Töröl egy vizsgát, amennyiben a felhasználó az admin, vagy tanár
        /// </summary>
        public void Delete(int examId, int userID);
    }
}
