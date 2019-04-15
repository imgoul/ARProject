using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using Assets.Script.Main;

public class StopCamera : MonoBehaviour {



    public GameObject vrcamera;

    // Use this for initialization
    void Start () {
       // vrcamera.GetComponent<VuforiaBehaviour>().enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if(MainUimanager.IsARscene)
        {
            Startcamera();
            MainUimanager.IsARscene = false;
        }
    }

    public void Stop()
    {
       
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Deinit();
        VuforiaUnity.OnPause();
        vrcamera.GetComponent<VuforiaBehaviour>().enabled = false;
    }

    public void Startcamera()
    {
        
        vrcamera.GetComponent<VuforiaBehaviour>().enabled = true;
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
        CameraDevice.Instance.Start();
        VuforiaUnity.OnResume();
        
    }
 
    public void ExitAr()
    {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Deinit();
        VuforiaUnity.OnPause();
        vrcamera.GetComponent<VuforiaBehaviour>().enabled = false;
        SceneManager.LoadScene(0);
    }
}
