using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev3 : MonoBehaviour {
    [SerializeField]
    private GameObject ball;
    public Rigidbody myRig;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            myRig = ball.GetComponent<Rigidbody>();
            myPlayerController Level = ball.GetComponent<myPlayerController>();
            Level.Level = 3;
            ball.transform.position = new Vector3(155.67f, 5.47f, 266.91f);
            myRig.velocity = Vector3.zero;
        }
    }
}
