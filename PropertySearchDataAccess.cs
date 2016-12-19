using AXT.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXT.SQLDBDataAccess
{
    public class PropertySearchDataAccess :DBAccess
    {
        public PropertySearchDataAccess(string connectionString) : base(connectionString) { }

        // A function that inserts a User into the database.
        public void InsertPropertySearch(PropertySearchModel newPropertySearch)
        {
            // Declare a new variable. Variable name is ‘sSQL’. Datatype is ‘string’.
            string sSQL = "";

            // Define the value for the ‘sSQL’ string variable.
            // Notice that this text is a SQL Query.
            sSQL += " INSERT INTO [Property Search] ";

            // More columns will need to be added, depending on how many columns you have in your User table.
            // In this line, you need ALL the columns from your User table.

            // The word ‘Password’ is in brackets because it is a reserved word in SQL. 
            // We are hijacking that word and using it for our own purposes, so we need to put it in brackets.
            // Normally, SQL would try to interpret the word 'Password' differently than how we're using it.

            sSQL += " (PropertyName, PropertyAddress, PropertyCity, PropertyState, PropertyZIP, PropertyTownship, PropertyCounty,PropertyStatus) ";
            sSQL += " Values ";
            // The ‘@’ sign is a SQL Variable. It is connected to a SqlParameter (below).
            // This line needs to exactly match the list of columns in the User table.
            sSQL += " (@PropertyName, @PropertyAddress, @PropertyCity, @PropertyState, @PropertyZIP, @PropertyTownship, @PropertyCounty, @PropertyStatus) ";

            // Declare a new variable. Variable name is ‘sqlcomm’. Datatype is ‘SqlCommand’.
            SqlCommand sqlcomm = new SqlCommand();
            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            // This SqlParameter constructor takes two arguments as input values.
            // Argument One: SQL Variable Name
            // Argument Two: Variable Value
            // The SqlParameter handles the declaration of the actual SQL Parameter in the T-SQL.
            SqlParameter sqlparam = new SqlParameter("PropertyName", newPropertySearch.PropertyName);
            sqlcomm.Parameters.Add(sqlparam);

            // Notice that there is one ‘SqlParameter’ variable for each variable used in the SQL Query
            // More SqlParameter variables will need to be added for additional SQL variables.
            sqlparam = new SqlParameter("PropertyAddress", newPropertySearch.PropertyAddress);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PropertyCity", newPropertySearch.PropertyCity);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PropertyState", newPropertySearch.PropertyState);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PropertyZIP", newPropertySearch.PropertyZIP);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PropertyTownship", newPropertySearch.PropertyTownship);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PropertyCounty", newPropertySearch.PropertyCounty);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PropertyStatus", newPropertySearch.PropertyStatus);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }
    }
}
