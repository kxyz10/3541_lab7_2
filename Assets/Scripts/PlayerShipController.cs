using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShipController : MonoBehaviour
{

    public float cameraSensitivity = 1.0f;
    public float frameSize = 20.0f;
    public float moveSpeed = 50.0f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera camera;
    CharacterController shipController;
    public StatTracker statTracker;



    void Start()
    {
        camera = Camera.main;
        shipController = GetComponent<CharacterController>();
        shipController.detectCollisions = false;
    }

    void Update()
    {
        bool gameEnd;
        gameEnd = statTracker.trackTime();
        if(!gameEnd)
        {
            // mouse movement
            float cameraX = Input.GetAxis("Mouse X") * cameraSensitivity;
            float cameraY = Input.GetAxis("Mouse Y") * cameraSensitivity;
            yRotation += cameraX;
            xRotation -= cameraY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            camera.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

            // spaceship movement
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float forward = 0.0f;
            if (Input.GetKey(KeyCode.Space))
            {
                forward = 1;
            }
            if (transform.position.x > frameSize)
            {
                shipController.Move(new Vector3(-1.0f, 0, 0));
                //transform.position = new Vector3(9.9f, transform.position.y, transform.position.z);
                Debug.Log(":Out of bounds");
            }
            if (transform.position.x < -frameSize)
            {
                shipController.Move(new Vector3(1.0f, 0, 0));
                //transform.position = new Vector3(-9.9f, transform.position.y, transform.position.z);
                Debug.Log("Out of bounds");
            }
            if (transform.position.y > frameSize)
            {
                shipController.Move(new Vector3(0, -1.0f, 0));
                //transform.position = new Vector3(transform.position.x, 9.9f, transform.position.z);
                Debug.Log("Out of bounds");
            }
            if (transform.position.y < -frameSize)
            {
                shipController.Move(new Vector3(0, 1.0f, 0));
                //transform.position = new Vector3(transform.position.x, -9.9f, transform.position.z);
                Debug.Log("Out of bounds");
            }
            shipController.Move((Vector3.right * horizontal + Vector3.up * vertical + Vector3.forward * forward) * Time.deltaTime * moveSpeed);
        }
        else
        {
            Debug.Log("Game end");
            Time.timeScale = 0;
            SceneManager.LoadScene("EndScreen");
        }
    }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Debug.Log("Collision Detected");
    //}
}