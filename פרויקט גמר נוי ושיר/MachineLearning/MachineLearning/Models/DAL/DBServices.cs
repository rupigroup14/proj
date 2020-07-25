using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using WebApplication3.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Read consumercomplaints list
    //---------------------------------------------------------------------------------
    public List<Tweet> getList()
    {
        List<Tweet> tweetsList = new List<Tweet>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM(select top(2363) * from Tweets1$ where sentiment = 0 ORDER BY NEWID()) first " +
                "union all " +
                "SELECT* FROM(select top(2363) *from Tweets1$ where sentiment = 1 ORDER BY NEWID()) second " +
                "union all " +
                "SELECT* FROM(select top(2363) *from Tweets1$ where sentiment = 2 ORDER BY NEWID()) last ";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Tweet t = new Tweet();

                t.Text = (string)dr["text"];
                t.Sentiment = Convert.ToInt32(dr["sentiment"]);
                tweetsList.Add(t);
            }

            return tweetsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }
}