using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TiKuData : MonoBehaviour
{

    public static MySqlConnection dbConnection;
    private static string Host = "39.96.183.75";
    private static string user = "root";
    private static string pwd = "imgoul";
    private static string database = "chemistry";
    private MySqlCommand sqlCommand;
    private MySqlDataReader reader;

    public GameObject timu;
    public Transform content;
    public GameObject A;
    private string Optionname;
    public static List<string> Answerlist = new List<string>();
    private int index = 0;
    public GameObject PanelScore;
    public Text Scoretext;
    public GameObject Tihaonum;
    public GameObject Tihaocontent;
    public Button submit;

    void Start()
    {
        OpenSql();
        
        PanelScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainButtonEvent.isOnclick)
        {
            ReaderData(MainButtonEvent.TypeId);
            MainButtonEvent.isOnclick = false;
        }
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

    public void ReaderData(string chapter)
    {
        string sql = "select * from question where ChapterId='"+ chapter + "'";
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
                    GameObject go = Instantiate(timu);
                    go.name = reader.GetString(0);
                    go.transform.SetParent(content);
                    go.transform.localScale = Vector3.one;
                    go.transform.GetChild(0).gameObject.GetComponent<Text>().text= reader.GetString(6);
                    

                    Transform xuanxiang = go.transform.GetChild(1);
                    xuanxiang.name = go.name;
                    for (int j = 0; j < xuanxiang.childCount; j++)
                    {
                        Destroy(xuanxiang.GetChild(j).gameObject);
                    }
                    for (int i = 0; i < reader.GetInt16(7); i++)
                    {
                        GameObject gameA = Instantiate(A);
                      
                     
                        gameA.transform.SetParent(xuanxiang);
                        gameA.GetComponentInChildren<Text>().text = reader.GetString(i + 2);
                        gameA.transform.localScale = Vector3.one;
                        
                        gameA.name = SetName(i);
                        gameA.AddComponent<Answer>();
                    }
         
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

    public void SelectAnswer(string id,string result)
    {
        string sql = "select TihaoId,Result from question where TihaoId='" + id + "' and Result='" + result + "'";
        sqlCommand = new MySqlCommand(sql, dbConnection);
        reader = sqlCommand.ExecuteReader();
        try
        {
            if (reader.Read())
            {
                if (reader.HasRows)
                {
                    
                    index++;
                } 
            }
            else
            {
                Answerlist.Add(id);
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

    public void Submit()
    {
        PanelScore.SetActive(true);
        for (int i = 0; i < Answer.Parentname.Count; i++)
        {
            SelectAnswer(Answer.Parentname[i], Answer.thisname[i]);
        }
        Scoretext.text = index.ToString();
        for (int i = 0; i < Answerlist.Count; i++)
        {
            GameObject gotihao = Instantiate(Tihaonum);
            gotihao.transform.SetParent(Tihaocontent.transform);
            gotihao.transform.localScale = Vector3.one;
            gotihao.GetComponent<Text>().text = Answerlist[i];
        }
        submit.interactable = false;
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
        index = 0;
        Answerlist.Clear();
        Answer.Parentname.Clear();
        Answer.thisname.Clear();
    }

    public string SetName(int num)
    {
        switch (num)
        {
            case 0:
                Optionname = "A";
                break;
            case 1:
                Optionname = "B";
                break;
            case 2:
                Optionname = "C";
                break;
            case 3:
                Optionname = "D";
                break;
            default:
                break;
        }
        return Optionname;
    }
}
