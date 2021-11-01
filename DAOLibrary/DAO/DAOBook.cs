using DAOLibrary.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary.DAO
{
    public class DAOBook : IDAOBook
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public DAOBook(DBConnection.DBConnection db)
        {
            con = db.Connection;
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }
        public void Add(Book book)
        {
            try
            {
                cmd.Parameters.Clear();
                String req = "insert into Book ('Title','Quantity','Category')" +
                       "        values (@Title ,@Quantity,@Category);";
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                cmd.Parameters.AddWithValue("@Category", book.Category);
                cmd.CommandText = req;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problem inserting book" + ex.Message);
            }
            finally
            {if(con.State== System.Data.ConnectionState.Open)
                con.Close();
            }
         
        }



        public void Delete(Book book)
        {
            try
            {
                cmd.Parameters.Clear();
                String req = "delete from book where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.CommandText = req;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("problem deleting book" + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public IEnumerable<Book> FindById(string id)
        {
            List<Book> books = new List<Book>();
            try
            {
                cmd.Parameters.Clear();
                String req = "select from Book where Id=@Id;";
                cmd.Parameters.AddWithValue("@Id",id);
                cmd.CommandText = req;
                con.Open();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    books.Add(
                        new Book( reader["id"].ToString(),
                        reader["Title"].ToString(),
                        Convert.ToInt32(reader["Quantity"].ToString()),
                        reader["Category"].ToString())
                        );
                }
                return books;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problem finding book" + ex.Message);
            }
            finally
            {
                reader.Close();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public IEnumerable<Book> FindAll()
        {
            List<Book> books = new List<Book>();
            try
            {
                cmd.Parameters.Clear();
                String req = "select * from Book;";
                cmd.CommandText = req;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(
                        new Book(reader["id"].ToString(),
                        reader["Title"].ToString(),
                        Convert.ToInt32(reader["Quantity"].ToString()),
                        reader["Category"].ToString())
                        );
                }
                return books;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problem retrieving book list" + ex.Message);
            }
            finally
            {
                reader.Close();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void Update(Book book)
        {
            try
            {
                cmd.Parameters.Clear();
                String req = "update Book set Title=@Title ,Quantity=@Quantity,Category=@Category where Id=@Id;";
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                cmd.Parameters.AddWithValue("@Category", book.Category);
                cmd.CommandText = req;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problem updating book" + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            List<Book> books = new List<Book>();
            try
            {
                cmd.Parameters.Clear();
                String req = "select from Book where Title=@Title";
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.CommandText = req;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(
                        new Book(reader["id"].ToString(),
                        reader["Title"].ToString(),
                        Convert.ToInt32(reader["Quantity"].ToString()),
                        reader["Category"].ToString())
                        );
                }
                return books;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problem finding book" + ex.Message);
            }
            finally
            {
                reader.Close();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public IEnumerable<Book> FindByCategory(string category)
        {
            List<Book> books = new List<Book>();
            try
            {
                cmd.Parameters.Clear();
                String req = "select from Book where Category=@Category";
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.CommandText = req;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(
                        new Book(reader["id"].ToString(),
                        reader["Title"].ToString(),
                        Convert.ToInt32(reader["Quantity"].ToString()),
                        reader["Category"].ToString())
                        );
                }
                return books;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problem finding book" + ex.Message);
            }
            finally
            {
                reader.Close();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
