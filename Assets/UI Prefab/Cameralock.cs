using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameralock : MonoBehaviour
{
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera.GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
