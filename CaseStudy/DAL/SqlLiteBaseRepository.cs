using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CaseStudy.DAL
{
    
    class SqlLiteBaseRepository
    {
        //Hier maken we een constructor om een object te maken.
        public SqlLiteBaseRepository()
        {
        }

        //Dit maakt de connectie met de database en maakt de db ook aan.
        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=stockmarket.sqlite");
        }

        //Protected zorgt ervoor dat je de class in deze methode gebruiken en waar je overergt.
        protected static bool DatabaseExists()
        {
            return File.Exists(@"stockmarket.sqlite");
        }
        
        //Eerst open ik de connectie om daarin een table aan te maken. daarna sluiten we de connectie.
        protected static void CreateDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE Company
                    (Id  INTEGER PRIMARY KEY AUTOINCREMENT, Symbol   VARCHAR(10 )  )");
            }
        }
    }
}

