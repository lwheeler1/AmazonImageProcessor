using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace AmazonDirectFulfillment
{
    public class DataAccess
    {
        public void ClearWebImagesCopyProgramTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.ConnectionString("ECOMLIVE")))
            {
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                //connection.Execute("dbo.TEMP_LOGAN_Update_LabelPrintDate @packageID", new { packageID = packageIdentifier }).ToString();
                connection.Execute("dbo.DT_IMAGE_PROCESSOR_ClearWebImagesCopyProgramTable").ToString();
            }
        }
        public void InsertIntoWebImagesCopyProgramTable(string imageFileName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.ConnectionString("ECOMLIVE")))
            {
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                //connection.Execute("dbo.TEMP_LOGAN_Update_LabelPrintDate @packageID", new { packageID = packageIdentifier }).ToString();
                connection.Execute("dbo.DT_IMAGE_PROCESSOR_InsertIntoWebImagesCopyProgramTable @imageName", new { imageName = imageFileName }).ToString();
            }
        }
        public List<string> GetMissingImagesList()
        {
            //the using statement is important becuase it CLOSES the DB connection as soon as it hits the ending curly brace
            //that means we are never leaving open connections to our DB
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.ConnectionString("ECOMLIVE")))
            {
                //using str8 SQL is bad because of SQL injection. Use stored procs instead.
                //var output = connection.Query<Person>($"SELECT CUSTNO, FirstName, LastName, EMAIL, DAYPHONE FROM DT_CUSTOMERS_VIEW WHERE LastName = '{ lastName }'").ToList();
                var output = connection.Query<string>("dbo.DT_IMAGE_PROCESSOR_GetMissingImagesList").ToList();
                return output;
            }
        }
        public List<string> GetMissingAsinsList()
        {
            //the using statement is important becuase it CLOSES the DB connection as soon as it hits the ending curly brace
            //that means we are never leaving open connections to our DB
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.ConnectionString("ECOMLIVE")))
            {
                //using str8 SQL is bad because of SQL injection. Use stored procs instead.
                //var output = connection.Query<Person>($"SELECT CUSTNO, FirstName, LastName, EMAIL, DAYPHONE FROM DT_CUSTOMERS_VIEW WHERE LastName = '{ lastName }'").ToList();
                var output = connection.Query<string>("dbo.DT_IMAGE_PROCESSOR_GetMissingAsinsList").ToList();
                return output;
            }
        }
        public List<Images> GetFinalImages()
        {
            //the using statement is important becuase it CLOSES the DB connection as soon as it hits the ending curly brace
            //that means we are never leaving open connections to our DB
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.ConnectionString("ECOMLIVE")))
            {
                //using str8 SQL is bad because of SQL injection. Use stored procs instead.
                //var output = connection.Query<Person>($"SELECT CUSTNO, FirstName, LastName, EMAIL, DAYPHONE FROM DT_CUSTOMERS_VIEW WHERE LastName = '{ lastName }'").ToList();
                var output = connection.Query<Images>("dbo.DT_IMAGE_PROCESSOR_GetFinalImages").ToList();
                return output;
            }
        }
    }
}
