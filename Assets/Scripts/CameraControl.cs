using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    public Camera cam;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float cameraMinZoom;
    [SerializeField] private float cameraMaxZoom;
    
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = target.gameObject.transform.position;
        transform.position = pos;

        transform.Rotate(0f,Input.GetAxis("Horizontal") * -rotateSpeed,0f);
        cam.transform.position += new Vector3(0f,Input.GetAxis("Vertical")*-zoomSpeed,0f);
        clampCamera();
        
        cam.transform.LookAt(this.transform);
    }

    void clampCamera()
    {
        if (cam.transform.position.y < cameraMinZoom)
        {
            cam.transform.position = new Vector3(cam.transform.position.x,cameraMinZoom,cam.transform.position.z);
        }
        if (cam.transform.position.y > cameraMaxZoom)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cameraMaxZoom, cam.transform.position.z);
        }
    }
}
