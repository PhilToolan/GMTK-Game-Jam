using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public Transform playerTransform;
    
    public Transform targetTransform;
    Vector3 tempVec3 = new Vector3();

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     transform.position = transform.position + new Vector3(0, playerTransform.position.y, 0);
    // }

    void LateUpdate() 
    {
        tempVec3.x = this.transform.position.x;
        tempVec3.y = targetTransform.position.y;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;
    }
}
