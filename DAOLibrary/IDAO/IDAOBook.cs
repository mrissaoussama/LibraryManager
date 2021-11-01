using DAOLibrary.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DAOLibrary
{
    public interface IDAOBook
    {
        public void Add(Book book);
        public void Update(Book book);
        public void Delete(Book book);
        public IEnumerable<Book> FindAll();
        public IEnumerable<Book> FindById(String id);
        public IEnumerable<Book> FindByTitle(String title);
        public IEnumerable<Book> FindByCategory(String category);



    }
}
