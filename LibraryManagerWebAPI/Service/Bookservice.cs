using DAOLibrary;
using DAOLibrary.Model;
using System;
using System.Collections.Generic;

public class Bookservice
{
	private IDAOBook daobook;
	public Bookservice(IDAOBook daobook)
	{
		this.daobook = daobook;
	}
	public void Add(String title, int quantity, String category)
	{
		Book book = new Book(title, quantity, category);
		daobook.Add(book);
	}
	public void Update(String id)
	{
		daobook.Update(id);
	}
	public void Delete(String id)
	{
		daobook.Delete(id);
	}
	public IEnumerable<Book> FindById(string id)
	{
		return daobook.FindById(id);
	}
	public IEnumerable<Book> FindByTitle(String title)
	{
		return daobook.FindByTitle(title);
	}
	public IEnumerable<Book> FindByCategory(String category)
	{
		return daobook.FindByTitle(category);

	}


}
