using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float rotationSpeed = 45.0f;

    public void Update()
    {
        // Mouse hareketi ile Main Camera'nýn Y ekseni etrafýnda rotasyonu

        if(Input.GetAxis("Mouse X") > 0)
            transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
        else if (Input.GetAxis("Mouse X") < 0)
            transform.RotateAround(Vector3.zero, Vector3.up, -rotationSpeed * Time.deltaTime);
    }
}
