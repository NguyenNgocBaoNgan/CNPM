using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMSWF.DAL
{
    public class UserDAL
    {
        //RETURN COMPLETE USERS FROM USER TABLE =>DAL
        String strCon = @"Data Source=DESKTOP-H0PK1MT\MSSQLSERVER01;Initial Catalog=quanli_thuvien;Integrated Security=True";
        SqlConnection sqlCon = null;
       
        public DataSet GetAllUsersDAL()
        {
            sqlCon = new SqlConnection(strCon);
            SqlDataAdapter da = new SqlDataAdapter("GetAllUsers", sqlCon);
            DataSet ds = new DataSet("Users");
            da.Fill(ds);
            return ds;
        }
        //ADD USER INTO USER TABLE =>DAL
        public string AddUserDAL(string userName, int userAdNo, string userEmail, string userPass)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd2 = new SqlCommand("Select count (*) from tblUsers where UserEmail=@email", sqlCon);
            cmd2.Parameters.Add(new SqlParameter("@email", userEmail));
            sqlCon.Open();
            int count = (int)cmd2.ExecuteScalar();
            sqlCon.Close();
            if (count > 0)
            {
                return "User already exists, ";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("AddUser @name, @adno, @email, @pass", sqlCon);
                cmd.Parameters.Add(new SqlParameter("@name", userName));
                cmd.Parameters.Add(new SqlParameter("@adno", userAdNo));
                cmd.Parameters.Add(new SqlParameter("@email", userEmail));
                cmd.Parameters.Add(new SqlParameter("@pass", userPass));
                sqlCon.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                sqlCon.Close();
                if (rowAffected > 0)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
        }
        //UPDATE THE USER FROM USER TABLE =>DAL
        public bool UpdateUserDAL(int userId, string userName, int userAdNo, string userEmail, string userPass)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("UpdateUser @id, @name, @adno, @email, @pass", sqlCon);
            cmd.Parameters.Add(new SqlParameter("@id", userId));
            cmd.Parameters.Add(new SqlParameter("@name", userName));
            cmd.Parameters.Add(new SqlParameter("@adno", userAdNo));
            cmd.Parameters.Add(new SqlParameter("@email", userEmail));
            cmd.Parameters.Add(new SqlParameter("@pass", userPass));
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
        //DELETE THE USER FROM USER TABLE =>DAL
        public bool DeleteUserDAL(int userId)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("DeleteUser @id", sqlCon);
            cmd.Parameters.Add(new SqlParameter("@id", userId));
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
        //RETURN USER NAME =>DAL
        public string TakeUserNameDAL(int userId)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("TakeUserName @userID", sqlCon);
            cmd.Parameters.Add(new SqlParameter("@userID", userId));
            sqlCon.Open();
            string userName = (string)cmd.ExecuteScalar();
            sqlCon.Close();
            Console.WriteLine(userName);
            return userName;
        }
        //CHECK THE USER LOGIN CREDENTIALS RETURN USER ID =>DAL
        public int UserLoginDAL(string userEmail, string userPass)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand("UserLogin @email, @pass", sqlCon);
                cmd.Parameters.Add(new SqlParameter("@email", userEmail));
                cmd.Parameters.Add(new SqlParameter("@pass", userPass));
                sqlCon.Open();
                int userId = (int)cmd.ExecuteScalar();
                sqlCon.Close();
                return userId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
