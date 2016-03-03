using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 1f;

    Vector3 movement;
    Vector3 rotationVector;
    Rigidbody rb;

    //New Mouse Rotating System
    private Quaternion targetRotation;
    public float rotationSpeed = 1f;
    int floorMask;
    float camRayLength = 100f;

    [Header("Check for using gamepad")]
    public string OnClickText = "";
    public bool useGamePad = true;

    //Camera
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void Start()
    {
        //if (Input.GetJoystickNames().Length > 0)
        //{
        //    useGamePad = true;
        //}
        //else
        //{
        //    useGamePad = false;
        //}
    }

    void Update()
    {
        //if (Input.GetJoystickNames().Length > 0)
        //{
        //    isGamepadConnected = true;
        //}
        //else
        //{
        //    isGamepadConnected = false;
        //}

        if (useGamePad == true)
        {
            float h = Input.GetAxisRaw("Horizontal_Rotate");
            float v = -Input.GetAxisRaw("Vertical_Rotate");
            RotatePlayer(h, v);
        }

        //Debug.Log(Input.GetJoystickNames().Length);

        //float h = Input.GetAxisRaw("Mouse X");
        //float v = -Input.GetAxisRaw("Mouse Y");
        //RotatePlayer(h, v);      
        
        //MouseRotate();

    }

    void FixedUpdate()
    {
        if(useGamePad == false)
        {
            RotatePlayerWithMouse();
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        MovePlayer(h, v);       
    }

    void MovePlayer(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void RotatePlayer(float h, float v)
    {
        rotationVector.Set(h, 0f, v);
        rotationVector = rotationVector.normalized;
        transform.LookAt(transform.position + rotationVector, Vector3.up);
    }

    void RotatePlayerWithMouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //transform.rotation = newRotation;
            rb.MoveRotation(newRotation);
        }
    }

    //void MouseRotate()
    //{
    //
    //    Vector3 mousePos = Input.mousePosition;
    //    mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
    //    targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0f, transform.position.y));
    //    transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
    //
    //}
}
