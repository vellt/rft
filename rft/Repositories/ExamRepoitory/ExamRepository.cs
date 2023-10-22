using Microsoft.EntityFrameworkCore;
using rft.Data;
using rft.Models;

namespace rft.Repositories.ExamRepository
{
    public class ExamRepository : IExamRepository
    {
        private readonly DataContext context;

        public ExamRepository(DataContext context)
        {
            this.context = context;
        }

        async Task<Exam> IExamRepository.Create(Exam exam, User user)
        {
            context.Exams.Add(exam);
            await context.SaveChangesAsync();
            return exam;
            // throw new NotImplementedException();
        }

        Task IExamRepository.Delete(int examId, User user)
        {
            throw new NotImplementedException();
        }

        List<Exam> IExamRepository.Get()
        {
            return context.Exams.ToList();
        }

        async Task<Exam?> IExamRepository.Get(int examId)
        {
            var exam = await context.Exams.FindAsync(examId);
            return exam;
        }

        Task IExamRepository.Update(Exam exam, User user)
        {
            throw new NotImplementedException();
        }
    }
}
