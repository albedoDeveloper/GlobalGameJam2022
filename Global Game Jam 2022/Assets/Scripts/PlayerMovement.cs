using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    Rigidbody2D rb;

    public Vector2 targetVelocity;
    public GameObject playerGun;


    Vector3 mousePosition;

    //should encapsulate
    public float playerAccel;
    public float playerMaxSpeed;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!isLocalPlayer)
            return;
        Camera.main.GetComponent<CameraStart>().SetChild(gameObject);

        if (isServer)
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }

        else if (isClientOnly)
            GetComponent<Renderer>().material.color = new Color(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        KeyPress();

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
        Debug.Log("MouseX = " + mousePosition.x + " MouseY = " + mousePosition.y);



        //rotate
        Vector3 gunPos = playerGun.transform.position;
        gunPos.z = 0;

        Quaternion targetRot = Quaternion.Euler(mousePosition - gunPos);

        playerGun.transform.right = Vector3.Lerp(playerGun.transform.right, mousePosition - transform.position, Time.deltaTime);
    }
}
