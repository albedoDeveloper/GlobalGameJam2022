using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyPress();
        Rotate();

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
        Vector3 mousePos = FindMousePosition();

        //Quaternion targetRot = Quaternion.Euler(mousePos - this.gameObject.transform.position);
        float targetAngle = Vector2.Angle(mousePos, this.gameObject.transform.position);
        Debug.Log("target angle ==" + targetAngle);

        playerGun.transform.rotation = Quaternion.Euler(0, 0, targetAngle);





    }

    private Vector3 FindMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);



    }
}
