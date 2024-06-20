using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ypravlenie : MonoBehaviour
{
    public float speed = 13.5f;
    public int rotationSpeed = 65;
    public float verticalInput;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ну привет");
        // Debug.Log(rotationSpeed);
        string privetstwie = "Hello mir";
        Debug.Log(privetstwie);
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log("Я крч из Update");
        //transform.Translate(new Vector3(0, 0, 0.001f));
        //transform.Translate(Vector3.forward*speed*Time.deltaTime); //vector3.forward это движение вперед, Time.deltatime это время одного кадра
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward*speed*Time.deltaTime); 
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        //}

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
    }
}