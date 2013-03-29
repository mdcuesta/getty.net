using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Getty.Responses;
using Api.Getty.Requests;

namespace Api.Getty
{
    /// <summary>
    /// Getty Images API Authorization Info
    /// </summary>
    public class AuthInfo
    {
        #region Variables
        private ConnectionMode _connectionMode = ConnectionMode.Production;
        #endregion

        #region ConnectionMode
        /// <summary>
        /// Getty Images API ConnectionMode
        /// </summary>
        public ConnectionMode ConnectionMode 
        {
            get 
            { 
                return _connectionMode; 
            }
            set 
            { 
                _connectionMode = value; 
            }
        }
        #endregion

        #region SystemId
        /// <summary>
        /// SystemId
        /// </summary>
        public string SystemId 
        { 
            get; 
            set; 
        }
        #endregion

        #region SystemPassword
        /// <summary>
        /// SystemPassword
        /// </summary>
        public string SystemPassword 
        { 
            get; 
            set; 
        }
        #endregion

        #region UserName
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName 
        { 
            get; 
            set; 
        }
        #endregion

        #region Password
        /// <summary>
        /// Password
        /// </summary>
        public string Password 
        { 
            get; 
            set; 
        }
        #endregion

        #region ToCreateSessionRequestBody
        /// <summary>
        /// Converts this(AuthInfo) into CreateSessionRequestBody
        /// </summary>
        /// <returns>CreateSessionRequestBody</returns>
        internal CreateSessionRequestBody ToCreateSessionRequestBody()
        {
            return new CreateSessionRequestBody
            {
                SystemId = SystemId,
                SystemPassword = SystemPassword,
                UserName = UserName,
                UserPassword = Password
            };
        }
        #endregion
    }
}
