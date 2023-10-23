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

        Exam IExamRepository.Post(Exam exam, int userID)
        {
            if(context.Exams != null)
            {
                if (context.Users.ToList().Where(x => x.Id == userID).Count() == 1) // van találat
                {
                    User user = context.Users.ToList().Where(x => x.Id == userID).Last();
                    if (user.role == "admin" || user.role == "teacher")
                    {
                        exam.MakerID = user.Id; 
                        context.Exams.Add(exam);
                        context.SaveChanges();
                        return exam;
                    }
                    else throw new Exception("No Access");
                }
                else throw new Exception("The function was called by an invalid user");
            }
            else throw new Exception("Entity set 'DataContext.Exams' is null.");

        }

        void IExamRepository.Delete(int examId, int userID)
        {
            if (context.Users != null)
            {
                if (context.Exams != null)
                {
                    if (context.Users.ToList().Where(x => x.Id == userID).Count()> 0) // van user találat
                    {
                        if (context.Exams.ToList().Where(x => x.Id == examId).Count() > 0) // van exam találat
                        {
                            User user = context.Users.ToList().Where(x => x.Id == userID).Last();
                            Exam exam = context.Exams.ToList().Where(x => x.Id == examId).Last();
                            if (user.role == "admin" || user.role == "teacher")
                            {
                                context.Exams.Remove(exam);
                                context.SaveChanges();
                            }
                            else throw new Exception("No Access");
                        }
                        else throw new Exception("The exam is not exist");   
                    }
                    else throw new Exception("The function was called by an invalid user");
                }
                else throw new Exception("Entity set 'DataContext.Exams' is null.");
            }
            else throw new Exception("Entity set 'DataContext.Users' is null.");
        }

        List<Exam> IExamRepository.Get()
        {
            if (context.Exams != null)
            {
                return context.Exams.ToList();
            }
            else throw new Exception("Entity set 'DataContext.Exams' is null.");
        }

        Exam IExamRepository.Get(int examId)
        {
            if (context.Exams != null)
            {
                if (context.Exams.ToList().Where(x => x.Id == examId).Count() > 0) // van exam találat
                {
                    Exam exam = context.Exams.ToList().Where(x => x.Id == examId).Last();
                    return exam;
                }
                else throw new Exception("The exam is not exist");
            }
            else throw new Exception("Entity set 'DataContext.Exams' is null.");
        }

        Exam IExamRepository.Put(Exam exam, int userID)
        {
            if (context.Exams != null)
            {
                if (context.Users.ToList().Where(x => x.Id == userID).Count() == 1) // van user találat
                {
                    User user = context.Users.ToList().Where(x => x.Id == userID).Last(); // később megnézem admin e
                    if (user.role == "admin" || user.role == "teacher")
                    {
                        context.Entry(exam).State = EntityState.Modified;
                        context.SaveChanges();
                        return exam;
                    }
                    else throw new Exception("No Access");
                }
                else throw new Exception("The function was called by an invalid user");
            }else throw new Exception("Entity set 'DataContext.Exams' is null.");
        }
    }
}
