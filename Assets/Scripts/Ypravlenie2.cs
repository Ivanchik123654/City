using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ypravlenie2 : MonoBehaviour
{
    public float speed;
    public float maxSpeed = 27.0f;
    public float rotationSpeed = 75.0f;
    public float maxReversSpeed = -20.0f; //макс скорость назад
    public float acceleration = 20.0f; //ускорение
    public float deceleration = 10.0f; //замедление
    private Vector3 startPosition;
    private Quaternion startRotation;
    public GameManager manager;
    void Start()
    {
        startPosition = transform.position;//сохраняем нач позицию игрока
        startRotation = transform.rotation;
    }


    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (verticalInput > 0)
        {
            speed = Mathf.MoveTowards(speed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            speed = Mathf.MoveTowards(speed, maxReversSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
        if (Input.GetKeyDown(KeyCode.Tab) || OutOfBounds())
        {
            ResetToStartPosition();
        }
    }
    bool OutOfBounds()
    {
        if (transform.position.y < -13 || transform.position.y > 30) // || - это или, && - это и 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetToStartPosition()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        speed = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            Debug.Log("CheckPoint " + other.gameObject.name);
            manager.CheckPointDostigli(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish " + other.gameObject.name);
            manager.DostigliFinisha(other.gameObject);
        }
    }
}