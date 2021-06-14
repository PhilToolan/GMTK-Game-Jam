using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{


    public LineRenderer rope1;
    public LineRenderer rope2;

    Color c = Color.red;
    Color32 c1 = new Color32 (236, 200, 58, 255);
    Color32 c2 = new Color32 (67, 125, 148, 255);




    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            rope1.SetColors(c, c);
        }
        if (collision.gameObject == Player2.Instance.gameObject)
        {
            rope2.SetColors(c, c);     
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            rope1.SetColors(c2, c2);
        }
        if (collision.gameObject == Player2.Instance.gameObject)
        {
            rope2.SetColors(c1, c1);     
        }
    }

}
