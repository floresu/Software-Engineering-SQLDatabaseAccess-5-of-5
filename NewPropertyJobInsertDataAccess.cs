using AXT.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXT.SQLDBDataAccess
{
    public class NewPropertyJobInsertDataAccess : DBAccess
    {
        public NewPropertyJobInsertDataAccess(string connectionString) : base(connectionString) { }

        // A function that inserts a User into the database.
        public void InsertNewPropertyJobInsert(NewPropertyJobInsertModel newNewPropertyJobInsert)
        {
            // Declare a new variable. Variable name is ‘sSQL’. Datatype is ‘string’.
            string sSQL = "";

            // Define the value for the ‘sSQL’ string variable.
            // Notice that this text is a SQL Query.
            sSQL += " INSERT INTO [NewPropertyJobInsert] ";

            // More columns will need to be added, depending on how many columns you have in your User table.
            // In this line, you need ALL the columns from your User table.

            // The word ‘Password’ is in brackets because it is a reserved word in SQL. 
            // We are hijacking that word and using it for our own purposes, so we need to put it in brackets.
            // Normally, SQL would try to interpret the word 'Password' differently than how we're using it.

            sSQL += " (AssignJobNumber, InsertPropertyName, InsertPropertyAddress, InsertPropertyCity, InsertPropertyState, InsertPropertyZIp, InsertPropertyTownship, InsertPropertyCounty, InsertPropertyPIN)";
            sSQL += " Values ";
            // The ‘@’ sign is a SQL Variable. It is connected to a SqlParameter (below).
            // This line needs to exactly match the list of columns in the User table.
            sSQL += " (@AssignJobNumber, @InsertPropertyName, @InsertPropertyAddress, @InsertPropertyCity, @InsertPropertyState, @InsertPropertyZIp, @InsertPropertyTownship, @InsertPropertyCounty, @InsertPropertyPIN) ";

            // Declare a new variable. Variable name is ‘sqlcomm’. Datatype is ‘SqlCommand’.
            SqlCommand sqlcomm = new SqlCommand();
            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            // This SqlParameter constructor takes two arguments as input values.
            // Argument One: SQL Variable Name
            // Argument Two: Variable Value
            // The SqlParameter handles the declaration of the actual SQL Parameter in the T-SQL.
            SqlParameter sqlparam = new SqlParameter("AssignJobNumber", newNewPropertyJobInsert.AssignJobNumber);
            sqlcomm.Parameters.Add(sqlparam);

            // Notice that there is one ‘SqlParameter’ variable for each variable used in the SQL Query
            // More SqlParameter variables will need to be added for additional SQL variables.
            sqlparam = new SqlParameter("InsertPropertyName", newNewPropertyJobInsert.InsertPropertyName);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("InsertPropertyAddress", newNewPropertyJobInsert.InsertPropertyAddress);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("InsertPropertyCity", newNewPropertyJobInsert.InsertPropertyCity);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("InsertPropertyState", newNewPropertyJobInsert.InsertPropertyState);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("InsertPropertyZIP", newNewPropertyJobInsert.InsertPropertyZIP);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("InsertPropertyTownship", newNewPropertyJobInsert.InsertPropertyTownship);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("InsertPropertyCounty", newNewPropertyJobInsert.InsertPropertyCounty);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("InsertPropertyPIN", newNewPropertyJobInsert.InsertPropertyPIN);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        } 

        public int InsertNewPropertyModel()
        {
            throw new NotImplementedException();
        }
    }
}
