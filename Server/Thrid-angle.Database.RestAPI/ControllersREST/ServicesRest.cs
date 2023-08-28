using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Thrid_angle.Database.RestAPI.DTO;
using Thrid_angle.Database.RestAPI.Mehtods;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.DependencyInjection;


namespace Thrid_angle.Database.RestAPI.ControllersREST
{
   
    [Route("[controller]/[action]/")]
    [ApiController]
    public class ServicesRest :  ControllerBase, IControllers
    {
        
        MethodsEntityFrameworcSQLite methodsEntityFrameworcSQLite;
       static  HelperMethodsDatabase helperMethodsDatabase = new HelperMethodsDatabase();

        //IServiceCollection Services;

        public ServicesRest(IServiceProvider _services)
        {

            methodsEntityFrameworcSQLite = (MethodsEntityFrameworcSQLite) _services.GetService<IMethodsEntityFrameworcSQLite>();

             methodsEntityFrameworcSQLite = new MethodsEntityFrameworcSQLite();
            



        }

        //CreateDatabaseBaskets/{IdUser}/{IdBook}/{QuantityBooks}/{PricePerBook}  - Метод создания записи корзины (добавление в корзину) ***
        [HttpGet("{IdUser}/{IdBook}/{QuantityBooks}/{PricePerBook}")]
        public void CreateDatabaseBaskets([FromRoute] Guid IdUser, [FromRoute] Guid IdBook, [FromRoute] int QuantityBooks, [FromRoute] int PricePerBook )
        {
           


                        Baskets _baskets = new Baskets();

            

            _baskets.IdUser = IdUser;
            _baskets.IdBook = IdBook;
            _baskets.StatusOrderCard = "basket"; 
            _baskets.NumberOrderCard = helperMethodsDatabase.BasketNewGuidOrderCard(IdUser, false);
            _baskets.NumberCard = helperMethodsDatabase.BasketNewNumberCard(IdUser, false);
            _baskets.QuantityBooks = QuantityBooks;
            _baskets.PricePerBook = PricePerBook;
            _baskets.DateCreationBasket = DateTime.Now;
            _baskets.DateUbdateBasket = DateTime.Now;


            methodsEntityFrameworcSQLite.CreateDatabaseBaskets(_baskets);




    }   //ServicesRest/CreateDatabaseBookCard/{NameBook}/{AuthorBook}/{PhotoBook}/{VendorCodeBook}/{GenreBook}/{DescriptionBook}/{PriceBook}
        [HttpGet("{NameBook}/{AuthorBook}/{PhotoBook}/{VendorCodeBook}/{GenreBook}/{DescriptionBook}/{PriceBook}")]
        public void CreateDatabaseBookCard([FromRoute] string NameBook, [FromRoute] string AuthorBook, [FromRoute] int PhotoBook, [FromRoute] string VendorCodeBook, [FromRoute] string GenreBook, [FromRoute] string DescriptionBook, [FromRoute] decimal PriceBook)
        {

            BookCard bookCard = new BookCard();

            bookCard.NameBook = NameBook;
            bookCard.AuthorBook = AuthorBook;
            bookCard.PhotoBook = PhotoBook;
            bookCard.VendorCodeBook = VendorCodeBook;
            bookCard.RecieptDateBook = DateTime.Now;
            bookCard.GenreBook = GenreBook;
            bookCard.DescriptionBook = DescriptionBook;
            bookCard.PriceBook = PriceBook;
            bookCard.DateCreationBook = DateTime.Now;
            bookCard.DateUpdateBook = DateTime.Now;

            methodsEntityFrameworcSQLite.CreateDatabaseBookCard(bookCard);






        }

        //ServicesRest/CreateDatabaseOrderCard{OrderCardBooksList}/{StatusOrderCard}/{IdUsers}/ - метод удален
       

