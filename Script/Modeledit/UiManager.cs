using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    // Use this for initialization
    public static bool Issave = false;
	
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
        Issave = true;
    }
}
