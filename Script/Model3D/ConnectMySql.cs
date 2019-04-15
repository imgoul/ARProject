using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using UnityEngine.UI;
using System.IO;

public class ConnectMySql : MonoBehaviour
{
    public static MySqlConnection dbConnection;
    private static string Host = "39.96.183.75";
    private static string user = "root";
    private static string pwd = "imgoul";
    private static string database = "chemistry";
    private MySqlCommand sqlCommand;
    private MySqlDataReader reader;

    public GameObject cpdbutton;
    public Transform cpdcontent;
    public GameObject tovebutton;
    public Transform tovecontent;
    public Text dingyi;
    GameObject go;
    public static GameObject Modle3DGo;
    private void Start()
    {
        OpenSql();
    }
    private void Update()
    {
        if (MainButtonEvent.isOnclick)
        {
            ReaderData(MainButtonEvent.TypeId);
            MainButtonEvent.isOnclick = false;
        }
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

    public void ReaderData(string chapterid)
    {
        string sql = "select * from cpdtype where ChapterId='" + chapterid + "'";
        sqlCommand = new MySqlCommand(sql, dbConnection);
        reader = sqlCommand.ExecuteReader();
        for (int i = 0; i < cpdcontent.childCount; i++)
        {
            Destroy(cpdcontent.GetChild(i).gameObject);
        }

        try
        {
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    go = Instantiate(cpdbutton);                  
                    go.transform.SetParent(cpdcontent);
                    go.transform.localScale = Vector3.one;
                    go.GetComponentInChildren<Text>().text = reader.GetString(0);
                    go.name = reader.GetString(0);
                    go.AddComponent<ButtonEvent>();
                    go.GetComponent<Button>().onClick.AddListener(delegate { GetPrefab(); });
                   
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

    public void GetPrefab()
    {
        reader.Close();
        string sql = "select * from tovetable where TypeName='"+ButtonEvent.TypeName+"' ";

        
       // string sql = "select * from cpdtype c,tovetable t where c.TypeName=t.TypeName";
        sqlCommand = new MySqlCommand(sql, dbConnection);
        reader = sqlCommand.ExecuteReader();
        for (int i = 0; i < tovecontent.childCount; i++)
        {
            Destroy(tovecontent.GetChild(i).gameObject);
        }
        try
        {
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    // print("typename:" + reader.GetString(0) + "id:" + reader.GetString(1)+"  "+reader.GetString(2)+"   "+reader.GetString(3) + "  " + reader.GetString(4) + "   " + reader.GetString(5));
                    GameObject tove = Instantiate(tovebutton);
                    tove.transform.SetParent(tovecontent);
                    tove.transform.localScale = Vector3.one;
                    tove.GetComponentInChildren<Text>().text = reader.GetString(2);
                    tove.name = reader.GetString(2);
                    tove.AddComponent<ButtonEvent>();
                    tove.GetComponent<Button>().onClick.AddListener(delegate { GetText(); });
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

    public void GetText()
    {
        reader.Close();
      
        string sql = "select * from tovetable where ToveName='" + ButtonEvent.TypeName + "' ";
        string path = "Tovc/" + ButtonEvent.TypeName;
        DirectoryInfo pathinfo=new DirectoryInfo(path);
        // string sql = "select * from cpdtype c,tovetable t where c.TypeName=t.TypeName";
        sqlCommand = new MySqlCommand(sql, dbConnection);
        reader = sqlCommand.ExecuteReader();
        if(Resources.Load(path, typeof(GameObject))==null)
        {
            return;
        }
        if (Modle3DGo != null)
        {
            Destroy(Modle3DGo);
        }
        Modle3DGo = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
        try
        {
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    dingyi.text = reader.GetString(3);
                  
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

  
}
