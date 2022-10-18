using BookStoreAPI.Data;
using BookStoreAPI.Models;
using System.Net;

namespace BookStoreAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookStoreContext _bookStoreContext;

        public BookService(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public List<BooksModel> GetAllBooks()
        {
            var books = _bookStoreContext.books?.Select(x => new BooksModel()
            {
                Id = x.Id,
                Title=x.Title,
                Description=x.Description,
            }).ToList();

            return books;
        }

        /// <summary>
        /// Add a new book in the database according to the requested model
        /// </summary>
        public BaseResponse AddNewBook(BooksModel bookModel)
        {
            BaseResponse response = new();
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _bookStoreContext.books?.Add(book);
            _bookStoreContext.SaveChanges();
            if (book.Id <= 0)
            {
                response.ResponseCode = (int)HttpStatusCode.BadRequest;
                response.ResponseMessage = HttpStatusCode.BadRequest.ToString();
                response.ResponseDescription = Constants.Constant.RestrictAddBook;
            }
            else { 
            response.ResponseCode = (int)HttpStatusCode.OK;
            response.ResponseMessage = HttpStatusCode.OK.ToString();
            response.ResponseDescription = Constants.Constant.SuccessfullyAdded;
            }
            return response;
        }
    }
}
