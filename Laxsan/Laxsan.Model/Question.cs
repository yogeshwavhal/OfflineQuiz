

namespace Laxsan.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;

    public class Question : IEquatable<Question>
    {
        //It should be of type Guid when we work with DB 
        //For now I kept it as string
        public string Id { get; set; }

        /// <summary>
        /// Gets the question's actual content
        /// </summary>
        public string Content { get; set; }

        public IEnumerable<string> Choices { get; set; }

        /// <summary>
        /// Answer of the question. Only for answer validation purpose
        /// </summary>
        public string Answer { get; set; }

        #region Public Methods
        public bool Equals(Question other)
        {
            if (other == null)
                return false;

            return this.Id.Equals(other.Id);
        }
        #endregion
    }
}
