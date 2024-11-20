using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    public Camera mainCamera;
    public int currentCameraIndex = -1;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera c in cameras)
        {
            c.gameObject.SetActive(false);
        }

        mainCamera.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
             if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchCamera(i);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ReturnToMainView();
        }
    }

    public void SwitchCamera(int index)
    {
        if(currentCameraIndex >= 0)
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(false);
        cameras[index].gameObject.SetActive(true);
        currentCameraIndex = index;
    }

    public void ReturnToMainView()
    {
        if (currentCameraIndex >= 0)
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(true);
        currentCameraIndex = -1;
    }
}
