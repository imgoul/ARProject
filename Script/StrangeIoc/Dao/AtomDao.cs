using System;
using System.Collections.Generic;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.tools;
using MySql.Data.MySqlClient;
using UnityEngine;

namespace Assets.Script.StrangeIoc.Dao
{
    public class AtomDao
    {

        /// <summary>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回值为List<Atom></returns>
        private List<Atom> Select(string sql)
        {

            MySqlConnection connection = DBUtility.Connect();
            MySqlDataReader reader = null;
            MySqlCommand cmd = null;
            List<Atom> list =new List<Atom>();
            bool isSuccess = false;
            string id = "id";
            string atomName = "atomName";
            string atomSymbol = "atomSymbol";
            string atomEnglishName = "atomEnglishName";
            string atomNumber = "atomNumber";
            string relativeAtomMass = "relativeAtomMass";
            string physicalProperty = "physicalProperty";
            string importantKnowledge = "importantKnowledge";
            string atomIntroduction = "atomIntroduction";
            try
            {
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    isSuccess = true;
                    id = "id";
                    atomName = "atomName";
                    atomSymbol = "atomSymbol";
                    atomEnglishName = "atomEnglishName";
                    atomNumber = "atomNumber";
                    relativeAtomMass = "relativeAtomMass";
                    physicalProperty = "physicalProperty";
                    importantKnowledge = "importantKnowledge";
                    atomIntroduction = "atomIntroduction";
                    //Debug.Log(reader.GetInt32(id) + "," + reader.GetString(atomName) + "," + reader.GetString(atomSymbol) + "," + reader.GetString(
                    //        atomEnglishName) + "," + reader.GetInt32(atomNumber) + "," + reader.GetDouble(relativeAtomMass) + "," + reader.GetString(physicalProperty) + "," +
                    //    reader.GetString(importantKnowledge) + "," + reader.GetString(atomIntroduction));
                    list.Add(new Atom(reader.GetInt32(id), reader.GetString(atomName), reader.GetString(atomSymbol), reader.GetString(
                            atomEnglishName), reader.GetInt32(atomNumber), reader.GetDouble(relativeAtomMass), reader.GetString(physicalProperty),
                        reader.GetString(importantKnowledge), reader.GetString(atomIntroduction)));
                
                }

                if (isSuccess)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            
            }
            catch (Exception e)
            {
                Debug.Log("在Select时出现异常：" + e);
            }
            finally
            {
                // ReSharper disable once PossibleNullReferenceException
                reader.Close();
                DBUtility.CloseConnection(connection);
            }

            return null;
        }

        /// <summary>
        /// 查询所有Atom
        /// </summary>
        /// <returns>List类型</returns>
        public List<Atom> SelectAllAtomItem()
        {
            string sql = "select * from atoms";
            return Select(sql);
        }

        /// <summary>
        /// 根据Id查询Atom表
        /// </summary>
        /// <param name="atomName">元素名称</param>
        /// <returns></returns>
        public List<Atom> SelectAtomByAtomName(string atomName)
        {
            //Debug.Log(atomName);
            string sql = "select * from atoms where atomName='" + atomName + "'";
            return Select(sql);
        }
    }
}