        //ServicesRest/CreateDatabaseQuoteCard/{QuoteTitle}/{QuoteText}/{QuoteAutor}
        [HttpGet("{QuoteTitle}/{QuoteText}/{QuoteAutor}/{IsActive}")]
        public void CreateDatabaseQuoteCard([FromRoute] string QuoteTitle, [FromRoute] string QuoteText, [FromRoute] string QuoteAutor, [FromRoute] bool IsActive)
        {

           QuoteCard quoteCard = new QuoteCard();

            quoteCard.QuoteTitle = QuoteTitle;
            quoteCard.QuoteText = QuoteText;
            quoteCard.QuoteAutor = QuoteAutor;
            quoteCard.IsActive = IsActive;
            quoteCard.DateCreationQuote = DateTime.Now;
            quoteCard.DateUpdateQuote = DateTime.Now;


            methodsEntityFrameworcSQLite.CreateDatabaseQuoteCard(quoteCard);


        }


        //ServicesRest/CreateDatabaseRequestCard/{CommentTextCard}/{NumberStars}/{IdUser}/{IdBook}
        [HttpGet("{CommentTextCard}/{NumberStars}/{IdUser}/{IdBook}")]
        public void CreateDatabaseRequestCard([FromRoute] string CommentTextCard, [FromRoute] int NumberStars, [FromRoute] Guid IdUser, [FromRoute] Guid IdBook)
        {

            RequestCard requestCard = new RequestCard();

            requestCard.CommentTextCard = CommentTextCard;
            requestCard.NumberStars = NumberStars;
            requestCard.IdUser = IdUser;
            requestCard.IdBook = IdBook;
            requestCard.DateRequestCreation = DateTime.Now;
            requestCard.DateRequestUpdation = DateTime.Now;


            methodsEntityFrameworcSQLite.CreateDatabaseRequestCard(requestCard);


        }


        //ServicesRest/CreateDatabaseUserCard/{UserName}/{SurnameUser}/{RoleUser}/{FloorUser}/{AgeUser}/{AddressUser}/{TelephoneUser}/{EmailUser}/{LoginUser}/{PasswordUser}
        [HttpGet("{UserName}/{SurnameUser}/{RoleUser}/{FloorUser}/{AgeUser}/{AddressUser}/{TelephoneUser}/{EmailUser}/{LoginUser}/{PasswordUser}")]
        public void CreateDatabaseUserCard([FromRoute] string UserName, [FromRoute] string SurnameUser, [FromRoute] string RoleUser, [FromRoute] string FloorUser, [FromRoute] int AgeUser, [FromRoute] string AddressUser, [FromRoute] string TelephoneUser, [FromRoute] string EmailUser, [FromRoute] string LoginUser, [FromRoute] string PasswordUser)
        {

            UserCard userCard = new UserCard();

            userCard.UserName = UserName;
            userCard.SurnameUser = SurnameUser;
            userCard.RoleUser = RoleUser;
            userCard.FloorUser = FloorUser;
            userCard.AgeUser = AgeUser;
            userCard.AddressUser = AddressUser;
            userCard.TelephoneUser = TelephoneUser;
            userCard.EmailUser = EmailUser;
            userCard.LoginUser = LoginUser;
            userCard.PasswordUser = PasswordUser;
            userCard.DateCreationUser = DateTime.Now;   
            userCard.UpdateDateUser = DateTime.Now;

            methodsEntityFrameworcSQLite.CreateDatabaseUserCard(userCard);




        }

        [HttpGet("{HeadlineNews}/{ContentNews}/{NewsText}/{PhotoNumber}")]
        public void CreateDatabaseNewsCard([FromRoute] string HeadlineNews, [FromRoute] string ContentNews, [FromRoute] string NewsText, [FromRoute] int? PhotoNumber=0)
        {
            NewsCard newsCard = new NewsCard();

            newsCard.HeadlineNews = HeadlineNews;
            newsCard.ContentNews = ContentNews;
            newsCard.NewsText = NewsText;
            newsCard.PhotoNumber = PhotoNumber;
            newsCard.CreationDate = DateTime.Now;
            newsCard.UpdateDate = DateTime.Now;

            methodsEntityFrameworcSQLite.CreateDatabaseNewsCard(newsCard);

           



        }









