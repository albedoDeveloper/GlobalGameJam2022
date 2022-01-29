using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    Rigidbody2D rb;

    public Vector2 targetVelocity;
    public GameObject playerGun;

    //should encapsulate
    public float playerAccel;
    public float playerMaxSpeed;





    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
            return;
        rb = GetComponent<Rigidbody2D>();


        Camera.main.GetComponent<CameraStart>().SetChild(gameObject);
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

    private void Rotate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Quaternion targetRot = Quaternion.Euler(mousePos - this.gameObject.transform.position);
        float targetAngle = Vector2.Angle(mousePos, this.gameObject.transform.position);
        Debug.Log("mouse X = " + mousePos.x + "mouse Y = " + mousePos.y + "target angle ==" + targetAngle);

        playerGun.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime);





    }

    private Vector3 FindMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
