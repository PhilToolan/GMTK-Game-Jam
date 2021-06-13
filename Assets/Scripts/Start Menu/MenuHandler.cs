using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] private string level1;
    [SerializeField] private string controls;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1);
    }

    public void LoadControls()
    {
        SceneManager.LoadScene(controls);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}