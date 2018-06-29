using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerController : MonoBehaviour
{
    //GameView for testing size = 1148/535 = 
    public Rigidbody myRig;
    public GameObject ball;
    public int Level = 1;
    private Vector3 start;
    private Vector3 check = new Vector3(1f, 1f, 1f);
    private Vector3 reset = new Vector3(0f, 0f, 0f);
    private Vector3 here;
    private Vector3 there;
    private Vector3 dir;
    private Vector3 direction;
    private Vector3 powerCap;
    private Color high = Color.red;
    private Color med = Color.yellow;
    private Color medlow = Color.green;
    private Color low = Color.white;
    private float power;
    private float screenmultiplier;
    private Vector3 speedstop = new Vector3(1f, 1f, 1f);
    private LineRenderer lineRenderer;
    // Use this for initialization
    void Start()
    {
        myRig = this.gameObject.GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        float grav = -9.81f * (transform.localScale.x) / 0.1544461f;
        Physics.gravity = new Vector3(0F, grav, 0F);
        Debug.Log((Screen.width));
        Debug.Log((Screen.height));
        screenmultiplier = (Screen.width * Screen.height)/ (1148f * 535f);
        Debug.Log(screenmultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButton(0))// && (myRig.velocity == Vector3.zero))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == "Sphere")
                    { //Debug.DrawLine(new Vector3(0, 0, 0), hit.point, Color.red); 
                        start = Input.mousePosition;
                        start.z = Camera.main.farClipPlane;
                        start = Camera.main.ScreenToWorldPoint(start);
                        check = start;
                        here = transform.position;
                        
                        lineRenderer.SetPosition(0, here);
                        //Debug.Log("My object is clicked by mouse"); 
                    }
                    //start is first click position
                    //check = start if sphere was the start click
                }


            }
        }
        if (power > ((transform.localScale.x) / 0.1544461f) * 20f)
        {
            lineRenderer.material.color = high;
        }
        else if (power > ((transform.localScale.x) / 0.1544461f) * 15f)
        {
            lineRenderer.material.color = med;
        }
        else if (power > ((transform.localScale.x) / 0.1544461f) * 10f)
        {
            lineRenderer.material.color = medlow;
        }
        else
        {
            lineRenderer.material.color = low;
        }

       // if (Mathf.Abs(myRig.velocity.x) < 0.1f && Mathf.Abs(myRig.velocity.y) < 0.1f && Mathf.Abs(myRig.velocity.z) < 0.1f)
        //{
          //  myRig.velocity = Vector3.zero;
        //}
        

    }

    void LateUpdate()
    {
        there = Input.mousePosition;
        there.z = Camera.main.farClipPlane;
        there = Camera.main.ScreenToWorldPoint(there);

        dir = there - here;
        power = dir.magnitude;
        power = power / 900;
        power = Mathf.Pow(power, 10);
        power = Mathf.Clamp(power, 1, 30);
        //Debug.Log(power);

        power = power * ((transform.localScale.x) / 0.1544461f);
        power = power * screenmultiplier;
       // Debug.Log(screenmultiplier);
        direction = (there - start).normalized;
        if (Input.GetMouseButtonUp(0) && (start == check)) //&& (myRig.velocity == Vector3 .zero))
        {
            //there = new position start = old position there-start

            //there = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //***dir = there - here;
            //dir = dir * 1000;
            


            //**Vector3 direction = (there - start).normalized; // normalize before setting y to 0 to get y tangent for horizontal direction** too complex 
            //direction.z = direction.y;
            //**direction.y = 0;
            //***float power = dir.magnitude / 900000;
            //******** Debug.Log(power);
            //power = Mathf.Clamp(power, 1f, 6f);
            direction.y = 0;

            //0.1544461
            //Debug.Log("scale" + transform.localScale);

              powerCap = power * -direction;
            //powerCap.z = Mathf.Clamp(powerCap.z, -20, 20);
            //powerCap.x = Mathf.Clamp(powerCap.x, -20, 20);
            Debug.Log("pC" + powerCap);
            //transform.position += direction * 5 * Time.deltaTime;
            myRig.velocity = powerCap;
            //********Debug.Log(myRig.velocity);
            //Debug.Log(start);
            start = reset;
            Debug.Log(direction);
            Debug.Log(power);
            //Debug.Log(Input.mousePosition);
            //Debug.Log(there);
            //Debug.Log(start);
            //***Debug.Log(dir.magnitude);
            Debug.Log(myRig.velocity);
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3 .zero);
        }
       // Debug.Log(myRig.velocity);

        //Debug.Log(myRig.velocity);
        //if (myRig.velocity.z < speedstop.z && myRig.velocity.x < speedstop.x) { myRig.velocity = new Vector3(0f, 0f, 0f); }
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //Debug.Log(worldPoint.x + "," + worldPoint.y + "," + worldPoint.z);
        if (Input.GetMouseButton(0) && (start == check))//&& (myRig.velocity == Vector3.zero))
        {
            //
            there.y = transform.position.y;
            Vector3 ok = (power/2.5f) * -direction + here;
            
            ok.y = there.y;
            lineRenderer.SetPosition(1, ok);
            Debug.Log(power);


        }
    }

}