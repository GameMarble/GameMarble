using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float rotationSpeed = 45.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
            CameraRotation();
    }

    // Mouse hareketi ile Main Camera'nýn Y ekseni etrafýnda rotasyonu
    public void CameraRotation()
    {
        if(Input.GetAxis("Mouse X") > 0)
            transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
        else if (Input.GetAxis("Mouse X") < 0)
            transform.RotateAround(Vector3.zero, Vector3.up, -rotationSpeed * Time.deltaTime);
    }
}
