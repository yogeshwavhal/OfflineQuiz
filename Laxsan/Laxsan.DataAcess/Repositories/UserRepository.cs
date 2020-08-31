namespace Laxsan.DataAccess.Repositories
{
    using Laxsan.Model;
    using System.Collections.Generic;
    using System.Linq;

    public class UserRepository : IUserRepository
    {
        private readonly List<User> users;
        public UserRepository()
        {
            users = new List<User>() 
            { new User {UserName = "admin", Password = "admin"} };
        }
        public User Add(User entity)
        {
            users.Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<User> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User entity)
        {
            users?.Remove(entity);
        }

        public void DeleteRange(IEnumerable<User> entities)
        {
            throw new System.NotImplementedException();
        }

        public User Get(string userName)
        {
            return users.FirstOrDefault(user => user.UserName == userName);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }
    }
}
