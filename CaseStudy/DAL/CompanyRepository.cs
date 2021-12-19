using CaseStudy.Models;
using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.DAL
{
    class CompanyRepository : SqlLiteBaseRepository
    {
        //Hier maken we de repository. Als de database niet bestaat maken we een nieuwe aan.
        public CompanyRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }

        //Dit is de methode die we gebruiken om een symbool toe te voegen in onze database. Hier maken we gebruik van Dapper.
        public int InsertCompany(favoritestock favoritestock)
        {
            
            string sql = "INSERT INTO Company (Symbol) Values (@Symbol);";
            
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, favoritestock);
            }
        }

        //Dit is het methode die we gebruiken om een symbool te verwijderen. 
        public int DeleteCompany(string symbol)
        {
            string sql = "DELETE FROM Company WHERE Symbol = @Symbol;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, new { Symbol = symbol });
            }
        }

        //Deze methode gebruiken we om later al onze symbolen in de db. Te laten zien op het scherm.
        public IEnumerable<favoritestock> GetCompanies()
        {
            string sql = "SELECT * FROM Company;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<favoritestock>(sql);
            }
        }

     
    }
}
