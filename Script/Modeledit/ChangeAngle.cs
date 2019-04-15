using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAngle : MonoBehaviour
{

    // Use this for initialization
    public GameObject CameraX;
    public GameObject CameraY;
    public GameObject CameraZ;
    public GameObject CameraT;
    void Start()
    {
        CameraX.SetActive(false);
        CameraY.SetActive(false);
        CameraT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(mouse_ray.selectgame);
        }
    }

    public void ChangeX(float angle)
    {
        if(mouse_ray.selectgame!=null)
        {
            Vector3 vectorx = new Vector3(angle, 0, 0);
            mouse_ray.selectgame.transform.eulerAngles += vectorx;
        }
    }

    public void ChangeY(float angle)
    {
        if (mouse_ray.selectgame != null)
        {
            Vector3 vectorx = new Vector3(0, angle, 0);
            mouse_ray.selectgame.transform.eulerAngles += vectorx;
        }
    }

    public void ChangeZ(float angle)
    {
        if (mouse_ray.selectgame != null)
        {
            Vector3 vectorx = new Vector3(0, 0, angle);
            mouse_ray.selectgame.transform.eulerAngles += vectorx;
        }
    }

    public void ZjCamerax()
    {
        CameraX.SetActive(true);
        CameraZ.SetActive(false);
        CameraY.SetActive(false);
        CameraT.SetActive(false);
    }

    public void ZjCameraY()
    {
        CameraX.SetActive(false);
        CameraZ.SetActive(false);
        CameraY.SetActive(true);
        CameraT.SetActive(false);
    }
    public void ZjCameraZ()
    {
        CameraX.SetActive(false);
        CameraZ.SetActive(true);
        CameraY.SetActive(false);
        CameraT.SetActive(false);
    }

    public void Toushi()
    {
        CameraX.SetActive(false);
        CameraZ.SetActive(false);
        CameraY.SetActive(false);
        CameraT.SetActive(true);
    }

    public void Zhenjiao()
    {
        CameraX.SetActive(false);
        CameraZ.SetActive(true);
        CameraY.SetActive(false);
        CameraT.SetActive(false);
    }
}
