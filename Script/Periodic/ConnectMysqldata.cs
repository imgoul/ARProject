using System;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Periodic
{
    public class ConnectMysqldata : MonoBehaviour {

        public static MySqlConnection dbConnection;
        private static string Host = "39.96.183.75";
        private static string user = "root";
        private static string pwd = "imgoul";
        private static string database = "chemistry";
        private MySqlCommand sqlCommand;
        private MySqlDataReader reader;
        public GameObject button;
        public Transform content;

        public Text ChineseName;
        public Text EnglishName;
        public Text ElementSymbol;
        public Text Number;
        public Text Mass;
        public Text Physicalproperty;
        public Text Knowledge;
        public Text Intro;
        private string path;
        void Start()
        {
        
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
            string sql = "select * from atoms";
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
                        GameObject go = Instantiate(button);
                        go.transform.SetParent(content);
                        go.transform.localScale = Vector3.one;
                        Texture2D image = (Texture2D)Resources.Load(path, typeof(Texture2D));
                        go.GetComponent<Image>().sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f));
                        go.name = reader.GetString(4);
                        go.GetComponent<Button>().onClick.AddListener(delegate { ReaderData(); });
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

        public void ReaderData()
        {
            string sql = "select * from atoms where id='"+ ButtonEvent.TypeName + "' and atomNumber='" + ButtonEvent.TypeName + "'";
            
            sqlCommand = new MySqlCommand(sql, dbConnection);
            reader = sqlCommand.ExecuteReader();
     

            try
            {
                while (reader.Read())     
                {
                    if (reader.HasRows)
                    {
                        ChineseName.text = reader.GetString(1);
                        EnglishName.text = reader.GetString(3);
                        ElementSymbol.text = reader.GetString(2);
                        Number.text = reader.GetString(4);
                        Mass.text = reader.GetString(5);
                        Physicalproperty.text = reader.GetString(6);
                        Knowledge.text = reader.GetString(7);
                        Intro.text = reader.GetString(8);
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
}
