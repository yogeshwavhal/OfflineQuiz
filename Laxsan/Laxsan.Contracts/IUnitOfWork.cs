
namespace Laxsan.DataAccess
{
    using System;
    using Laxsan.Contracts;
    using Laxsan.DataAccess.Repositories;

    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IQuestionRepository QuestionSet { get; }

        /// <summary>
        /// This method is will helpfull when we will use DB.
        /// We can commit the transaction by calling this method
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
