

namespace Laxsan.Contracts
{
    using Laxsan.DataAccess.Repositories;
    using Laxsan.Model;
    using System.Collections.Generic;

    public interface IQuestionRepository : IRepository<Question>
    {
        //We can define more methods for
        //IQuestionRepository if IRepository is not serving our purpose
        Question GetRandom();

        bool AllQuestionDone();

        IReadOnlyDictionary<string, string> GetAnswerKey();

        int Count();

    }
}
