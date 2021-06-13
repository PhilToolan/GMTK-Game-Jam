using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject camera;
    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            camera.SetActive(true);
            menu.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        camera.SetActive(false);
        menu.SetActive(false);
    }
}