        //ServicesRest/IDReadDatabaseBookCard/{IdBook}
        [HttpGet("{IdBook}")]
        public BookCard IDReadDatabaseBookCard([FromRoute] Guid IdBook)
        {
            BookCard bookCard = methodsEntityFrameworcSQLite.IDReadDatabaseBookCard(IdBook);
            return bookCard;

        }

       

        //ServicesRest/IDReadDatabaseQuoteCard/{IdQuote}
        [HttpGet("{IdQuote}")]
        public QuoteCard IDReadDatabaseQuoteCard([FromRoute] Guid IdQuote)
        {
            QuoteCard quoteCard = methodsEntityFrameworcSQLite.IDReadDatabaseQuoteCard(IdQuote);
            return quoteCard;

        }
        //ServicesRest/IDReadDatabaseRequestCard/{IdRequestCard}
        [HttpGet("{IdRequestCard}")]
        public RequestCard IDReadDatabaseRequestCard([FromRoute] Guid IdRequestCard)
        {
            RequestCard requestCard = methodsEntityFrameworcSQLite.IDReadDatabaseRequestCard(IdRequestCard);
            return requestCard;

        }
        //ServicesRest/IDReadDatabaseUserCard/{IdUser}
        [HttpGet("{IdUser}")]
        public UserCard IDReadDatabaseUserCard([FromRoute] Guid IdUser)
        {
            UserCard userCard = methodsEntityFrameworcSQLite.IDReadDatabaseUserCard(IdUser);
            return userCard;

        }

        [HttpGet("{IdNewsCard}")]
        public NewsCard IDReadDatabaseNewsCard([FromRoute] Guid IdNewsCard)
        {

            NewsCard newsCard = methodsEntityFrameworcSQLite.IDReadDatabaseNewsCard(IdNewsCard);
            return newsCard;


        }




        //ServicesRest/UpdateDatabaseBaskets/{IdBasket}/{QuantityBooks}/{PricePerBook}
        [HttpGet("{IdBasket}/{QuantityBooks}/{PricePerBook}")]
        public void UpdateDatabaseBaskets([FromRoute] Guid IdBasket, [FromRoute] int QuantityBooks, [FromRoute] int PricePerBook)
        {
            Baskets baskets = new Baskets();

            baskets.IdBasket = IdBasket;
            baskets.QuantityBooks = QuantityBooks;
            baskets.PricePerBook = PricePerBook;
            baskets.DateUbdateBasket = DateTime.Now;
            methodsEntityFrameworcSQLite.UpdateDatabaseBaskets(baskets);

           

        }



