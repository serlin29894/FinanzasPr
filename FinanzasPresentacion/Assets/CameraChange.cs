using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {


    public GameObject forward = null;
    public GameObject backwards = null;
    public PlayerControl mPlayer;
    public CameraControl cam;



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!mPlayer.backwards)
        {
            cam.target = forward;
        }
        else if (mPlayer.backwards)
        {
            cam.target = backwards;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.target = mPlayer.gameObject;
    }

}
