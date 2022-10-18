using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{  
    /// <summary>
    ///  API controller to expose the endpoints related to books
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region Private Variables
        private readonly IBookService _bookService;
        #endregion

        #region Constructor
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion

        [HttpGet("GetAll")]
        public IActionResult GetAllBooks()
        {
            List<BooksModel> booksModel = new();
            booksModel = _bookService.GetAllBooks();
            return Ok(booksModel);
        }

        /// <summary>
        /// Add a new book in the database according to the requested model
        /// </summary>
        /// <param name="booksModel"></param>
        /// <returns>response</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Invalid data encountered while processing the request</response>
        /// <response code="401">Unauthorized access</response>
        /// <response code="500">Internel server error</response>
        [ProducesResponseType(typeof(BaseResponse),200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        [ProducesResponseType(typeof(BaseResponse), 401)]
        [ProducesResponseType(typeof(BaseResponse), 500)]
        [HttpPost("AddBook")]
        [Produces("application/json")]
        public IActionResult AddBook([FromBody]BooksModel booksModel)
        {
            BaseResponse response=_bookService.AddNewBook(booksModel);
            if(response.ResponseCode==StatusCodes.Status200OK)
             return Ok(response);

            return StatusCode(response.ResponseCode,response);
        }
    }
}