        //ServicesRest/UpdateDatabaseBookCard/{IdBook}/{NameBook}/{AuthorBook}/{PhotoBook}/{VendorCodeBook}/{GenreBook}/{DescriptionBook}/{PriceBook}
        [HttpGet("{IdBook}/{NameBook}/{AuthorBook}/{PhotoBook}/{VendorCodeBook}/{GenreBook}/{DescriptionBook}/{PriceBook}")]
       public void UpdateDatabaseBookCard([FromRoute] Guid IdBook, [FromRoute] string NameBook, [FromRoute] string AuthorBook, [FromRoute] int PhotoBook, [FromRoute] string VendorCodeBook,  [FromRoute] string GenreBook, [FromRoute] string DescriptionBook, [FromRoute] decimal PriceBook)
       {
           BookCard bookCard = new BookCard();
            bookCard.IdBook = IdBook;
            bookCard.NameBook = NameBook;
            bookCard.AuthorBook = AuthorBook;
            bookCard.PhotoBook = PhotoBook;
            bookCard.VendorCodeBook = VendorCodeBook;
            bookCard.RecieptDateBook = DateTime.Now;
            bookCard.GenreBook = GenreBook;
            bookCard.DescriptionBook = DescriptionBook;
            bookCard.PriceBook = PriceBook;
            bookCard.DateUpdateBook = DateTime.Now;

            methodsEntityFrameworcSQLite.UpdateDatabaseBookCard(bookCard);

           
       }
        //ServicesRest/UpdateDatabaseOrderCard/{NumberOrderCard}/{StatusOrderCard}  - обновляет в таблице корзины статуз заказа по номеру заказа NumberOrderCard при этом статус заказа может быть и basket    ****
        [HttpGet("{NumberOrderCard}/{StatusOrderCard}")]
       public void UpdateDatabaseOrderCard([FromRoute] Guid NumberOrderCard, [FromRoute] string StatusOrderCard)
       {

           Baskets orderCard = new Baskets();

            orderCard.NumberOrderCard = NumberOrderCard;
            orderCard.StatusOrderCard = StatusOrderCard;
            orderCard.DateUbdateBasket = DateTime.Now        ;
            

            methodsEntityFrameworcSQLite.UpdateDatabaseOrderCard(orderCard);
           
     
       }

        //ServicesRest/UpdateDatabaseQuoteCard/{IdQuote}/{QuoteTitle}/{QuoteText}/{QuoteAutor}
        [HttpGet("{IdQuote}/{QuoteTitle}/{QuoteText}/{QuoteAutor}/{IsActive}")]
       public void UpdateDatabaseQuoteCard([FromRoute] Guid IdQuote, [FromRoute] string QuoteTitle, [FromRoute] string QuoteText, [FromRoute] string QuoteAutor, [FromRoute] bool IsActive)
       {
           QuoteCard quoteCard = new QuoteCard();

            quoteCard.IdQuote = IdQuote;
            quoteCard.QuoteTitle = QuoteTitle;
            quoteCard.QuoteText = QuoteText;
            quoteCard.QuoteAutor = QuoteAutor;
            quoteCard.IsActive = IsActive;
            quoteCard.DateUpdateQuote = DateTime.Now;   

            methodsEntityFrameworcSQLite.UpdateDatabaseQuoteCard(quoteCard);

           
     
       }

        //ServicesRest/UpdateDatabaseRequestCard/{IdRequestCard}/{CommentTextCard}/{NumberStars}
        [HttpGet("{IdRequestCard}/{CommentTextCard}/{NumberStars}")]
       public void UpdateDatabaseRequestCard([FromRoute] Guid IdRequestCard, [FromRoute] string CommentTextCard, [FromRoute] int NumberStars)
       {
           RequestCard requestCard = new RequestCard();

            requestCard.IdRequestCard = IdRequestCard;
            requestCard.CommentTextCard = CommentTextCard;
            requestCard.NumberStars = NumberStars;
            requestCard.DateRequestUpdation = DateTime.Now;

            methodsEntityFrameworcSQLite.UpdateDatabaseRequestCard(requestCard);

           
       }
        //ServicesRest/UpdateDatabaseUserCard/{IdUser}/{UserName}/{SurnameUser}/{RoleUser}/{FloorUser}/{AgeUser}/{AddressUser}/{TelephoneUser}/{EmailUser}/{LoginUser}/{PasswordUser}
        [HttpGet("{IdUser}/{UserName}/{SurnameUser}/{RoleUser}/{FloorUser}/{AgeUser}/{AddressUser}/{TelephoneUser}/{EmailUser}/{LoginUser}/{PasswordUser}")]
       public void UpdateDatabaseUserCard([FromRoute] Guid IdUser, [FromRoute] string UserName, [FromRoute] string SurnameUser, [FromRoute] string RoleUser, [FromRoute] string FloorUser, [FromRoute] int AgeUser, [FromRoute] string AddressUser, [FromRoute] string TelephoneUser, [FromRoute] string EmailUser, [FromRoute] string LoginUser, [FromRoute] string PasswordUser)
       {
           UserCard userCard = new UserCard();

            userCard.IdUser = IdUser;
            userCard.UserName = UserName;
            userCard.SurnameUser = SurnameUser;
            userCard.RoleUser = RoleUser;
            userCard.FloorUser = FloorUser;
            userCard.AgeUser = AgeUser;
            userCard.AddressUser = AddressUser;
            userCard.TelephoneUser = TelephoneUser;
            userCard.EmailUser = EmailUser;
            userCard.LoginUser = LoginUser;
            userCard.PasswordUser = PasswordUser;
            userCard.UpdateDateUser = DateTime.Now; 

            methodsEntityFrameworcSQLite.UpdateDatabaseUserCard(userCard);
           
          
       }

