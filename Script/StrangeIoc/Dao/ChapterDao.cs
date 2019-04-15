using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Assets.Script.StrangeIoc.model.Chapters;
using Assets.Script.StrangeIoc.tools;
using MySql.Data.MySqlClient;
using Debug = UnityEngine.Debug;

namespace Assets.Script.StrangeIoc.Scripts.Dao
{
    class ChapterDao
    {
        /// <summary>
        /// 获取section表中的所有数据
        /// </summary>
        /// <returns></returns>
        public List<Chapter> SelectAllChapterItem()
        {
           
            MySqlConnection connection = DBUtility.Connect();
            MySqlDataReader reader = null;
            MySqlCommand cmd = null;
            List<Chapter> list = new List<Chapter>();
            try
            {
                //Debug.Log("Dao正在查询数据库");
                cmd = new MySqlCommand("select * from chapters", connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Chapter(reader.GetInt32("Id"), reader.GetString("ChapterName"),
                        reader.GetInt32("ChapterId")));
                    //Debug.Log(reader.GetInt32("Id")+","+ reader.GetString("ChapterName")+","+reader.GetInt32("ChapterId"));
                    
                }

                return list;
            }
            catch (Exception e)
            {
                Debug.Log("在SelectAllSectionItem时出现异常：" + e);
            }
            finally
            {
                reader.Close();
                DBUtility.CloseConnection(connection);
            }
            
            return null;
        }
    }
}
