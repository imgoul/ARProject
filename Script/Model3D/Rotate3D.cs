using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate3D : MonoBehaviour {

    // Use this for initialization
    public float speed = 30;
    private bool isrotate = false;
    public GameObject rotategame;
    private GameObject Maincmaera;
    public float distance;
    private Vector3 offsetPosition;//位置偏移
    public float rotatespeedx = 3;
    public float rotatespeedy = 3;

    void Start()
    {
        Maincmaera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
        rotategame = GameObject.FindGameObjectWithTag("Ting");

        if (isrotate && rotategame != null)
        {
            rotategame.GetComponent<GetCenter>().enabled = false;
            rotategame.transform.Rotate(0, speed * Time.deltaTime, 0);
        }
      
       /* if(Input.GetMouseButton(1))
        {
            Rotateview();
 
        }
        ScrolView();*/

        // Rotategame();
    }


    public void Rotate()
    {
        isrotate = !isrotate;
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

   /* public void Rotateview()
    {
        if(rotategame!=null)
        {
            //Maincmaera.transform.LookAt(rotategame.transform.position);
            offsetPosition = Maincmaera.transform.position - rotategame.transform.position;
            Vector3 vector = Maincmaera.transform.position;

            Maincmaera.transform.RotateAround(rotategame.transform.position, Maincmaera.transform.up, Input.GetAxis("Mouse X") * rotatespeedx);


            Maincmaera.transform.RotateAround(rotategame.transform.position, Maincmaera.transform.right, Input.GetAxis("Mouse Y") * -rotatespeedy);
        }
       
    }

    public void ScrolView()
    {
        if (rotategame != null)
        {

            if (Input.GetAxis("Mouse ScrollWheel") > 0 )
            {
                float scale = Input.GetAxis("Mouse ScrollWheel");
               
                Vector3 vector = new Vector3(scale, scale, scale);
                rotategame.transform.localScale += vector;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                float scale = Input.GetAxis("Mouse ScrollWheel");
                Vector3 vector = new Vector3(scale, scale, scale);
                rotategame.transform.localScale += vector;

            }
        }
    }*/
    public void ResetGame()
    {
        rotategame.transform.position = new Vector3(1.9f, 0, 0);
        rotategame.transform.rotation = new Quaternion();
        rotategame.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        isrotate = false;
    }
}
