using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev1 : MonoBehaviour {
    [SerializeField]
    private GameObject ball;
    public Rigidbody myRig;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            myRig = ball.GetComponent<Rigidbody>();
            myPlayerController Level = ball.GetComponent<myPlayerController>();
            Level.Level = 1;
            ball.transform.position = new Vector3(261f,2.03f,233f);
            myRig.velocity = Vector3.zero;
        }
    }
}
