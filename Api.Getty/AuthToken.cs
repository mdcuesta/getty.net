using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty
{
    /// <summary>
    /// Represents API live token
    /// </summary>
    [Serializable]
    public class AuthToken
    {
        private DateTime _dateRenewed = DateTime.Now;

        /// <summary>
        /// Token String
        /// </summary>
        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// Secure Token String
        /// </summary>
        public string SecureToken
        {
            get;
            set;
        }

        /// <summary>
        /// Token Duration in minutes before expiration
        /// </summary>
        public int TokenDurationMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// Estimated Date and Time of Token Renewal
        /// </summary>
        public DateTime DateRenewed 
        {
            get
            {
                return _dateRenewed;
            }
            internal set
            {
                _dateRenewed = value;
            }
        }

        /// <summary>
        /// Determines if the token is already expired
        /// </summary>
        public bool IsExpired
        {
            get 
            {
                DateTime tokenLife = DateRenewed.AddMinutes(TokenDurationMinutes);
                return tokenLife.CompareTo(DateTime.Now) >= 0;                 
            }
        }
    }
}
