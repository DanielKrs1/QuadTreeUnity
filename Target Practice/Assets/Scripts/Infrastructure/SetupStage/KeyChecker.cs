using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChecker : MonoBehaviour
{

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {


        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * 50);

     

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * 50);

        float zoomInput = Input.GetAxis("Zoom");

        cam.orthographicSize += zoomInput;

        if (cam.orthographicSize < 20) { cam.orthographicSize = 20; }
        if (cam.orthographicSize > 100) { cam.orthographicSize = 100; }


    }
}
