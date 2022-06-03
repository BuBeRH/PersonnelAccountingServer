using Microsoft.Data.Sqlite;
using System;
using System.Data;
using PersonnelAccountingServer.Classes.Personal;
using PersonnelAccountingServer.Classes.Response;

namespace PersonnelAccountingServer.Database
{
    public class DBConnect
    {
        private static readonly SqliteConnection connection = new("DataSource=PersonalDB.db");

        public static Jpersons GetFiltredPersons()
        {
            Jpersons jpersons = new();

            return jpersons;
        }

        public static void DeletePerson(int id)
        {
            connection.Open();

            string sqlExpression = "DELETE FROM Personal WHERE Id = " + id;

            SqliteCommand command = new(sqlExpression, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void UpdatePerson(Jperson jperson)
        {
            Person person = jperson.Person;
            connection.Open();

            string sqlExpression = "UPDATE Personal SET" +
                " Function = '" + person.Function + "'," +
                " LastName = '" + person.LastName + "'," +
                " FirstName = '" + person.FirstName + "'," +
                " ThirdName = '" + person.ThirdName + "'," +
                " Departament = '" + person.Departament + "'," +
                " DateOfBirth = '" + person.DateOfBirth + "'," +
                " Gender = '" + person.Gender + "'," +
                " UniqueDirector = '" + person.UniqueDirector + "'," +
                " UniqueLeader = '" + person.UniqueLeader + "'," +
                " UniqueControler = '" + person.UniqueControler + "'," +
                " UniqueWorker = '" + person.UniqueWorker + "'" +
                " WHERE Id = " + person.Id;

            SqliteCommand command = new(sqlExpression, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static Jpersons GetPersons()
        {
            connection.Open();
            List<Person> person = new();
            int count = 0;
            string sqlExpression = "SELECT * FROM Personal";

            SqliteCommand command = new(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())   // построчно считываем данные
                    {
                        person.Add(new Person());
                        person[count].Id = Convert.ToInt64(reader["Id"]);
                        person[count].Function = reader["Function"].ToString();
                        person[count].LastName = reader["LastName"].ToString();
                        person[count].FirstName = reader["FirstName"].ToString();
                        person[count].ThirdName = reader["ThirdName"].ToString();
                        person[count].Departament = reader["Departament"].ToString();
                        person[count].DateOfBirth = reader["DateOfBirth"].ToString();
                        person[count].Gender = reader["Gender"].ToString();
                        person[count].UniqueDirector = reader["UniqueDirector"].ToString();
                        person[count].UniqueLeader = reader["UniqueLeader"].ToString();
                        person[count].UniqueControler = reader["UniqueControler"].ToString();
                        person[count].UniqueWorker = reader["UniqueWorker"].ToString();
                        count++;
                    }
                }
            }
            connection.Close();
            return new Jpersons { Persons = person };
        }

        public static Jperson GetPerson(int id)
        {
            connection.Open();
            Person person = new();
            string sqlExpression = "SELECT * FROM Personal WHERE Id = " + id;

            SqliteCommand command = new(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())   // построчно считываем данные
                    {
                        person.Id = Convert.ToInt64(reader["Id"]);
                        person.Function = reader["Function"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.FirstName = reader["FirstName"].ToString();
                        person.ThirdName = reader["ThirdName"].ToString();
                        person.Departament = reader["Departament"].ToString();
                        person.DateOfBirth = reader["DateOfBirth"].ToString();
                        person.Gender = reader["Gender"].ToString();
                        person.UniqueDirector = reader["UniqueDirector"].ToString();
                        person.UniqueLeader = reader["UniqueLeader"].ToString();
                        person.UniqueControler = reader["UniqueControler"].ToString();
                        person.UniqueWorker = reader["UniqueWorker"].ToString();
                    }
                }
            }

            connection.Close();
            return new Jperson { Person = person };
        }

        public static void AddPerson(Jperson jperson)
        {
            Person person = jperson.Person;
            connection.Open();
            SqliteCommand command = new()
            {
                Connection = connection,
                CommandText = "INSERT INTO Personal " +
                "(Function, LastName, FirstName, ThirdName, Departament, DateOfBirth, Gender, UniqueDirector, UniqueLeader, UniqueControler, UniqueWorker) " +
                "VALUES (" +
                "'" + person.Function + "'," +
                "'" + person.LastName + "'," +
                "'" + person.FirstName + "'," +
                "'" + person.ThirdName + "'," +
                "'" + person.Departament + "'," +
                "'" + person.DateOfBirth + "'," +
                "'" + person.Gender + "'," +
                "'" + person.UniqueDirector + "'," +
                "'" + person.UniqueLeader + "'," +
                "'" + person.UniqueControler + "'," +
                "'" + person.UniqueWorker + "'" +
                ")"
            };
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void Connect()
        {
            connection.Open();

            SqliteCommand ConnectPersonal = new()
            {
                Connection = connection,
                CommandText = "CREATE TABLE IF NOT EXISTS Personal(" +
                "Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                "Function TEXT NOT NULL," +
                "LastName TEXT NOT NULL," +
                "FirstName TEXT NOT NULL," +
                "ThirdName TEXT NOT NULL," +
                "Departament TEXT NOT NULL," +
                "DateOfBirth TEXT NOT NULL," +
                "Gender TEXT NOT NULL," +
                "UniqueDirector TEXT," +
                "UniqueLeader TEXT," +
                "UniqueControler TEXT," +
                "UniqueWorker TEXT" +
                ")"
            };
            ConnectPersonal.ExecuteNonQuery();
            connection.Close();
        }
    }
}
