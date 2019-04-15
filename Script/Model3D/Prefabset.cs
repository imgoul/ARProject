using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prefabset : MonoBehaviour
{
    private GameObject game;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("ARTarget");
    }
    private void Update()
    {
        if(ConnectMySql.Modle3DGo!=null&&game!=null)
        {
            ConnectMySql.Modle3DGo.transform.SetParent(game.transform);
           
            ConnectMySql.Modle3DGo.GetComponent<GetCenter>().enabled = false;
            if(DefaultTrackableEventHandler.notfind == false)
            {
                ConnectMySql.Modle3DGo.SetActive(false);
                DefaultTrackableEventHandler.notfind = true;
            }
        }
    }

}
