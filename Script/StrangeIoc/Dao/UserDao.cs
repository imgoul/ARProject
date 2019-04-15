using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.StrangeIoc.model.Users;
using Assets.Script.StrangeIoc.tools;
using MySql.Data.MySqlClient;

namespace Assets.Demo.Scripts.Dao
{
    class UserDao
    {
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool VertifyUser(User user)
        {
            //连接数据库
            MySqlConnection connection = DBUtility.Connect();

            MySqlDataReader reader = null;

            try
            {
                MySqlCommand cmd =
                    new MySqlCommand("select * from user where username=@username and password=@username", connection);
                cmd.Parameters.AddWithValue("username", user.username);
                cmd.Parameters.AddWithValue("password", user.password);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("在vertifyUser时出现异常："+e);
                throw;
            }
            finally
            {
                DBUtility.CloseConnection(connection);
            }
        }

        public bool AddUser(User user)
        {
            MySqlConnection connection = DBUtility.Connect();

            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into user set username=@username and password=@password",connection);
                cmd.Parameters.AddWithValue("username", user.username);
                cmd.Parameters.AddWithValue("password", user.password);
                int isSuccess = cmd.ExecuteNonQuery();
                if (isSuccess != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                DBUtility.CloseConnection(connection);
            }
        }
    }
}
