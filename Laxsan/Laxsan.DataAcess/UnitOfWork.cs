

namespace Laxsan.DataAccess
{
    using Laxsan.Contracts;
    using Laxsan.DataAccess.Repositories;
    using Laxsan.DataAcess.Repositories;
    using Laxsan.Model;
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        #region Public Constructors

        public UnitOfWork()
        {
            Users = new UserRepository();
            QuestionSet = new QuestionRepository();
        }

      
        #endregion Public Constructors

        #region Public Properties

        public IUserRepository Users { get; private set; }

        public IQuestionRepository QuestionSet { get; private set; }


        #endregion Public Proiperties

        #region Public Methods
        /// <summary>
        /// Completes the unit of work
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            //Use this method to save changes to DB
            return 1;
        }

        public void Dispose()
        {
            //Dispose the DB object or close the connection if we used DB to fetch user
        }
        #endregion Public Methods
    }
}
