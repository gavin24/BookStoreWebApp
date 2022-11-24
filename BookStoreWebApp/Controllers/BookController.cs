using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;
using BookStoreWebApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreWebApp.Controllers
{
  
    [Route("api/book")]
    [ApiController]
   // [EnableCors("allowAuth")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        private IApiRequestService _apiRequestService;
        private IBookSubscriptionService _bookSubscriptionService;
        private IUserSubscriptionService _userSubscriptionService;
        public BookController(IBookService bookService, IApiRequestService apiRequestService, IBookSubscriptionService bookSubscriptionService, IUserSubscriptionService userSubscriptionService)
        {
            _bookService = bookService;
            _apiRequestService = apiRequestService;
            _bookSubscriptionService = bookSubscriptionService;
            _userSubscriptionService = userSubscriptionService;
        }
        // GET: api/<BookController>
        [Route("~/api/book/GetAllBooks")]
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {

            IEnumerable<Book> bookList;
            List<BookModel> bookModelList = new List<BookModel>();
            bookList = _bookService.GetBooks();
          
            return bookList;
        }
        [Route("~/api/book/GetAllNotSubscribedBooks")]
        [HttpGet]
        public IEnumerable<BookModel> GetAllNotSubscribedBooks()
        {
            IEnumerable<Book> bookList;
            List<BookModel> bookModelList = new List<BookModel>();
            bookList = _bookService.GetBooks();
            IEnumerable<UserSubscription> userSubcriptionList;
            var userId = getUserId();
            userSubcriptionList = _userSubscriptionService.GetUserSubscriptionsByUserId(Int64.Parse(userId));
            if(userSubcriptionList.Count() > 0)
            {
                foreach (Book book in bookList)
                {
                    bool bookCheck = false;
                    foreach (UserSubscription userSubscription in userSubcriptionList)
                    {
                        if (userSubscription.BookId == book.Id)
                        {
                            bookCheck = true;
                        }

                    }
                    if (bookCheck == false)
                    {
                        BookModel bookModel = new BookModel();
                        bookModel.Id = book.Id;
                        bookModel.Author = book.Author;
                        bookModel.PurchasePrice = String.Format("{0:0.00}", book.PurchasePrice);
                        bookModel.Description = book.Description;
                        bookModel.Category = book.Category;
                        bookModel.Name = book.Name;
                        bookModelList.Add(bookModel);
                    }


                }
            }
            else
            {
                foreach (Book book in bookList)
                {
                   
                        BookModel bookModel = new BookModel();
                        bookModel.Id = book.Id;
                        bookModel.Author = book.Author;
                        bookModel.PurchasePrice = String.Format("{0:0.00}", book.PurchasePrice);
                        bookModel.Description = book.Description;
                        bookModel.Category = book.Category;
                        bookModel.Name = book.Name;
                        bookModelList.Add(bookModel);
                    


                }
            }
           
            return bookModelList;
        }
        [Route("~/api/book/GetAllSubscribedBooksByUserId")]
        [HttpGet]
        public IEnumerable<SubscribedBookModel> GetAllSubscribedBooksByUserId()
        {
            var userId = getUserId();
            IEnumerable<Book> bookList;
            List<long> bookIdList = new List<long>();
            IEnumerable<UserSubscription> userSubcriptionList;
            userSubcriptionList = _userSubscriptionService.GetUserSubscriptionsByUserId(Int64.Parse(userId));
            foreach (UserSubscription userSubcription in userSubcriptionList)
            {
                bookIdList.Add((long)userSubcription.BookId);
            }
           
          
            List<Book> filteredBookList = new List<Book>();
            foreach(long bookId in bookIdList)
            {
               Book book =  _bookService.GetBookByID(bookId);
                filteredBookList.Add(book);
            }


            List<SubscribedBookModel> bookModelList = new List<SubscribedBookModel>();
           
         
            if (filteredBookList.Count() > 0)
            {
                foreach (Book book in filteredBookList)
                {
                    SubscribedBookModel bookModel = new SubscribedBookModel();
                    bookModel.Id = book.Id;
                    bookModel.Author = book.Author;
                    bookModel.PurchasePrice = String.Format("{0:0.00}", book.PurchasePrice);
                    bookModel.Description = book.Description;
                    bookModel.Category = book.Category;
                    bookModel.Name = book.Name;
                    bookModelList.Add(bookModel);
                }
            }
          
            return bookModelList;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [Route("~/api/book/SubscribeBook")]
        [HttpPost]
        public async Task<IActionResult> SubscribeBook([FromBody] BookModel bookModel)
        {
            var userId = getUserId();
            UserSubscription userSubscription = new UserSubscription();
            userSubscription.DateModified = DateTime.Now;
            userSubscription.DateCreated = DateTime.Now;
            userSubscription.BookId = bookModel.Id;
            userSubscription.IsSubscribed = true;
            userSubscription.UserId = Int64.Parse(userId);
            _userSubscriptionService.InsertUserSubscription(userSubscription);

            return Ok();
        }
        [Route("~/api/book/UnsubscribeBook")]
        [HttpPost]
        public async Task<IActionResult> UnsubscribeBook([FromBody] SubscribedBookModel subscribedBookModel)
        {
            var userId = getUserId();
            IEnumerable<UserSubscription> subLust = _userSubscriptionService.GetUserSubscriptionsByUserId(Int64.Parse(userId));
            UserSubscription userSubscription = subLust.Where(x => x.BookId == subscribedBookModel.Id).FirstOrDefault();
         
           
            _userSubscriptionService.DeleteUserSubscription(userSubscription.Id);

            return Ok();
        }
        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        private string getUserId()
        {
            string value = "";
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                value = identity.FindFirst("UserId").Value;

            }
            return value;
        }
        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
