using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {


    public GameObject target;
    public float distanceToCamera;
    public float heightToCamera;
    [Range(0.01f, 0.5f)]
    public float smoothSpeed;

    private Vector3 destination;

    public void LateUpdate ()
    {
        distanceToCamera += Input.mouseScrollDelta.x  + Input.mouseScrollDelta.y ;

        if (Input.GetKey(KeyCode.W))
        {
            heightToCamera += 0.1f;
        }else if (Input.GetKey(KeyCode.S))
        {
            heightToCamera -= 0.1f;
        }
      
        destination = new Vector3(target.transform.position.x , target.transform.position.y + heightToCamera, target.transform.position.z - distanceToCamera);

        transform.position = Vector3.Lerp(transform.position, destination, smoothSpeed);
        
    }


}
