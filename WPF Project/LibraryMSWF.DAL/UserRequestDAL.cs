using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace LibraryMSWF.DAL
{
    public class UserRequestDAL
    {
        //ADD THE BOOK REQUEST INTO REQUEST TABLE =>DAL
        String strCon = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=LibraryMSWF;Integrated Security=True";
        SqlConnection sqlCon = null;
        
        //RETURN THE PERTICULAR USER REQUESTED BOOKS FROM REQUEST TABLE  =>DAL
        public DataSet GetAllRequestUserDAL(int userId)
        {
            sqlCon = new SqlConnection(strCon);
            SqlDataAdapter da = new SqlDataAdapter("GetAllRequestUser '"+userId+"'", sqlCon);
            SqlCommand cmd = new SqlCommand("GetAllRequestUser @uId", sqlCon);
            cmd.Parameters.Add(new SqlParameter("@uId", userId));
            DataSet ds = new DataSet("UsersRequests");
            da.Fill(ds);
            return ds;
        }
        //8. AddRequestDAL()
        public bool AddRequestDAL(int bookId, string bookName, int userId, string userName)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("AddRequest @bId, @bName, @date, @uId, @uName", sqlCon);
            cmd.Parameters.Add(new SqlParameter("@bId", bookId));
            cmd.Parameters.Add(new SqlParameter("@bName", bookName));
            cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now.Date));
            cmd.Parameters.Add(new SqlParameter("@uId", userId));
            if (String.IsNullOrEmpty(userName))
            {
                cmd.Parameters.AddWithValue("@uName", DBNull.Value);
            }
            else
                cmd.Parameters.AddWithValue("@uName", userName);
            //          cmd.Parameters.Add(new SqlParameter("@uName", userName));
            sqlCon.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        //RETURN THE COMPLETE REQUESTED BOOKS FROM REQUEST TABLE  =>DAL
        public DataSet GetAllRequestDAL()
        {
            sqlCon = new SqlConnection(strCon);
            SqlDataAdapter da = new SqlDataAdapter("GetAllRequest", sqlCon);
            DataSet ds = new DataSet("Requests");
            da.Fill(ds);
            return ds;
        }
        //DELETE THE BOOK REQUEST FROM REQUEST TABLE =>DAL
        public bool DeleteRequestDAL(int bookId, int userId)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("DeleteRequest @bId, @uId", sqlCon);
            cmd.Parameters.Add(new SqlParameter("@bId", bookId));
            cmd.Parameters.Add(new SqlParameter("@uId", userId));
            sqlCon.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
