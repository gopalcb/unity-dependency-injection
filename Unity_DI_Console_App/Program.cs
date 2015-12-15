using System;
using Microsoft.Practices.Unity;
using Unity_DI_Console_App.Repository;

namespace Unity_DI_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IUserRepository<User>, UserRepository>();
            var usrRepo = container.Resolve<IUserRepository<User>>();
            var lst = usrRepo.GetUsers();
            foreach (var o in lst)
            {
                Console.Write(o.UserId + "   " + o.Name + "   " + o.Email);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}