using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;

public class ModelEditSql : MonoBehaviour {


    public static MySqlConnection dbConnection;
    private static string Host = "39.96.183.75";
    private static string user = "root";
    private static string pwd = "imgoul";
    private static string database = "chemistry";
    private MySqlCommand sqlCommand;
    private MySqlDataReader reader;

    public Transform content;
    private string path;
    public GameObject button;
    public GameObject prefabbasicatom;
    private GameObject go;

    void Start () {
        OpenSql();
        ReadAlldata();
	}
	
    public void OpenSql()
    {

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

    public void ReadAlldata()
    {
        string sql = "select * from atomtable";
        sqlCommand = new MySqlCommand(sql, dbConnection);
        reader = sqlCommand.ExecuteReader();

        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        try
        {
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    path = "biao/" + reader.GetInt16(4);
                    go = Instantiate(button);
                    go.transform.SetParent(content);
                    go.transform.localScale = Vector3.one;
                    Texture2D image = (Texture2D)Resources.Load(path, typeof(Texture2D));
                    go.GetComponent<Image>().sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f));
                    go.name = reader.GetString(1);
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
        Carbon.basicatom = prefabbasicatom;
    }
}
