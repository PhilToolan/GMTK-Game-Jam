using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

	public Rigidbody2D hook;

	public GameObject linkPrefab;
    public GameObject end;

	public Weight weigth;

	public int links = 7;

	public LineRenderer line;
	List<GameObject> children = new List<GameObject>();

    private int j = 0;

	void Start()
	{
		line = gameObject.GetComponent<LineRenderer>();
		GenerateRope();
		GetLinePositions();
	}

	void GenerateRope()
	{

		//Segments for physics
		Rigidbody2D previousRB = hook;
		for (int i = 0; i < links; i++)
		{
			GameObject link = Instantiate(linkPrefab, transform);
			HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
			joint.connectedBody = previousRB;

			if (i < links - 1)
			{
				previousRB = link.GetComponent<Rigidbody2D>();
			}
			else
			{
				weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
			}


		}

        //Line Segments
		line.positionCount = links + 1;
	}

	public void GetLinePositions()
    {

		foreach (Transform child in this.gameObject.transform)
		{
			children.Add(child.gameObject);
		}

	}

	void LateUpdate()
	{
		if (line.enabled)
        {
            j = 0;
			for (int i = 0; i < links; i++)
			{
				line.SetPosition(i, children[i].transform.position);
                j++;
			}
            line.SetPosition(j, end.transform.position);
		}

	}

}
