using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;
/// <summary>
/// 原项目代码
/// </summary>
public class ReadMysqlEdit : MonoBehaviour {

    public static MySqlConnection dbConnection;
    private static string Host = "39.96.183.75";
    private static string user = "root";
    private static string pwd = "imgoul";
    private static string database = "chemistry";
    private MySqlCommand sqlCommand;
    private MySqlDataReader reader;


    public GameObject content;
    public GameObject buttonprefab;
    public GameObject chapter;

    void Start () {
        OpenSql();
        ReaderData();

    }
	
    public void OpenSql()
    {
        //text[0].text = "服务器连接";
        try
        {
            string connectionString = string.Format("Server = {0};port={4};Database = {1}; User ID = {2}; Password = {3};", Host, database, user, pwd, "3306");
            dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
        }
        catch (Exception e)
        {
            throw new Exception("服务器连接失败，请重新检查是否打开MySql服务。" + e.Message.ToString());
        }
    }

    public void ReaderData()
    {
        string sql = "select * from section";
        sqlCommand = new MySqlCommand(sql, dbConnection);
        reader = sqlCommand.ExecuteReader();
  

        try
        {
            while (reader.Read())
            {
                if (reader.HasRows)
                {                   /* Instantiate用来复制并返回GameObject*/
                    GameObject go = Instantiate(buttonprefab);
                    go.transform.SetParent(content.transform);
                    /*Vector3.one直接给Vector赋值（1,1,1）*/
                    go.transform.localScale = Vector3.one;
                    string chaptername = reader.GetString(1);
                    string chapterid = reader.GetString(2);
                    go.GetComponentInChildren<Text>().text = "第" + chapterid + "章:" + chaptername;
                    go.name = chapterid;
                    go.AddComponent<MainButtonEvent>();
                    go.GetComponent<Button>().onClick.AddListener(delegate { IntoMain(); });
                }
            }
        }
        catch (Exception)
        {

            print("查询失败");
        }
        finally
        {
            reader.Close();
        }
    }

    public void IntoMain()
    {
        chapter.SetActive(false);
    }
}
