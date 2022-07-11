namespace GA2.Application.Dto
{
    /// <summary>
    /// Login external application
    /// </summary>
    /// <date>25/11/2021</date>
    /// <author>Oscar Julian Rojas</author>
    public  class LoginExternalDto
    {
        /// <summary>
        /// User name application
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password application
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Status login application
        /// </summary>
        public bool Status { get; set; }
    }
}
