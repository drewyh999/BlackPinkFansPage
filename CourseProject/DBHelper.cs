using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace CourseProject
{

    public class DBHelper
    {
        public static System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static DataSet GetMerchandiseAll()
        {
            DataSet ds = new DataSet(); // 新建DataSet对象
                                        // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [merchandise] ", conn);
            conn.Open(); // 打开数据库连接
            da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
            conn.Close(); // 关闭数据库连接
            return ds;

        }

        public static DataSet GetMerchandiseByCate(String category)
        {
            DataSet ds = new DataSet(); // 新建DataSet对象
                                        // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
            string querystring = string.Format("SELECT * FROM [merchandise] where m_type = '{0}'", category);
            SqlDataAdapter da = new SqlDataAdapter(querystring, conn);
            conn.Open(); // 打开数据库连接
            da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
            conn.Close(); // 关闭数据库连接
            return ds;
        }

        public static Boolean TestPhoneAva(string phone)
        {
            string querystring = string.Format("SELECT * FROM [user] where phone = '{0}'", phone);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader();  // 将检索的记录行填充到DataReader对象中
                if (dr.Read())  //如果用户存在
                {   // 如果密码正确，显示登录成功
                    dr.Close();
                    conn.Close();
                    return false;
                }
                else  //如果用户不存在
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
                  //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Open();
                return false;
            }
            



        }
        public static Boolean TestUsernameAva(string username)
        {
            string querystring = string.Format("SELECT * FROM [user] where Id = '{0}'",username);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader();  // 将检索的记录行填充到DataReader对象中
                if (dr.Read())  //如果用户存在
                {   // 如果密码正确，显示登录成功
                    dr.Close();
                    conn.Close();
                    return false;
                }
                else  //如果用户不存在
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                return false;
            }




        }

        public static Boolean InsertComment(int ori_id, string author, string replytime, string replycontent)
        {
            string querystring = string.Format("INSERT INTO [reply] values({0},N'{1}','{2}',N'{3}')",ori_id,author,replytime,replycontent );

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if (count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                return false;
            }

        }
       　
        public static Boolean InsertPost(string authorid,string posttime,string content,string title,string section,string phone,string path)
        {
            string querystring = string.Format("INSERT INTO [posts] values(N'{0}','{1}',N'{2}',N'{3}','{4}','{5}','{6}')", authorid, posttime, content, title, section, phone,path);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if (count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Open();
                return false;
            }
        }
        public static Boolean InsertUser(string id,string email,string pwd,string phone,int balance,string gender,string avatar)
        {
            string querystring = string.Format("INSERT INTO [user] values(N'{0}','{1}','{2}','{3}',{4},'{5}','{6}')", id,email,pwd,phone,balance,gender,avatar);
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if(count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                return false;
            }



        }
        public static string QStringClean(string ori)
        {
            return ori.Replace("&", "'+char(38)+'").Replace("[", "'+char(219)+'").Replace("]", "'+char(221)+'")
                .Replace(":", "'+char(16)+'");
        }
        public static Boolean AddShoppingCart(string buyerid,string name,string price)
        {
           string querystring = string.Format("(N'{0}',N'{1}',{2})", buyerid,name,price);
            string ROOT = "INSERT INTO [shoppingcart] VALUES";
            querystring = QStringClean(querystring);
            querystring = ROOT + querystring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if (count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Close();
                return false;
            }
        }

        public static Boolean DeletePostById(string id)
        {
            string querystring = string.Format("DELETE [posts] WHERE Id = {0}", id);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if (count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Close();
                return false;
            }
        }
        public static Boolean DeleteShoppingCart(string item_id)
        {
            string querystring = string.Format("DELETE [shoppingcart] WHERE Id = {0}", item_id);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if (count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Close();
                return false;
            }
        }

        public static Boolean UpdatePersonalInfo(string id, string email, string pwd, string phone, string avatar)
        {
            string querystring;
            if (avatar != "")
            {
                 querystring = string.Format("UPDATE [user] SET email = '{0}',pwd = '{1}',phone = '{2}',avatar = '{3}' WHERE Id='{4}'", email, pwd, phone, avatar,id);
            }
            else
            {
                querystring = string.Format("UPDATE [user] SET email = '{0}',pwd = '{1}',phone = '{2}' WHERE Id='{3}'", email, pwd, phone, id);

            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if (count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                return false;
            }
        }
        public static Boolean UpdateBalance(string Id,int delta)
        {
            string querystring = string.Format("UPDATE [user] SET balance = {0} WHERE Id = N'{1}'", delta,Id);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                int count = cmd.ExecuteNonQuery();  // 将检索的记录行填充到DataReader对象中
                if (count == 1)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Close();
                return false;
            }
        }

        public static Boolean VerifyUser(string phone, string pwd)
        {
            string querystring = string.Format("SELECT * FROM [user] where phone = '{0}' and pwd = '{1}'", phone,pwd);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader();  // 将检索的记录行填充到DataReader对象中
                if (dr.Read())  //如果用户存在
                {   // 如果密码正确，显示登录成功
                    dr.Close();
                    conn.Close();
                    return true;
                }
                else  //如果用户不存在
                {
                    dr.Close();
                    conn.Close();
                    return false;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                return false;
            }
        }

        public static int GetShoppingCartSum(string buyerid)
        {
            string querystring = string.Format("SELECT SUM(price) FROM [shoppingcart] where buyerid = N'{0}'", buyerid);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader();  // 将检索的记录行填充到DataReader对象中
                if (dr.Read())  //如果用户存在
                {   // 如果密码正确，显示登录成功
                    int result = Convert.ToInt32(dr[0]);
                   

                    dr.Close();
                    conn.Close();
                    return result;
                }
                else  //如果用户不存在
                {
                    dr.Close();
                    conn.Close();
                    return 0;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Close();
                return 0;
            }
        }
        public static User GetUserInfo(string phone)
        {
            string querystring = string.Format("SELECT * FROM [user] where phone = '{0}'", phone);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader();  // 将检索的记录行填充到DataReader对象中
                if (dr.Read())  //如果用户存在
                {   // 如果密码正确，显示登录成功
                    User result = new User();
                    result.Id = Convert.ToString(dr["Id"]);
                    result.Phone = Convert.ToString(dr["phone"]);
                    result.Balance = Convert.ToInt32(dr["balance"]);
                    result.Avatar = Convert.ToString(dr["avatar"]);
                    result.Email = Convert.ToString(dr["email"]);
                    result.pwd = Convert.ToString(dr["pwd"]);
                    dr.Close();
                    conn.Close();
                    return result;
                }
                else  //如果用户不存在
                {
                    dr.Close();
                    conn.Close();
                    return null;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                conn.Close();
                return null;
            }
        }

      
      
        public static DataSet GetPostsBySection(string section)
        {
            DataSet ds = new DataSet(); // 新建DataSet对象
                                        // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
            string q_string = string.Format("SELECT * from [posts] where section = '{0}'", section);
            SqlDataAdapter da = new SqlDataAdapter(q_string, conn);
            conn.Open(); // 打开数据库连接
            da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
            conn.Close(); // 关闭数据库连接
            return ds;
        }
        
        public static DataSet GetPostsByUserId(string user_id)
        {
            DataSet ds = new DataSet(); // 新建DataSet对象
                                        // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
            string q_string = string.Format("SELECT * from [posts] where authorid = N'{0}'", user_id);
            SqlDataAdapter da = new SqlDataAdapter(q_string, conn);
            conn.Open(); // 打开数据库连接
            da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
            conn.Close(); // 关闭数据库连接
            return ds;
        }

        public static DataSet GetReplyByOriginalPostId(string ori_id)
        {
            DataSet ds = new DataSet(); // 新建DataSet对象
                                        // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
            string q_string = string.Format("SELECT * from [reply] where ori_id = {0}", ori_id);
            SqlDataAdapter da = new SqlDataAdapter(q_string, conn);
            conn.Open(); // 打开数据库连接
            da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
            conn.Close(); // 关闭数据库连接
            return ds;
        }

        public static DataSet GetShoppingCartByBuyerId(string id)
        {
            DataSet ds = new DataSet(); // 新建DataSet对象
                                        // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
            string q_string = string.Format("SELECT * from [shoppingcart] where buyerid = N'{0}'", id);
            SqlDataAdapter da = new SqlDataAdapter(q_string, conn);
            conn.Open(); // 打开数据库连接
            da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
            conn.Close(); // 关闭数据库连接
            return ds;
        }
        public static Post GetAPostById(string id)
        {
            string querystring = string.Format("SELECT * FROM [posts] where Id = {0}", id);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = querystring;
            cmd.CommandType = CommandType.Text;
            try   // 打开conn连接，检索User表的Password字段
            {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader();  // 将检索的记录行填充到DataReader对象中
                if (dr.Read())  //如果用户存在
                {   // 如果密码正确，显示登录成功
                    Post result = new Post();
                    result.Id = Convert.ToInt32(dr["Id"]);
                    result.content = Convert.ToString(dr["content"]);
                    result.title = Convert.ToString(dr["title"]);
                    result.posttime = Convert.ToString(dr["posttime"]);
                    result.author = Convert.ToString(dr["authorid"]);
                    result.authorphone = Convert.ToString(dr["authorphone"]);
                    result.imgpath = Convert.ToString(dr["imgpath"]);

                    dr.Close();
                    conn.Close();
                    return result;
                }
                else  //如果用户不存在
                {
                    dr.Close();
                    conn.Close();
                    return null;
                }
                //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);  // 显示连接异常信息
                return null;
            }
        }
        
    }
}