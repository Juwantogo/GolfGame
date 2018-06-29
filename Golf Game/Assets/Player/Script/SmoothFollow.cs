using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class SmoothFollow : MonoBehaviour
    {

        // The target we are following
        [SerializeField]
        private Transform target;
        public GameObject ball;
        // The distance in the x-z plane to the target
        //[SerializeField]
        private float distance = 1f;
        // the height we want the camera to be above the target
        [SerializeField]
        private float height = 5.0f;
        private float olddis = 1f;
        private float X = 0.0f;
        private float Y = 0.0f;

        [SerializeField]
        private float rotationDamping;
        [SerializeField]
        private float heightDamping;

        // Use this for initialization
        void Start()
        {
            X += Input.GetAxis("Mouse X") * 10;
            Y += Input.GetAxis("Mouse Y");
            Y = Mathf.Clamp(Y, 30.0f, 80.0f);
            Debug.Log(X);
            Debug.Log(Y);
            distance = ((ball.transform.localScale.x) / 0.1544461f);
        }

        void Update()
        {
            //if (Input.GetMouseButton(0))
            //{
            // RaycastHit hit;
            // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if (Input.GetMouseButtonDown(0))
            //{
            //   if (Physics.Raycast(ray, out hit))
            //   {
            //     if (hit.transform.name == "Sphere")
            //     { //Debug.DrawLine(new Vector3(0, 0, 0), hit.point, Color.red); 
            //        Debug.Log("dont update");
            //   }

            //   }

            // }
            // }
            // else
            //{
            if (Input.GetKey("space"))
            {
                X += Input.GetAxis("Mouse X") * 10;
                Y += Input.GetAxis("Mouse Y") * 10;
                Y = Mathf.Clamp(Y, 30.0f, 80.0f);
                //Debug.Log("update");
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                distance -= Input.GetAxis("Mouse ScrollWheel") * ((ball.transform.localScale.x) / 0.1544461f);
                Debug.Log(distance);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                distance -= Input.GetAxis("Mouse ScrollWheel") * ((ball.transform.localScale.x) / 0.1544461f);
                Debug.Log(distance);
            }
            distance = Mathf.Clamp(distance, ((ball.transform.localScale.x) / 0.1544461f), 6*((ball.transform.localScale.x) / 0.1544461f));
            // }

        }

        // Update is called once per frame
        void LateUpdate()
        {
            // Early out if we don't have a target
            if (!target)
                return;

            // Calculate the current rotation angles
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAnglex = X;
            var currentRotationAngle = Y;
            var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            //currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, Y, rotationDamping * Time.deltaTime);
            currentRotationAnglex = Mathf.LerpAngle(currentRotationAnglex, X, rotationDamping * Time.deltaTime);

            //Debug.Log(wantedRotationAngle);
            //Debug.Log(currentRotationAnglex);
            //Debug.Log(X);

            // Damp the height
            // currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            // Debug.Log(distance);
            // Debug.Log(olddistance);
            distance = Mathf.Lerp(distance, distance, heightDamping * Time.deltaTime);
            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(currentRotationAngle, currentRotationAnglex, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            Vector3 direction = new Vector3(0, 0, -distance);
            transform.position = target.position + currentRotation * direction;
            //transform.Rotate(currentRotation);
            //transform.position -= currentRotation * Vector3.forward * distance;

            // Set the height of the camera
            //transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);


            // Always look at the target
            transform.LookAt(target);
            olddis = distance;
        }
    }
}