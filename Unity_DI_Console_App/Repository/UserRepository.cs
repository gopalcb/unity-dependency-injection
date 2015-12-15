using System.Collections.Generic;

namespace Unity_DI_Console_App.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        public List<User> GetUsers()
        {
            var ul = new List<User>
            {
                new User {UserId = 1, Name = "Gopal", Email = "gopal@bitmascot.com"},
                new User {UserId = 2, Name = "Nayan", Email = "nayan@live.com"}
            };
            return ul;
        } 
    }
    public interface IUserRepository<User>
    {
        List<User> GetUsers();
    }
}