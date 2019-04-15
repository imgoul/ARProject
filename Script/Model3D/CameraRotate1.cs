using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate1 : MonoBehaviour {

    // Use this for initialization
    // Use this for initialization
    public float scrollSpeed = 0.6f;
    public float rotatespeedx = 3;
    public float rotatespeedy = 3;
    public float distance;
    private Vector3 offsetPosition;//位置偏移
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotateview();
        }
        ScrollView();

    }
    void ScrollView()//滚轮操作
    {
        if (GetGameobject.Atomprefab != null)
        {

            distance = Vector3.Distance(transform.position, GetGameobject.Atomprefab.transform.position);
            distance = Mathf.Clamp(distance, 0.9f, 9);//限定距离最小及最大值

            if (Input.GetAxis("Mouse ScrollWheel") > 0 && distance > 0.95f)
            {
                Vector3 vector = transform.position - (transform.position - GetGameobject.Atomprefab.transform.position).normalized * scrollSpeed;
                transform.position = vector;

            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance < 9f)
            {
                Vector3 vector = transform.position + (transform.position - GetGameobject.Atomprefab.transform.position).normalized * scrollSpeed;
                transform.position = vector;

            }

        }

    }

    void rotateview()//上下左右移动视野
    {
        if ( GetGameobject.Atomprefab != null)
        {
            Transform prefabposion = GetGameobject.Atomprefab.transform;
            //transform.LookAt(prefabposion.position);//使相机朝向目标
            offsetPosition = transform.position - prefabposion.position;//获得相机与目标的位置的偏移量

            Vector3 originalPos = transform.position;//保存相机当前的位置
            Quaternion originalRotation = transform.rotation;//保存相机当前的旋转

            transform.RotateAround(prefabposion.position, transform.up, Input.GetAxis("Mouse X") * rotatespeedx);


            transform.RotateAround(prefabposion.position, transform.right, Input.GetAxis("Mouse Y") * -rotatespeedy);
            float x = transform.eulerAngles.x;//获得x轴的角度
                                              /* if (x < 10 || x > 80)
                                               {//限制x轴的旋转在10到80之间
                                                   transform.position = originalPos;
                                                   transform.rotation = originalRotation;
                                               }*/

            offsetPosition = transform.position - prefabposion.position;//更新位置偏移量
        }
    }
}