        [HttpGet("{HeadlineNews}/{ContentNews}/{NewsText}/{PhotoNumber}")]
        public void UpdateDatabaseNewsCard([FromRoute] string HeadlineNews, [FromRoute] string ContentNews, [FromRoute] string NewsText, [FromRoute] int? PhotoNumber=0 )
        {
            NewsCard newsCard = new NewsCard();

            newsCard.HeadlineNews = HeadlineNews;
             newsCard.ContentNews = ContentNews;
             newsCard.NewsText = ContentNews;
            newsCard.PhotoNumber = PhotoNumber;
            newsCard.CreationDate = DateTime.Now;
             newsCard.UpdateDate = DateTime.Now;

            methodsEntityFrameworcSQLite.UpdateDatabaseNewsCard(newsCard);


    }




        //ServicesRest/DeleteDatabaseBaskets/{IdBasket} -  удаляет из таблици корзины записи отмечены в поле StatusOrderCard - как basket ***
        [HttpGet("{IdBasket}")]
       public void DeleteDatabaseBaskets([FromRoute] Guid IdBasket)
       {
           
            methodsEntityFrameworcSQLite.DeleteDatabaseBaskets(IdBasket);
          
     
       }
        //ServicesRest/DeleteDatabaseBookCard/{IdBook}
        [HttpGet("{IdBook}")]
       public void DeleteDatabaseBookCard([FromRoute] Guid IdBook)
       {
           
            methodsEntityFrameworcSQLite.DeleteDatabaseBookCard(IdBook);
           
       }
        //ServicesRest/DeleteDatabaseOrderCard/{NumberOrderCard}  - удаляет из таблици корзины записи заказа отмечены в поле StatusOrderCard - как order  *****
        [HttpGet("{NumberOrderCard}")]
       public void DeleteDatabaseOrderCard([FromRoute] Guid NumberOrderCard)
       {
           
            methodsEntityFrameworcSQLite.DeleteDatabaseOrderCard(NumberOrderCard);
           
     
       }
        //ServicesRest/DeleteDatabaseQuoteCard/{IdQuote}
        [HttpGet("{IdQuote}")]
        public void DeleteDatabaseQuoteCard([FromRoute] Guid IdQuote)
        {
            methodsEntityFrameworcSQLite.DeleteDatabaseQuoteCard(IdQuote);
        }


        //ServicesRest/DeleteDatabaseRequestCard/{IdRequestCard}
        [HttpGet("{IdRequestCard}")]
       public void DeleteDatabaseRequestCard([FromRoute] Guid IdRequestCard) 
       {
            methodsEntityFrameworcSQLite.DeleteDatabaseRequestCard(IdRequestCard);

     
     
       }
        //ServicesRest/DeleteDatabaseUserCard/{IdUser}
        [HttpGet("{IdUser}")]
       public   void DeleteDatabaseUserCard([FromRoute] Guid IdUser)
       {

            methodsEntityFrameworcSQLite.DeleteDatabaseUserCard(IdUser);
          
        }

