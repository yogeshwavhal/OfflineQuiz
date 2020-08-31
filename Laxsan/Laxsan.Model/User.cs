namespace Laxsan.Model
{
    public class User
    {
        /// <summary>
        /// Gets or Sets the User id
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Check whether the user is authorized or not
        /// </summary>
        public bool IsAuthorized { get; set; }
    }
}
