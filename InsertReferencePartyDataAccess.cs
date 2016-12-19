using AXT.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXT.SQLDBDataAccess
{
    public class InsertReferencePartyDataAccess : DBAccess
    {
        public InsertReferencePartyDataAccess(string connectionString) : base(connectionString) { }

        // A function that inserts a User into the database.
        public void InsertInsertReferenceParty(InsertReferencePartyModel newInsertReferenceParty)
        {
            // Declare a new variable. Variable name is ‘sSQL’. Datatype is ‘string’.
            string sSQL = "";

            // Define the value for the ‘sSQL’ string variable.
            // Notice that this text is a SQL Query.
            sSQL += " INSERT [Reference Party] ";

            // More columns will need to be added, depending on how many columns you have in your User table.
            // In this line, you need ALL the columns from your User table.

            // The word ‘Password’ is in brackets because it is a reserved word in SQL. 
            // We are hijacking that word and using it for our own purposes, so we need to put it in brackets.
            // Normally, SQL would try to interpret the word 'Password' differently than how we're using it.

            sSQL += " (ReferenceFirstName, LastNameReferenceLastName, ReferenceCompanyName, ReferenceAddress, ReferenceCity, ReferenceState, ReferenceZIP, ReferenceEmail, ReferencePhoneNumber, ReferenceFaxNumber ) ";
            sSQL += " Values ";
            // The ‘@’ sign is a SQL Variable. It is connected to a SqlParameter (below).
            // This line needs to exactly match the list of columns in the User table.
            sSQL += " (@ReferenceFirstName, @LastNameReferenceLastName, @ReferenceCompanyName, @ReferenceAddress, @ReferenceCity, @ReferenceState, @ReferenceZIP, @ReferenceEmail, @ReferencePhoneNumber, @ReferenceFaxNumber) ";

            // Declare a new variable. Variable name is ‘sqlcomm’. Datatype is ‘SqlCommand’.
            SqlCommand sqlcomm = new SqlCommand();
            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            // This SqlParameter constructor takes two arguments as input values.
            // Argument One: SQL Variable Name
            // Argument Two: Variable Value
            // The SqlParameter handles the declaration of the actual SQL Parameter in the T-SQL.
            SqlParameter sqlparam = new SqlParameter("FirstName", newInsertReferenceParty.ReferenceFirstName);
            sqlcomm.Parameters.Add(sqlparam);

            // Notice that there is one ‘SqlParameter’ variable for each variable used in the SQL Query
            // More SqlParameter variables will need to be added for additional SQL variables.
            sqlparam = new SqlParameter("ReferenceLastName", newInsertReferenceParty.ReferenceLastName);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferenceCompanyName", newInsertReferenceParty.ReferenceCompanyName);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferenceAddress", newInsertReferenceParty.ReferenceAddress);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferenceCity", newInsertReferenceParty.ReferenceCity);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferenceState", newInsertReferenceParty.ReferenceState);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferenceZIP", newInsertReferenceParty.ReferenceZIP);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferencEmail", newInsertReferenceParty.ReferenceEmail);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferencePhoneNumber", newInsertReferenceParty.ReferencePhoneNumber);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("ReferenceFaxNumber", newInsertReferenceParty.ReferenceFaxNumber);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }
    }
}
