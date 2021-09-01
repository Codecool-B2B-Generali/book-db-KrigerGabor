using Codecool.BookDb.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Codecool.BookDb.Manager
{
    public class BookDbManager
    {
        DbProviderFactory factory;
        private string provider;
        private string connectionString;

        public BookDbManager()
        {
            provider = ConfigurationManager.AppSettings["provider"];
            connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            factory = DbProviderFactories.GetFactory(provider);
        }

        public void AddAuthor(Author author)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO BOOKS.DBO.AUTHOR " +
                                      "(first_name, last_name, birth_date) " +
                                      "VALUES('" + author.FirstName + "', '"
                                                 + author.LastName + "', '"
                                                 + author.BirthDate.ToString("yyyyMMdd") + "');";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new KeyNotFoundException();
                }
            }
        }

        public void UpdateAuthor(Author author)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE BOOKS.DBO.AUTHOR" +
                                      " SET first_name = '" + author.FirstName + "', " +
                                            "last_name = '" + author.LastName + "', " +
                                            "birth_date = '" + author.BirthDate.ToString("yyyyMMdd") + "' " +
                                      " WHERE Id = " + author.Id + ";";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new KeyNotFoundException();
                }
            }
        }

        public Author GetAuthorById(int id)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM BOOKS.DBO.AUTHOR" +
                                      "  WHERE Id = " + id + ";";
                using DbDataReader reader = command.ExecuteReader();
                {
                    try
                    {
                        reader.Read();

                        return new Author
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["first_name"],
                            LastName = (string)reader["last_name"],
                            BirthDate = (DateTime)reader["birth_date"]
                        };
                    }
                    catch (Exception)
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
        }

        public List<Author> GetAllAuthors()
        {
            var authors = new List<Author>();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM BOOKS.DBO.AUTHOR;";
                using DbDataReader reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        authors.Add(new Author
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["first_name"],
                            LastName = (string)reader["last_name"],
                            BirthDate = (DateTime)reader["birth_date"]
                        });
                    }
                }
            }
            return authors;
        }
    }
}
