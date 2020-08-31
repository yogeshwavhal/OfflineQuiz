
namespace Laxsan
{
    using Laxsan.DataAccess;
    using Laxsan.Model;
    using System.Linq; 

    public class Authenticator
    {
        #region Private Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion Private Fields

        public Authenticator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="user">user to be authenticate</param>
        /// <returns>true if the user is valid otherwise false</returns>
        public bool Authenticate(User user)
        {
            var users =  _unitOfWork.Users.GetAll();

            var usr = users.FirstOrDefault(
                us => us.UserName == user.UserName
                && us.Password == user.Password);

            if (usr != null)
            {
                return true;
            }
            return false;
        }
    }
}
