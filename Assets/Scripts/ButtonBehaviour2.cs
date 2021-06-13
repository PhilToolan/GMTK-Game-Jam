using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour2 : MonoBehaviour
{

    public GameObject light;
    public GameObject light2;

    [SerializeField] private Transform targetA, targetB, targetA2, targetB2;
    public GameObject platform;
    public GameObject platform2;
    private float speed = 1f; 
    private bool switching = false;
    private bool switching2 = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            light.SetActive(true);
            light2.SetActive(true);
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


            if (!switching2)
            {
                platform2.transform.position = Vector2.MoveTowards(platform2.transform.position, targetA2.position, speed * Time.deltaTime); 
            }
            else
            {
                platform2.transform.position = Vector2.MoveTowards(platform2.transform.position, targetB2.position, speed * Time.deltaTime);
            }

            if ( platform2.transform.position == targetB2.position)
            {
                switching2 = false;
            }
            else if ( platform2.transform.position == targetA2.position)
            {
                switching2 = true;
            }

        }

        if (collision.gameObject == Player2.Instance.gameObject)
        {
            light.SetActive(true);
            light2.SetActive(true);

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


            if (!switching2)
            {
                platform2.transform.position = Vector2.MoveTowards(platform2.transform.position, targetA2.position, speed * Time.deltaTime); 
            }
            else
            {
                platform2.transform.position = Vector2.MoveTowards(platform2.transform.position, targetB2.position, speed * Time.deltaTime);
            }

            if ( platform2.transform.position == targetB2.position)
            {
                switching2 = false;
            }
            else if ( platform2.transform.position == targetA2.position)
            {
                switching2 = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            light.SetActive(false);
            light2.SetActive(false);
        }
        if (collision.gameObject == Player2.Instance.gameObject)
        {
            light.SetActive(false);
            light2.SetActive(false);
        }
    }
}
