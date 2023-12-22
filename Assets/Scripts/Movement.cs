using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Movement : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    private Rigidbody rb;

    public float moveDistance = 0.1f;
    public float turnSpeed = 100f;

    public GameObject LaptopCanvas;
    public GameObject Laptop2Canvas;

    public bool doorUnlocked;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 10))
            {
                if(hit.collider.gameObject.CompareTag("Laptop"))
                {
                    LaptopCanvas.SetActive(true);
                }
                if(hit.collider.gameObject.CompareTag("Laptop2"))
                {
                    Laptop2Canvas.SetActive(true);
                }
            }
            MoveInCameraDirection();
        }

        if (Input.GetMouseButton(1))
        {
            Turn();
        }
    }

    void MoveInCameraDirection()
    {

        // Get the camera's forward vector (direction the camera is facing)
        Vector3 cameraForward = Camera.main.transform.forward;

        // Calculate the new position by moving along the camera's forward vector
        Vector3 newPosition = rb.position + cameraForward * moveDistance;

        // Set the cursor's new position
        //transform.position = newPosition;
        rb.MovePosition(newPosition);
    }

    void Turn()
    {
        // Get the mouse movement on the x-axis
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        // Rotate the player around the y-axis based on mouse movement
        transform.Rotate(Vector3.up, mouseX * turnSpeed * Time.deltaTime);
        // Rotate the player around the x-axis based on mouse Y movement
        transform.Rotate(Vector3.left, mouseY * turnSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Exit"))
        {
           if(doorUnlocked==true)
            {
                uiText.text = "You escaped.\nCongratulations!";
            }
        }
    }

}
