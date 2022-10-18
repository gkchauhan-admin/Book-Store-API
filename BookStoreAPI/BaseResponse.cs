namespace BookStoreAPI
{
    public class BaseResponse
    {
        /// <summary>
        ///  Gets or sets response code of the response
        /// </summary>
        public int ResponseCode { get; set; }

        /// <summary>
        ///  Gets or sets response message of the response
        /// </summary>
        public string? ResponseMessage { get; set; }

        /// <summary>
        ///  Gets or sets response description of the response
        /// </summary>

        public string? ResponseDescription { get; set; }
    }
}
