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

        Exam IRegisterRepository.Post(Register regisztracio)
        {
            if (context.Registers != null)
            {
                if (context.Exams.ToList().Where(x => x.Id == regisztracio.ExamId).Count() > 0) // van találat
                {
                    if (context.Users.ToList().Where(x => x.Id == regisztracio.UserId).Count() > 0)
                    {
                        User user= context.Users.ToList().Where(x => x.Id == regisztracio.UserId).First(); 
                        if (user.role=="student") // ha tanuló akkor regisztrálhat egyébként nem
                        {
                            context.Registers.Add(regisztracio);
                            context.SaveChanges();
                            Exam exam = context.Exams.ToList().Where(x => x.Id == regisztracio.ExamId).Last();
                            return exam;
                        }
                        else throw new Exception("No Access");  // nincs hozzáférése az illentőnek a regisztrálásra
                    }
                    else throw new Exception("Invalid User");
                }
                else throw new Exception("invalid Exam");
            }
            else throw new Exception("Entity set 'DataContext.Registers' is null.");
        }

        void IRegisterRepository.Delete(int registracioId)
        {
            if (context.Registers.ToList().Where(x => x.Id == registracioId).Count() > 0)
            {
                Register register = context.Registers.ToList().Where(x => x.Id == registracioId).First();
                context.Registers.Remove(register);
                context.SaveChanges();
            }
            else throw new Exception("Invalid Regisztáció");
        }

        public List<Register> Get()
        {
            if (context.Registers != null)
            {
                return context.Registers.ToList();
            }
            else throw new Exception("Entity set 'DataContext.Regsiters' is null.");
        }
    }
}
