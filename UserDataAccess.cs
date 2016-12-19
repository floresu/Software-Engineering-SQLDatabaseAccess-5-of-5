using AXT.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AXT.SQLDBDataAccess
{
    public class UserDataAccess : DBAccess
    {

        // Constructor 
        public UserDataAccess(string connectionString) : base(connectionString) { }

        // A function that inserts a User into the database.
        public void InsertUser(UserModel newUser)
        {
            // Declare a new variable. Variable name is ‘sSQL’. Datatype is ‘string’.
            string sSQL = "";

            // Define the value for the ‘sSQL’ string variable.
            // Notice that this text is a SQL Query.
            sSQL += " INSERT INTO [User] ";

            // More columns will need to be added, depending on how many columns you have in your User table.
            // In this line, you need ALL the columns from your User table.

            // The word ‘Password’ is in brackets because it is a reserved word in SQL. 
            // We are hijacking that word and using it for our own purposes, so we need to put it in brackets.
            // Normally, SQL would try to interpret the word 'Password' differently than how we're using it.

            sSQL += " (FirstName, LastName, Email, [Password], PhoneNumber, UserType) ";
            sSQL += " Values ";
            // The ‘@’ sign is a SQL Variable. It is connected to a SqlParameter (below).
            // This line needs to exactly match the list of columns in the User table.
            sSQL += " (@FirstName, @LastName, @Email, @Password, @PhoneNumber, @UserType) ";

            // Declare a new variable. Variable name is ‘sqlcomm’. Datatype is ‘SqlCommand’.
            SqlCommand sqlcomm = new SqlCommand();
            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            // This SqlParameter constructor takes two arguments as input values.
            // Argument One: SQL Variable Name
            // Argument Two: Variable Value
            // The SqlParameter handles the declaration of the actual SQL Parameter in the T-SQL.
            SqlParameter sqlparam = new SqlParameter("FirstName", newUser.FirstName);
            sqlcomm.Parameters.Add(sqlparam);

            // Notice that there is one ‘SqlParameter’ variable for each variable used in the SQL Query
            // More SqlParameter variables will need to be added for additional SQL variables.
            sqlparam = new SqlParameter("LastName", newUser.LastName);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Email", newUser.Email);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Password", newUser.Password);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PhoneNumber", newUser.PhoneNumber);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("UserType", newUser.UserType);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }

        
        public void UpdateUser(UserModel um)
        {
            // Declare a new variable. Variable name is ‘sSQL’. Datatype is ‘string’.
            string sSQL = "";

            // Define the value for the ‘sSQL’ string variable.
            // Notice that this text is a SQL Query.
            sSQL += " INSERT INTO [User] ";

            // More columns will need to be added, depending on how many columns you have in your User table.
            // In this line, you need ALL the columns from your User table.

            // The word ‘Password’ is in brackets because it is a reserved word in SQL. 
            // We are hijacking that word and using it for our own purposes, so we need to put it in brackets.
            // Normally, SQL would try to interpret the word 'Password' differently than how we're using it.

            sSQL += " (FirstName, LastName, Email, [Password], PhoneNumber, UserType) ";
            sSQL += " Values ";
            // The ‘@’ sign is a SQL Variable. It is connected to a SqlParameter (below).
            // This line needs to exactly match the list of columns in the User table.
            sSQL += " (@FirstName, @LastName, @Email, @Password, @PhoneNumber, @UserType) ";

            // Declare a new variable. Variable name is ‘sqlcomm’. Datatype is ‘SqlCommand’.
            SqlCommand sqlcomm = new SqlCommand();
            // Assign a value to the CommandText property.
            sqlcomm.CommandText = sSQL;

            // This SqlParameter constructor takes two arguments as input values.
            // Argument One: SQL Variable Name
            // Argument Two: Variable Value
            // The SqlParameter handles the declaration of the actual SQL Parameter in the T-SQL.
            SqlParameter sqlparam = new SqlParameter("FirstName", um.FirstName);
            sqlcomm.Parameters.Add(sqlparam);

            // Notice that there is one ‘SqlParameter’ variable for each variable used in the SQL Query
            // More SqlParameter variables will need to be added for additional SQL variables.
            sqlparam = new SqlParameter("LastName", um.LastName);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Email", um.Email);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("Password", um.Password);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("PhoneNumber", um.PhoneNumber);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("UserType", um.UserType);
            sqlcomm.Parameters.Add(sqlparam);

            // Execute the query.
            ExecNonQuery(sqlcomm);
        }
        

        // This function is called when a user tries to login to the website.
        // The function validates whether or not the username and password are correct.
        // If the username and password are correct, the UserID will be returned.
        // Otherwise, return 0.
        public int GetUserIDFromLogin(string email, string password)
        {

            string sql = " SELECT [UserID] FROM [User] WHERE Email = @Email AND Password = @Password ";

            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandText = sql;

            SqlParameter sqlparam = new SqlParameter("email", email);
            sqlcomm.Parameters.Add(sqlparam);

            sqlparam = new SqlParameter("password", password);
            sqlcomm.Parameters.Add(sqlparam);


            object oUserID = ExecScalar(sqlcomm);

            int userID = 0;

            if (oUserID != null)

            {

                string sUserID = oUserID.ToString();

                if (string.IsNullOrEmpty(sUserID) == false)

                {

                    userID = int.Parse(sUserID);

                }

            }

            return userID;

            


        }

        // This DataAccess function gets data for all Users from the database

        public List<UserModel> GetUsers()

        {

            // This is a SQL Query

            string sql = " SELECT UserID, Email, FirstName, LastName FROM [User] ";



            SqlCommand sqlcomm = new SqlCommand();

            sqlcomm.CommandText = sql;



            // Execute the SQL query

            DataTable dt = ExecReader(sqlcomm);



            // This is the variable that will be returned from the function.

            List<UserModel> Users = new List<UserModel>();



            // Go through each row in the datatable.

            foreach (DataRow dr in dt.Rows)

            {

                // Get the data from the datatable

                UserModel User = new UserModel();

                User.UserID = int.Parse(dr["UserID"].ToString());

                User.FirstName = dr["FirstName"].ToString();

                User.Email = dr["Email"].ToString();



                // Add this User to the list

                Users.Add(User);

            }



            return Users;

        }
    }

    /*
    public UserModel GetUser(int userID)
    {

    }
    */
}



   
