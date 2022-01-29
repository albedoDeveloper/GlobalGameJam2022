using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    public Rigidbody2D rb;

    public Vector2 targetVelocity;
    public GameObject playerGun;


    Vector3 mousePosition;

    //should encapsulate
    public float playerAccel;
    public float playerMaxSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        if (!isLocalPlayer)
            return;
        rb = this.GetComponent<Rigidbody2D>();


        Camera.main.GetComponent<CameraStart>().SetChild(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClientOnly)
        {
            Rotate();

            KeyPress();
        }
    }

    private void KeyPress()
    {
        targetVelocity.y = (Input.GetAxis("Vertical"));
        targetVelocity.x = (Input.GetAxis("Horizontal"));

        Move();
    }

    private void Move()
    {
        if (rb.velocity.magnitude <= playerMaxSpeed)
        {
            targetVelocity.Normalize();
            //drift
            //rb.velocity += targetVelocity;
            //no drift requires higher accel value
            rb.velocity = targetVelocity * playerAccel;
        }
    }

    void Rotate()
    {
        Camera.main.ResetWorldToCameraMatrix();
        //find mouse pos
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 mousePosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Vector3 mousePosition = Camera.main.WorldToViewportPoint(Input.mousePosition);
        //Vector3 mousePosition = Camera.main.ViewportToWorldPoint(Input.mousePosition);

        mousePosition.z = 0;

        Debug.DrawLine(transform.position, mousePosition, Color.red);
       // Debug.Log("MouseX = " + mousePosition.x + " MouseY = " + mousePosition.y);



        //rotate
        Vector3 gunPos = playerGun.transform.position;
        gunPos.z = 0;

        Quaternion targetRot = Quaternion.Euler(mousePosition - gunPos);

        playerGun.transform.right = Vector3.Lerp(playerGun.transform.right, mousePosition - transform.position, Time.deltaTime);
    }

    private void Start()
    {
        if (isClientOnly)
        {
            playerGun.SetActive(false);
        }
    }
}
