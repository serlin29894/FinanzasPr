using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour {


    public float speed;
    public float jumpForce;
    public float limitDistance = 5;
    public float maxTime = 0.2f;

    private Vector3 direction;
    private Rigidbody2D mRg;
    private SpriteRenderer mSp;
    private Animator anim;
    private float acTime = 0;

    private bool grounded = true;

    [NonSerialized]
    public bool forward;

    public void Start()
    {
        mRg = GetComponent<Rigidbody2D>();
        mSp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {

        

        if (Input.GetKey(KeyCode.A))
        {
            forward = mSp.flipX = true;
            direction = transform.right * -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            forward = mSp.flipX = false;
            direction = transform.right;
        }
        else
        {

            direction = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            mRg.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }


        if (grounded)
        {
            anim.SetBool("Grounded", true);
            acTime = 0;
        }
        else
        {
            CheckGround();
            anim.SetBool("Grounded", false);
        }


        transform.position += direction * speed * Time.deltaTime;   
        
    }


    public void CheckGround()
    {
        Vector2 direction = Vector2.down;
        RaycastHit2D hit;

        hit = Physics2D.Raycast((Vector2)transform.position, direction,100, 7);

        acTime += Time.deltaTime;
        if (acTime > maxTime)
        {
            if (hit)
            {
                if ((hit.point - (Vector2)transform.position).magnitude < limitDistance)
                {
                    grounded = true;
                }
            }
        }
    }


}