        [HttpGet("{IdNewsCard}")]
        public void DeleteDatabaseNewsCard(Guid IdNewsCard)
        {
            methodsEntityFrameworcSQLite.DeleteDatabaseNewsCard(IdNewsCard);



        }




        // UserReadDatabaseBaskets/{IdUser} - читате содержание корзины по IdUser  и полю StatusOrderCard  со значением basket ****
        [HttpGet("{IdUser}")]
        public IEnumerable<Baskets> UserReadDatabaseBaskets([FromRoute] Guid IdUser)
        {

            List<Baskets> t = methodsEntityFrameworcSQLite.UserReadDatabaseBaskets(IdUser);

            foreach (Baskets m in t) { yield return m;  }

            
            

        }

        //ReadDatabaseBookCard - читает весь список книг (парметры не нужны)
        [HttpGet()]
        public IEnumerable<BookCard> ReadDatabaseBookCard()
        {
            List<BookCard> t = methodsEntityFrameworcSQLite.ReadDatabaseBookCard();

            foreach (BookCard m in t) { yield return m; }



        }

        //UserReadDatabaseOrderCard/{IdUser}  - читатет карточку заказа по IdUser пользователя заказы находятся в таблице корзина отмечены в поле StatusOrderCard - как order ***
        [HttpGet("{IdUser}")]
        public IEnumerable<Baskets> UserReadDatabaseOrderCard([FromRoute] Guid IdUser)

        {

            List<Baskets> t = methodsEntityFrameworcSQLite.UserReadDatabaseOrderCard(IdUser);

            foreach (Baskets m in t) { yield return m; }



        }

        //IdUserReadDatabaseRequestCard/{IdUser} - читатет карточку запроса по IdUser 
        [HttpGet("{IdUser}")]
        public IEnumerable<RequestCard> IdUserReadDatabaseRequestCard([FromRoute] Guid IdUser) 
        {

            List<RequestCard> t = methodsEntityFrameworcSQLite.IdUserReadDatabaseRequestCard(IdUser);

            foreach (RequestCard m in t) { yield return m; }



        }

        //IdBookReadDatabaseRequestCard/{IdBook}  - читатет карточку запроса по IdBook
        [HttpGet("{IdBook}")]
        public IEnumerable<RequestCard> IdBookReadDatabaseRequestCard([FromRoute] Guid IdBook)
        {

            List<RequestCard> t = methodsEntityFrameworcSQLite.IdBookReadDatabaseRequestCard(IdBook);

            foreach (RequestCard m in t) { yield return m; }


        }

        //LoginUserReadDatabaseUserCard/{LoginUser}/{PasswordUser} - Читатет карточку пользователя по Логину и Паролю User
        [HttpGet("{LoginUser}/{PasswordUser}")]
        public IEnumerable<UserCard> LoginUserReadDatabaseUserCard([FromRoute] string LoginUser, [FromRoute] string PasswordUser) 
        {

            List<UserCard> t = methodsEntityFrameworcSQLite.LoginUserReadDatabaseUserCard(LoginUser, PasswordUser);

            foreach (UserCard m in t) { yield return m; }

        }

        //CreateDatabaseBasketsStatusOrderCard/{IdUser} - изменяет статус из корзины (basket) на статус заказа (order) ***
        [HttpGet("{IdUser}")]
        public void CreateDatabaseBasketsStatusOrderCard(Guid IdUser)
        {

            methodsEntityFrameworcSQLite.CreateDatabaseBasketsStatusOrderCard(IdUser);

            helperMethodsDatabase.BasketNewGuidOrderCard(IdUser, true);
            helperMethodsDatabase.BasketNewNumberCard(IdUser, true);


        }




