using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    Rigidbody2D rb;
    public Animator animator;

    public Vector2 targetVelocity;
    public GameObject playerGun;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;

    Vector3 mousePosition;

    //should encapsulate
    public float playerAccel;
    public float playerMaxSpeed;

    public Sprite dog;
    public Sprite cat;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!isClientOnly && hasAuthority)
        {
            GetComponent<SpriteRenderer>().sprite = dog;
            Camera.main.transform.parent = gameObject.transform;
        }
        else if (!isClientOnly && !hasAuthority)
        {
            GetComponent<SpriteRenderer>().sprite = cat;
        }
        else if (isClientOnly && hasAuthority)
        {
            GetComponent<SpriteRenderer>().sprite = cat;
            Camera.main.transform.parent = gameObject.transform;
        }
        else if (isClientOnly && !hasAuthority)
        {
            GetComponent<SpriteRenderer>().sprite = dog;
        }


    }

    // Update is called once per frame
    void Update()
    {

        Rotate();

        KeyPress();

        animator.SetFloat("Speed", rb.velocity.magnitude);


    }

    private void KeyPress()
    {
        targetVelocity.y = (Input.GetAxis("Vertical"));
        targetVelocity.x = (Input.GetAxis("Horizontal"));

        Move();

        if (Input.GetMouseButtonDown(0) && hasAuthority)
        {
            cmdFire();
        }
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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = 0;

        Debug.DrawLine(transform.position, mousePosition, Color.red);
        //Debug.Log("MouseX = " + mousePosition.x + " MouseY = " + mousePosition.y);

        //rotate
        Vector3 gunPos = playerGun.transform.position;
        gunPos.z = 0;

        Quaternion targetRot = Quaternion.Euler(mousePosition - gunPos);

        playerGun.transform.right = Vector3.Lerp(playerGun.transform.right, mousePosition - transform.position, Time.deltaTime);
    }

    [Command(requiresAuthority = false)]
    void cmdFire()
    {
        if (hasAuthority)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            NetworkServer.Spawn(bullet);
        }

        else
        {
            GameObject bullet = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
            NetworkServer.Spawn(bullet);
        }
        //projectile.firePoint = firePoint;
        //rpcFire(move);

        //screen shake
        Camera.main.GetComponent<Animator>().Play("Camera_Shake");

    }



}
