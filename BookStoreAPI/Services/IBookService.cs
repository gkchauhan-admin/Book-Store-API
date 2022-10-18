using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IBookService
    {
        public List<BooksModel> GetAllBooks();
        BaseResponse AddNewBook(BooksModel bookModel);

    }
}
