using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour {

    public GameObject anim;

    private bool Taken;

    private float timea;
    private float tima = 0;

    public void Update()
    {
        if (Taken)
        {
            tima += Time.deltaTime;
            if (tima > 0.2)
            {
                Destroy(this.gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetActive(true);
            transform.GetComponent<SpriteRenderer>().enabled = false;
            anim.GetComponent<Animator>().SetBool("isTaken", true);
        }

        Taken = true;

    }


}
