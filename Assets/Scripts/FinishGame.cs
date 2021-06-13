using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private bool canFinish = false;
    private bool canFinish2 = false;

        [SerializeField] private string menu;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            canFinish = true;
        }
        if (collision.gameObject == Player2.Instance.gameObject)
        {
            canFinish2 = true;
        }
    }

    void Update()
    {
        if(canFinish && canFinish2)
        {
            SceneManager.LoadScene(menu);
        }
    }
}
