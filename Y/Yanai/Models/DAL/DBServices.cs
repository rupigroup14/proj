using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using Yanai.Models;

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
    // Read customers list
    //---------------------------------------------------------------------------------
    public List<Customer> getCustomersList()
    {
        List<Customer> customerList = new List<Customer>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Customer";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Customer c = new Customer();

                c.CustID = Convert.ToInt32(dr["custID"]);
                c.CustLogin = Convert.ToInt32(dr["custLogin"]);
                c.CustName = (string)dr["custName"];
                c.CustPhone = Convert.ToInt32(dr["custPhone"]);
                c.CustAddress = (string)dr["custAddress"];
                c.ManagerID= Convert.ToInt32(dr["managerID"]);
                customerList.Add(c);
            }

            return customerList;
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

    //---------------------------------------------------------------------------------
    // Read complaints list
    //---------------------------------------------------------------------------------
    public List<Complaint> getComplaintsList()
    {
        List<Complaint> complaintList = new List<Complaint>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Complaint";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Complaint co = new Complaint();

                co.CompID= Convert.ToInt32(dr["CompID"]);
                co.OrderDate = (string)dr["orderDate"];
                co.LastUpdate = (string)dr["lastUpdate"];
                co.OpenDate = (string)dr["openDate"];
                co.OnTreatDate = (string)dr["onTreatDate"];
                co.OpenType = (string)dr["openType"];
                co.OrderReport = (string)dr["orderReport"];
                co.StatName1 = (string)dr["StatusName"];
                co.CusLogin= Convert.ToInt32(dr["custLogin"]);
                co.ModeOfTreatment1= (string)dr["ModeOfTreatment"];
                co.OpenBy= (string)dr["openBy"];
                co.Archived = Convert.ToBoolean(dr["archived"]);
                complaintList.Add(co);
            }

            return complaintList;
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
    //---------------------------------------------------------------------------------
    // Read Comments Files list
    //---------------------------------------------------------------------------------
    public List<CommentFile> getCFilesList()
    {
        List<CommentFile> commentsFilesList = new List<CommentFile>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM CommentFiles";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                CommentFile cf = new CommentFile();

                cf.FilePath1 = (string)dr["FilePath"];
                cf.CommentID = Convert.ToInt32(dr["commentID"]);
                commentsFilesList.Add(cf);
            }

            return commentsFilesList;
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

    //---------------------------------------------------------------------------------
    // Read comments list by compnumber
    //---------------------------------------------------------------------------------
    public List<Comment> getCommentsList(int compnum)
    {
        List<Comment> CommentsList = new List<Comment>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Comment where CompID="+ compnum;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Comment com = new Comment();

                com.CommentID= Convert.ToInt32(dr["commentID"]);
                com.CommentTime = (string)dr["commentTime"];
                com.CommentDes = (string)dr["commentDescription"];
                com.ManagerID = Convert.ToInt32(dr["managerID"]);
                com.CompID = Convert.ToInt32(dr["CompID"]);
                CommentsList.Add(com);
            }

            return CommentsList;
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
    //---------------------------------------------------------------------------------
    // Read comments list
    //---------------------------------------------------------------------------------
    public List<Comment> getCommentsList1()
    {
        List<Comment> CommentsList = new List<Comment>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Comment";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Comment com = new Comment();

                com.CommentID= Convert.ToInt32(dr["commentID"]);
                com.CommentTime = (string)dr["commentTime"];
                com.CommentDes = (string)dr["commentDescription"];
                com.ManagerID = Convert.ToInt32(dr["managerID"]);
                com.CompID = Convert.ToInt32(dr["CompID"]);
                CommentsList.Add(com);
            }

            return CommentsList;
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

    //---------------------------------------------------------------------------------
    // Read products list
    //---------------------------------------------------------------------------------
    public List<Product> getProductsList()
    {
        List<Product> productList = new List<Product>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Product p = new Product();

                p.ProductId = Convert.ToInt32(dr["productID"]);
                p.ProductName = (string)dr["productName"];
                productList.Add(p);
            }

            return productList;
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

    //---------------------------------------------------------------------------------
    // Read managers list
    //---------------------------------------------------------------------------------
    public List<Manager> getManagersList()
    {
        List<Manager> managerList = new List<Manager>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT managerID, managerName, email, photo, permissionType FROM Manager";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Manager m = new Manager();

                m.ManagerID = Convert.ToInt32(dr["managerID"]);
                m.ManagerName = (string)dr["managerName"];
                m.Email = (string)dr["email"];
                m.Photo= (string)dr["photo"];
                m.PermissionType = (string)dr["permissionType"];
                managerList.Add(m);
            }

            return managerList;
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

    //---------------------------------------------------------------------------------
    // Check if manager exist in managers list
    //---------------------------------------------------------------------------------
    public bool checkmanagerList(string username, string password)
    {
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT COUNT(*) AS CHECKING FROM Manager WHERE managerName='" + username + "' and password='" + password + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                if (Convert.ToInt32(dr["checking"])==1)
                {
                    return true;
                }
            }
            return false;
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
    //---------------------------------------------------------------------------------
    // Check if customer exist in customers list
    //---------------------------------------------------------------------------------
    public bool checkcustomerexist(int idbycus)
    {
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT COUNT(*) AS CHECKING FROM Customer WHERE custLogin='"+ idbycus + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                if (Convert.ToInt32(dr["checking"]) == 1)
                {
                    return true;
                }
            }
            return false;
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
    //---------------------------------------------------------------------------------
    // Read files list
    //---------------------------------------------------------------------------------
    public List<File1> getFilesList()
    {
        List<File1> filesList = new List<File1>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Files";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                File1 f = new File1();

                f.FileID= Convert.ToInt32(dr["fileID"]);
                f.ProblemID = Convert.ToInt32(dr["probID"]);
                f.Description = (string)dr["Description1"];
                f.Filepath = (string)dr["filepath"];
                filesList.Add(f);
            }

            return filesList;
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

    //---------------------------------------------------------------------------------
    // Read manager-complaints list
    //---------------------------------------------------------------------------------
    public List<ManagerComplaint> getManComplaintsList()
    {
        List<ManagerComplaint> mancomplaintList = new List<ManagerComplaint>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM managerComplaints";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                ManagerComplaint mc = new ManagerComplaint();

                mc.ManagerID = Convert.ToInt32(dr["managerID"]);
                mc.CompID = Convert.ToInt32(dr["CompID"]);
                mc.SendType = (string)dr["sendType"];
                mancomplaintList.Add(mc);
            }

            return mancomplaintList;
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

    //--------------------------------------------------------------------------------------------------
    // This method inserts a file to the files table 
    //--------------------------------------------------------------------------------------------------
    public int insert(File1 file)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(file);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String(file)
    //--------------------------------------------------------------------
    private String BuildInsertCommand(File1 file)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, '{1}' ,'{2}')", file.ProblemID.ToString(), file.Description, file.Filepath);
        String prefix = "INSERT INTO Files " + "(probID, Description1, filepath)";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a problem to the problems table 
    //--------------------------------------------------------------------------------------------------
    public int insert(Problem problem)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(problem);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String(problem)
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Problem problem)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, '{1}' ,'{2}', {3}, '{4}')", problem.ProbID.ToString(), problem.Description11, problem.ProbType, problem.CompID.ToString(), problem.ProductName);
        String prefix = "INSERT INTO Problem " + "(probID, Description1, probType, CompID, productName) ";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a complaint to the complaints table 
    //--------------------------------------------------------------------------------------------------
    public int insert(Complaint complaint)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(complaint);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String(problem)
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Complaint complaint)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, '{9}', '{10}', '{11}')", complaint.CompID.ToString(), complaint.OrderDate, complaint.LastUpdate, complaint.OpenDate, complaint.OnTreatDate, complaint.OpenType, complaint.OrderReport, complaint.StatName1, complaint.CusLogin.ToString(), complaint.ModeOfTreatment1, complaint.OpenBy, complaint.Archived.ToString());
        String prefix = "INSERT INTO Complaint " + "(CompID, orderDate, lastUpdate, openDate, onTreatDate, openType, orderReport, StatusName, custLogin, ModeOfTreatment, openBy, archived) ";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a comment to the comments table 
    //--------------------------------------------------------------------------------------------------
    public int insert(Comment comment)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(comment);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String(comment)
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Comment comment)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, '{1}', '{2}', {3}, {4})", comment.CommentID.ToString(), comment.CommentTime, comment.CommentDes, comment.ManagerID.ToString(), comment.CompID.ToString());
        String prefix = "INSERT INTO Comment " + "(commentID, commentTime, commentDescription, managerID, CompID) ";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a commentFile to the commentFiles table 
    //--------------------------------------------------------------------------------------------------
    public int insert(CommentFile CommentFile)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(CommentFile);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String(commentFile)
    //--------------------------------------------------------------------
    private String BuildInsertCommand(CommentFile CommentFile)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', {1})", CommentFile.FilePath1, CommentFile.CommentID.ToString());
        String prefix = "INSERT INTO CommentFiles " + "(FilePath, commentID) ";
        command = prefix + sb.ToString();

        return command;
    }

    //---------------------------------------------------------------------------------
    // Read problems list
    //---------------------------------------------------------------------------------
    public List<Problem> getProblemsList()
    {
        List<Problem> problemList = new List<Problem>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Problem";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Problem p = new Problem();

                p.ProbID = Convert.ToInt32(dr["probID"]);
                p.Description11 = Convert.ToString(dr["Description1"]);
                p.ProbType = Convert.ToString(dr["probType"]);
                p.CompID = Convert.ToInt32(dr["CompID"]);
                p.ProductName = Convert.ToString(dr["productName"]);
                problemList.Add(p);
            }

            return problemList;
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

    //--------------------------------------------------------------------------------------------------
    // This method inserts a managerComplaint to the managerComplaint table 
    //--------------------------------------------------------------------------------------------------
    public int insert(ManagerComplaint managerComplaint)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(managerComplaint);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String(managerComplaint)
    //--------------------------------------------------------------------
    private String BuildInsertCommand(ManagerComplaint managerComplaint)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, {1}, '{2}')", managerComplaint.ManagerID.ToString(), managerComplaint.CompID.ToString(), managerComplaint.SendType);
        String prefix = "INSERT INTO managerComplaints " + "(managerID, CompID, sendType) ";
        command = prefix + sb.ToString();

        return command;
    }
    

    //--------------------------------------------------------------------------------------------------
    // This method delete a managercomplaint from the managercomplaints table 
    //--------------------------------------------------------------------------------------------------
    public int deleteMC(int number)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildDeleteCommand3(number);    // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Delete command String(managercomplaint)
    //--------------------------------------------------------------------
    private String BuildDeleteCommand3(int number)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("where CompID={0}", number);
        String prefix = "DELETE FROM managerComplaints ";
        command = prefix + sb.ToString();

        return command;
    }

    //---------------------------------------------------------------------------------
    // Read complaint using a DataSet
    //---------------------------------------------------------------------------------
    public DBservices readComplaints()
    {
        SqlConnection con = null;
        try
        {
            con = connect("DBConnectionString");
            da = new SqlDataAdapter("select * from Complaint", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
        }

        catch (Exception ex)
        {
            // write errors to log file
            // try to handle the error
            throw ex;
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }


        return this;

    }

    public void update()
    {
        da.Update(dt);
    }

    //---------------------------------------------------------------------------------
    // Read filtered complaints list
    //---------------------------------------------------------------------------------
    public List<Complaint> getFilteredComplList(int managerId, int archived)
    {
        List<Complaint> complaintList = new List<Complaint>();
        SqlConnection con = null;
        // classEX enter your code here

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT distinct Complaint.CompID, Complaint.openDate, Complaint.custLogin, Complaint.orderDate, Complaint.StatusName, Complaint.lastUpdate, complaint.openType, complaint.orderReport, complaint.ModeOfTreatment, complaint.openBy, complaint.archived " +
                "FROM Complaint "+
                "INNER JOIN Customer "+
                "ON Complaint.custLogin = Customer.custLogin "+
                "LEFT JOIN managerComplaints "+
                "ON Complaint.CompID = managerComplaints.CompID "+
                "where(Customer.managerID = "+ managerId + " OR(managerComplaints.managerID = "+ managerId + " AND managerComplaints.sendType = 'forInformed')) AND Complaint.archived = "+ archived;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Complaint co = new Complaint();

                co.CompID = Convert.ToInt32(dr["CompID"]);
                co.OrderDate = (string)dr["orderDate"];
                co.LastUpdate = (string)dr["lastUpdate"];
                co.OpenDate = (string)dr["openDate"];
                co.OpenType = (string)dr["openType"];
                co.OrderReport = (string)dr["orderReport"];
                co.StatName1 = (string)dr["StatusName"];
                co.CusLogin = Convert.ToInt32(dr["custLogin"]);
                co.ModeOfTreatment1 = (string)dr["ModeOfTreatment"];
                co.OpenBy = (string)dr["openBy"];
                co.Archived = Convert.ToBoolean(dr["archived"]);
                complaintList.Add(co);
            }

            return complaintList;
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