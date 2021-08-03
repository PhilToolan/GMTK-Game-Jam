using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public GameObject light;

    [SerializeField] private Transform targetA, targetB;
    public GameObject platform;

    [SerializeField] private float speed = 1f; 
    private bool switching = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            light.SetActive(true);
            if (!switching)
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, targetA.position, speed * Time.deltaTime); 
            }
            else
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, targetB.position, speed * Time.deltaTime);
            }

            if ( platform.transform.position == targetB.position)
            {
                switching = false;
            }
            else if ( platform.transform.position == targetA.position)
            {
                switching = true;
            }

        }

        if (collision.gameObject == Player2.Instance.gameObject)
        {
            light.SetActive(true);
            if (!switching)
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, targetA.position, speed * Time.deltaTime); 
            }
            else
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, targetB.position, speed * Time.deltaTime);
            }

            if ( platform.transform.position == targetB.position)
            {
                switching = false;
            }
            else if ( platform.transform.position == targetA.position)
            {
                switching = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            light.SetActive(false);
        }
        if (collision.gameObject == Player2.Instance.gameObject)
        {
            light.SetActive(false);
        }
    }
}
