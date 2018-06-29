using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCheck : MonoBehaviour {

    [SerializeField]
    private GameObject ball;
    public Rigidbody myRig;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            myRig = ball.GetComponent<Rigidbody>();
            myPlayerController Level = ball.GetComponent<myPlayerController>();
            if (Level.Level == 1)
            {
                ball.transform.position = new Vector3(261f, 2.03f, 233f);
                myRig.velocity = Vector3.zero;
            }
            if (Level.Level == 2)
            {
                ball.transform.position = new Vector3(189.87f, 2.81f, 338.14f);
                myRig.velocity = Vector3.zero;
            }
            if (Level.Level == 3)
            {
                ball.transform.position = new Vector3(155.67f, 5.47f, 266.91f);
                myRig.velocity = Vector3.zero;
            }
        }
    }
}
