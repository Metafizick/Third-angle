using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Thrid_angle.Database.RestAPI.Database;
using System.Dynamic;
using Thrid_angle.Database.RestAPI.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace Thrid_angle.Database.RestAPI.Mehtods
{
    internal class MethodsEntityFrameworcSQLite: IMethodsEntityFrameworcSQLite
    {
        internal DatabaseContext db = new DatabaseContext();


        public void CreateDatabaseBaskets(Baskets table) { db.Add(table); db.SaveChanges();   } //***
        public void CreateDatabaseBookCard(BookCard table) { db.Add(table); db.SaveChanges();  } //***
        public void CreateDatabaseNewsCard(NewsCard table) { db.Add(table); db.SaveChanges();  } //***
        public void CreateDatabaseQuoteCard(QuoteCard table) { db.Add(table); db.SaveChanges();  } //***
        public void CreateDatabaseRequestCard(RequestCard table) { db.Add(table); db.SaveChanges();  } //***
        public void CreateDatabaseUserCard(UserCard table)  {db.Add(table); db.SaveChanges();  } //***
        public void CreateDatabaseGenreCards(GenreCards table) { db.Add(table); db.SaveChanges(); } //++
        public void CreateDatabaseAuthorsCard (AuthorsCard table) { db.Add(table); db.SaveChanges(); } //++




        public List<Baskets> ReadDatabaseBascets() { List<Baskets> t = db.DbBaskets.Where(d=>d.StatusOrderCard== "basket").ToList<Baskets>(); return t; } // чтение всех карточек карзин 
        public List<Baskets> ReadDatabaseQuoteCard() { List<Baskets> t = db.DbBaskets.Where(d => d.StatusOrderCard == "order").ToList<Baskets>(); return t; } // чтение всех карточек заказа
        public List<BookCard> ReadDatabaseBookCard() { List<BookCard> t = db.DbBookCard.ToList<BookCard>(); return t; } // чтение всех книг
        public List<RequestCard> ReadDatabaseRequestCard() { List<RequestCard> t = db.DbRequestCard.ToList<RequestCard>(); return t; } //чтение всех карточек запросов
        public List<UserCard> ReadDatabaseUserCard() { List<UserCard> t = db.DbUserCard.ToList<UserCard>(); return t; } // чтение всех карточек user
        public List<NewsCard> ReadDatabaseNewsCard() { List<NewsCard> t = db.DbNewsCard.ToList<NewsCard>(); return t; } // чтение всех новостей *****
        public List<GenreCards> ReadDatabaseGenreCards() { List<GenreCards> t = db.DbGenreCards.ToList<GenreCards>(); return t; } //++
        public List<AuthorsCard> ReadDatabaseAuthorsCard() { List<AuthorsCard> t = db.DbAuthorsCard.ToList<AuthorsCard>(); return t; } //++




        public Baskets IDReadDatabaseBaskets(Guid Id) { Baskets t = db.DbBaskets.Find(Id); return t; } // - удалить
        public BookCard IDReadDatabaseBookCard(Guid Id) { BookCard t = db.DbBookCard.Find(Id); return t; }

        public QuoteCard IDReadDatabaseQuoteCard(Guid Id) { QuoteCard t = db.DbQuoteCard.Find(Id); return t; }
        public RequestCard IDReadDatabaseRequestCard(Guid Id) { RequestCard t =  db.DbRequestCard.Find(Id); return t; }
        public UserCard IDReadDatabaseUserCard(Guid Id) { UserCard t = db.DbUserCard.Find(Id); return t; }
        public NewsCard IDReadDatabaseNewsCard(Guid Id) { NewsCard t = db.DbNewsCard.Find(Id); return t; } //****

        public GenreCards IDReadDatabaseGenreCards(Guid Id) { GenreCards t = db.DbGenreCards.Find(Id); return t; } //++
        public AuthorsCard IDReadDatabaseAuthorsCard(Guid Id) { AuthorsCard t = db.DbAuthorsCard.Find(Id); return t; } //++











        public void UpdateDatabaseBaskets(Baskets baskets) 
        {


            db.DbBaskets.Where(d => d.IdBasket == baskets.IdBasket).Where(b=> b.StatusOrderCard== "basket").ExecuteUpdate(b => b.SetProperty(t => t.QuantityBooks, baskets.QuantityBooks));
            db.DbBaskets.Where(d => d.IdBasket == baskets.IdBasket).Where(b => b.StatusOrderCard == "basket").ExecuteUpdate(b => b.SetProperty(t => t.PricePerBook, baskets.PricePerBook));
            db.DbBaskets.Where(d => d.IdBasket == baskets.IdBasket).Where(b => b.StatusOrderCard == "basket").ExecuteUpdate(b => b.SetProperty(t => t.DateUbdateBasket, baskets.DateUbdateBasket));

            db.SaveChanges();

       }



        public void UpdateDatabaseNewsCard(NewsCard news) //******
        {
            var _db = db.DbNewsCard.Find(news);
            _db.HeadlineNews = news.HeadlineNews;
            _db.ContentNews = news.ContentNews;
            _db.NewsText = news.NewsText;
            _db.PhotoNumber = news.PhotoNumber;
            _db.UpdateDate = news.UpdateDate;
            db.SaveChanges();

        }











        public void UpdateDatabaseBookCard(BookCard bookCard) 
        {

            var _db = db.DbBookCard.Find(bookCard.IdBook);
            _db.NameBook = bookCard.NameBook;
            _db.AuthorBook = bookCard.AuthorBook;
            _db.PhotoBook = bookCard.PhotoBook;
            _db.VendorCodeBook = bookCard.VendorCodeBook;
            _db.RecieptDateBook = bookCard.RecieptDateBook;
            _db.GenreBook = bookCard.GenreBook;
            _db.DescriptionBook = bookCard.DescriptionBook;
            _db.PriceBook = bookCard.PriceBook;
           // _db.DateCreationBook = bookCard.DateCreationBook;
           _db.DateUpdateBook = bookCard.DateUpdateBook;

           db.SaveChanges();

        }

        public void UpdateDatabaseOrderCard(Baskets baskets)
        {
            db.DbBaskets.Where(d => d.NumberOrderCard == baskets.NumberOrderCard).ExecuteUpdate(b => b.SetProperty(t => t.StatusOrderCard, baskets.StatusOrderCard));
            db.DbBaskets.Where(d => d.NumberOrderCard == baskets.NumberOrderCard).ExecuteUpdate(b => b.SetProperty(t => t.DateUbdateBasket, baskets.DateUbdateBasket));


           

            db.SaveChanges();


          

        }




        public void UpdateDatabaseQuoteCard(QuoteCard quoteCard) 
        {
            var _db = db.DbQuoteCard.Find(quoteCard.IdQuote);

            _db.QuoteTitle = quoteCard.QuoteTitle;
            _db.QuoteText = quoteCard.QuoteText;
            _db.QuoteAutor = quoteCard.QuoteAutor;
            _db.IsActive = quoteCard.IsActive;
           // _db.DateCreationQuote = quoteCard.DateCreationQuote;
           _db.DateUpdateQuote = quoteCard.DateUpdateQuote;
           ; db.SaveChanges(); 
        
        }

        public void UpdateDatabaseRequestCard(RequestCard requestCard)
        {

            var _db = db.DbRequestCard.Find(requestCard.IdRequestCard);
            _db.CommentTextCard = requestCard.CommentTextCard;
            _db.NumberStars = requestCard.NumberStars;
           // _db.IdUser = requestCard.IdUser;
           // _db.IdBook = requestCard.IdBook;
            //_db.DateRequestCreation = requestCard.DateRequestCreation;
            _db.DateRequestUpdation = requestCard.DateRequestUpdation;
            db.SaveChanges();
        }

        public void UpdateDatabaseUserCard(UserCard userCard)
        {
            var _db = db.DbUserCard.Find(userCard.IdUser);


            _db.UserName = userCard.UserName;
            _db.SurnameUser = userCard.SurnameUser;
            _db.RoleUser = userCard.RoleUser; 
            _db.FloorUser = userCard.FloorUser;
            _db.AgeUser = userCard.AgeUser;
            _db.AddressUser = userCard.AddressUser;
            _db.TelephoneUser = userCard.TelephoneUser;
            _db.EmailUser = userCard.EmailUser;
            _db.LoginUser = userCard.LoginUser;
            _db.PasswordUser = userCard.PasswordUser;
            //_db.DateCreationUser = userCard.DateCreationUser;
            _db.UpdateDateUser = userCard.UpdateDateUser;
             db.SaveChanges();


        }


        public void UpdateDatabaseGenreCards(GenreCards genreCards) //++
        {
            var _db = db.DbGenreCards.Find(genreCards.IdGenreCard);

            _db.Genre = genreCards.Genre;

            db.SaveChanges();

        }


        public void UpdateDatabaseAuthorsCard(AuthorsCard authorsCard) //++
        {
            var _db = db.DbAuthorsCard.Find(authorsCard.IdAuthor);

            _db.Author = authorsCard.Author;

            db.SaveChanges();

        }






        public void DeleteDatabaseBaskets(Guid Id) { db.DbBaskets.Where(d => d.IdBasket == Id&d.StatusOrderCard== "basket").ExecuteDelete(); db.SaveChanges(); }
        public void DeleteDatabaseBookCard(Guid Id) { db.DbBookCard.Where(d => d.IdBook == Id).ExecuteDelete(); db.SaveChanges(); }
        public void DeleteDatabaseOrderCard(Guid Id) { db.DbBaskets.Where(d => d.NumberOrderCard == Id).ExecuteDelete(); db.SaveChanges(); }
        public void DeleteDatabaseQuoteCard(Guid Id) { db.DbQuoteCard.Where(d => d.IdQuote == Id).ExecuteDelete(); db.SaveChanges(); }
        public void DeleteDatabaseRequestCard(Guid Id) { db.DbRequestCard.Where(d => d.IdRequestCard == Id).ExecuteDelete(); db.SaveChanges(); }
        public void DeleteDatabaseUserCard(Guid Id) { db.DbUserCard.Where(d => d.IdUser == Id).ExecuteDelete(); db.SaveChanges(); }
        public void DeleteDatabaseNewsCard(Guid Id) { db.DbNewsCard.Where(d => d.IdNewsCard == Id).ExecuteDelete(); db.SaveChanges(); }  //****
        public void DeleteDatabaseGenreCards(Guid Id) { db.DbGenreCards.Where(d => d.IdGenreCard == Id).ExecuteDelete(); db.SaveChanges(); } //++
        public void DeleteDatabaseAuthorsCard(Guid Id) { db.DbAuthorsCard.Where(d => d.IdAuthor == Id).ExecuteDelete(); db.SaveChanges(); } //++





        public List<Baskets> UserReadDatabaseBaskets(Guid IdUser) { List<Baskets> t = db.DbBaskets.Where(d => d.IdUser == IdUser && d.StatusOrderCard == "basket").ToList<Baskets>(); return t; }


        public List<Baskets> UserReadDatabaseOrderCard(Guid IdUser) { List<Baskets> t = db.DbBaskets.Where(d =>  d.IdUser == IdUser&&d.StatusOrderCard== "order").ToList<Baskets>(); return t; }


        public List<RequestCard> IdUserReadDatabaseRequestCard(Guid IdUser) { List<RequestCard> t = db.DbRequestCard.Where(d => d.IdUser == IdUser).ToList<RequestCard>(); return t; }


        public List<RequestCard> IdBookReadDatabaseRequestCard(Guid IdBook) { List<RequestCard> t = db.DbRequestCard.Where(d => d.IdBook == IdBook).ToList<RequestCard>(); return t; }


        public List<UserCard> LoginUserReadDatabaseUserCard(string LoginUser, string PasswordUser) { List<UserCard> t = db.DbUserCard.Where(d => d.LoginUser == LoginUser&&d.PasswordUser== PasswordUser).ToList<UserCard>(); return t; }


        public Guid? CreateDatabaseBasketsStatusOrderCard(Guid IdUser) //***
        {
           
                var t = db.DbBaskets.Where(d => d.StatusOrderCard == "basket"& d.IdUser== IdUser);

                t.ExecuteUpdate(setters => setters.SetProperty(b => b.StatusOrderCard, "order"));
            db.SaveChanges();

            return db.DbBaskets.Find(IdUser).NumberOrderCard;




        }




    }
}