        [HttpGet()]
        public IEnumerable<Baskets> ReadDatabaseBascets() { List<Baskets> baskets = methodsEntityFrameworcSQLite.ReadDatabaseBascets(); foreach (Baskets baskets1 in baskets) { yield return baskets1; }; }
        [HttpGet()]
        public IEnumerable<Baskets> ReadDatabaseQuoteCard() { List<Baskets> _quoteCard = methodsEntityFrameworcSQLite.ReadDatabaseQuoteCard(); foreach (Baskets _quoteCard1 in _quoteCard) { yield return _quoteCard1; }; }
        [HttpGet()]
        public IEnumerable<RequestCard> ReadDatabaseRequestCard() { List<RequestCard> _requestCard = methodsEntityFrameworcSQLite.ReadDatabaseRequestCard(); foreach (RequestCard _requestCard1 in _requestCard) { yield return _requestCard1; }; }
        [HttpGet()]
        public IEnumerable<UserCard> ReadDatabaseUserCard() { List<UserCard> _userCard = methodsEntityFrameworcSQLite.ReadDatabaseUserCard(); foreach (UserCard _userCard1 in _userCard) { yield return _userCard1; }; }
        [HttpGet()]
        public IEnumerable<NewsCard> ReadDatabaseNewsCard() { List<NewsCard> _newsCard = methodsEntityFrameworcSQLite.ReadDatabaseNewsCard(); foreach (NewsCard _newsCard1 in _newsCard) { yield return _newsCard1; }; }



        [HttpGet("{Genre}")]
        public void CreateDatabaseGenreCards([FromRoute]  String Genre) { methodsEntityFrameworcSQLite.CreateDatabaseGenreCards(new GenreCards { Genre = Genre }); }

        [HttpGet("{Author}")]
        public void CreateDatabaseAuthorsCard([FromRoute] string Author) { methodsEntityFrameworcSQLite.CreateDatabaseAuthorsCard(new AuthorsCard { Author = Author }); }

        [HttpGet()]
        public IEnumerable<GenreCards> ReadDatabaseGenreCards() { List<GenreCards> _genreCard = methodsEntityFrameworcSQLite.ReadDatabaseGenreCards(); foreach (GenreCards _newsCard1 in _genreCard) { yield return _newsCard1; } }

        [HttpGet()]
        public IEnumerable<AuthorsCard> ReadDatabaseAuthorsCard() { List<AuthorsCard> _authorsCard = methodsEntityFrameworcSQLite.ReadDatabaseAuthorsCard(); foreach (AuthorsCard _authorsCard1 in _authorsCard) { yield return _authorsCard1; } }

        [HttpGet("{Id}")]
        public GenreCards IDReadDatabaseGenreCards([FromRoute] Guid Id) { GenreCards t = methodsEntityFrameworcSQLite.IDReadDatabaseGenreCards(Id); return t; }

        [HttpGet("{Id}")]
        public AuthorsCard IDReadDatabaseAuthorsCard([FromRoute] Guid Id) { AuthorsCard t = methodsEntityFrameworcSQLite.IDReadDatabaseAuthorsCard(Id); return t; }

        [HttpGet("{IdGenreCard}/{Genre}")]
        public void UpdateDatabaseGenreCards([FromRoute] Guid IdGenreCard, [FromRoute] String Genre) { methodsEntityFrameworcSQLite.UpdateDatabaseGenreCards(new GenreCards() { IdGenreCard = IdGenreCard, Genre = Genre });  }

        [HttpGet("{IdAuthor}/{Author}")]
        public void UpdateDatabaseAuthorsCard([FromRoute] Guid IdAuthor, [FromRoute] string Author ) { methodsEntityFrameworcSQLite.UpdateDatabaseAuthorsCard(new AuthorsCard() { IdAuthor = IdAuthor, Author = Author }); }


        [HttpGet("{Id}")]
        public void DeleteDatabaseGenreCards([FromRoute] Guid Id) { methodsEntityFrameworcSQLite.DeleteDatabaseGenreCards(Id); }

        [HttpGet("{Id}")]
        public void DeleteDatabaseAuthorsCard([FromRoute] Guid Id) { methodsEntityFrameworcSQLite.DeleteDatabaseAuthorsCard(Id); }










    }
}
