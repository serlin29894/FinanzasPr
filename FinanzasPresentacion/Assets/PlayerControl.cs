using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


    public float speed;
    public float jumpForce;

    private Vector3 direction;
    private Rigidbody mRg;


    public void Start()
    {
        mRg = GetComponent<Rigidbody>();
    }

    public void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            direction = transform.forward * -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = transform.forward;
        }
        else
        {
            direction = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mRg.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        transform.position += direction * speed * Time.deltaTime;

        
    }


}
