
using FastMember;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlBulkCopyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProcess();
        }

        private static void RunProcess()
        {

            var csvFile = @"D:\temp\FakeNameGenerator.com_ccc0490e.csv";
            var cc = new CsvContext();

            var csvFileDescription = new CsvFileDescription()
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true                
            };
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            var people = cc.Read<Person>(csvFile, csvFileDescription).ToList();

            using (var sqlBulk = new SqlBulkCopy(Properties.Settings.Default.ConnectionString))
            {
                using (var reader = ObjectReader.Create(people))
                {
                    sqlBulk.BatchSize = 10000;
                    sqlBulk.DestinationTableName = "People";
                    sqlBulk.ColumnMappings.Add("Gender", "Gender");
                    sqlBulk.ColumnMappings.Add("NameSet", "NameSet");
                    sqlBulk.ColumnMappings.Add("StreetAddress", "StreetAddress");
                    sqlBulk.ColumnMappings.Add("City", "City");
                    sqlBulk.ColumnMappings.Add("ZipCode", "ZipCode");
                    sqlBulk.ColumnMappings.Add("EmailAddress", "EmailAddress");
                    sqlBulk.WriteToServer(reader);
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Total time:{TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds).Seconds}");

        }

    }
}

