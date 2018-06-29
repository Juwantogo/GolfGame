using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev2 : MonoBehaviour {

    [SerializeField]
    private GameObject ball;
    public Rigidbody myRig;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            myRig = ball.GetComponent<Rigidbody>();
            myPlayerController Level  = ball.GetComponent<myPlayerController>();
            Level.Level = 2;
            ball.transform.position = new Vector3(189.87f, 2.81f, 338.14f);
            myRig.velocity = Vector3.zero;
        }
    }
}
