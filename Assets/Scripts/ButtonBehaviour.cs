using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public GameObject light;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            light.SetActive(true);
        }
    }
}
