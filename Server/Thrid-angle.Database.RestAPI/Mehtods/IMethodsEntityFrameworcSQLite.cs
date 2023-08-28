using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrid_angle.Database.RestAPI.DTO;

namespace Thrid_angle.Database.RestAPI.Mehtods
{
    public interface IMethodsEntityFrameworcSQLite
    {
        public void CreateDatabaseBaskets(Baskets table);
        public void CreateDatabaseBookCard(BookCard table);
        public void CreateDatabaseNewsCard(NewsCard table);
        public void CreateDatabaseQuoteCard(QuoteCard table);
        public void CreateDatabaseRequestCard(RequestCard table);
        public void CreateDatabaseUserCard(UserCard table);

        public List<Baskets> ReadDatabaseBascets();
        public List<Baskets> ReadDatabaseQuoteCard();
        public List<BookCard> ReadDatabaseBookCard();
        public List<RequestCard> ReadDatabaseRequestCard();
        public List<UserCard> ReadDatabaseUserCard();
        public List<NewsCard> ReadDatabaseNewsCard();

        public Baskets IDReadDatabaseBaskets(Guid Id);
        public BookCard IDReadDatabaseBookCard(Guid Id);
        public QuoteCard IDReadDatabaseQuoteCard(Guid Id);
        public RequestCard IDReadDatabaseRequestCard(Guid Id);
        public UserCard IDReadDatabaseUserCard(Guid Id);
        public NewsCard IDReadDatabaseNewsCard(Guid Id);

        public void UpdateDatabaseBaskets(Baskets baskets);
        public void UpdateDatabaseNewsCard(NewsCard news);
        public void UpdateDatabaseBookCard(BookCard bookCard);
        public void UpdateDatabaseOrderCard(Baskets baskets);
        public void UpdateDatabaseQuoteCard(QuoteCard quoteCard);
        public void UpdateDatabaseRequestCard(RequestCard requestCard);
        public void UpdateDatabaseUserCard(UserCard userCard);

        public void DeleteDatabaseBaskets(Guid Id);
        public void DeleteDatabaseBookCard(Guid Id);
        public void DeleteDatabaseOrderCard(Guid Id);
        public void DeleteDatabaseQuoteCard(Guid Id);
        public void DeleteDatabaseRequestCard(Guid Id);
        public void DeleteDatabaseUserCard(Guid Id);
        public void DeleteDatabaseNewsCard(Guid Id);

        public List<Baskets> UserReadDatabaseBaskets(Guid IdUser);
        public List<Baskets> UserReadDatabaseOrderCard(Guid IdUser);
        public List<RequestCard> IdUserReadDatabaseRequestCard(Guid IdUser);
        public List<RequestCard> IdBookReadDatabaseRequestCard(Guid IdBook);
        public List<UserCard> LoginUserReadDatabaseUserCard(string LoginUser, string PasswordUser);
        public Guid? CreateDatabaseBasketsStatusOrderCard(Guid IdUser);
      


    }
}
