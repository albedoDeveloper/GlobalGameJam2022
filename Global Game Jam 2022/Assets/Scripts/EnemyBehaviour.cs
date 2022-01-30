using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject playerTarget;
    public float detectionRadius = 25f;
    public float enemySpeed = 2f;

    public float health = 5f;

    Rigidbody2D rb;
    List<Collider2D> hitColliders = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            SelfDestruct();
        }

        if (playerTarget)
        {
            SeekPlayer();
        }

    }

    private void FixedUpdate()
    {
        CheckForPlayer();
    }

    void CheckForPlayer()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        if (colliders.Length > 0)
        {
            foreach (Collider2D col in colliders)
            {
                //Debug.Log("Object " + col.name + " detected");
                if (col.GetComponent<PlayerMovement>())
                {
                    Debug.Log("PLAYER " + col.name + " detected");
                    playerTarget = col.gameObject;
                }
            }
        }

    }

    void SeekPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.transform.position, enemySpeed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        health--;
    }

    void SelfDestruct()
    {
        Destroy(this.gameObject, 0.25f);
    }
}
