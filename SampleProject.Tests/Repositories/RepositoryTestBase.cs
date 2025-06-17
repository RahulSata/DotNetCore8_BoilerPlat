using Dapper;
using Microsoft.Data.Sqlite;
using NUnit.Framework;
using SampleProject.Common.Constants;
using SampleProject.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SampleProject.Tests.Repositories
{
    public abstract class RepositoryTestBase
    {
        protected IDbConnection Connection;
        protected AppDbContext Context;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            SQLitePCL.Batteries.Init();

            Connection = new SqliteConnection("Data Source=:memory:");
            Connection.Open();

            CreateTables(Connection);
            SeedData(Connection);
            ConvertToSQLLiteQueries();
        }

        private void ConvertToSQLLiteQueries()
        {
            var fields = typeof(SqlQueries).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var field in fields)
            {
                if (field.FieldType == typeof(string))
                {
                    var originalValue = field.GetValue(null)?.ToString();
                    if (!string.IsNullOrEmpty(originalValue))
                    {
                        var cleaned = CleanQuery(originalValue);
                        field.SetValue(null, cleaned);
                    }
                }
            }
        }

        private string CleanQuery(string query)
        {
            return query.Replace("WITH(NOLOCK)", "", StringComparison.OrdinalIgnoreCase);
        }


        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            Connection?.Dispose();
        }

        private static void CreateTables(IDbConnection connection)
        {
            connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Doctor (
                DoctorId INTEGER PRIMARY KEY,
                Name TEXT NOT NULL
            );");
        }

        private static void SeedData(IDbConnection connection)
        {
            connection.Execute("INSERT INTO Doctor (Name) VALUES (@Name);", new[]
            {
                new { Name = "Dr. Rahul" },
                new { Name = "Dr. Sata" }
            });
        }
    }
}
