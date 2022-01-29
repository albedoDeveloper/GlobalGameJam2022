using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public GameObject explosionPrefab;
    Rigidbody2D rb;
    public float bulletForce = 20f;
    public Transform firePoint;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        Travel();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Travel()
    {
        rb.velocity = transform.right * bulletForce;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("I have collided with " + collision.transform.gameObject.name);
            SelfDestruct();
        }

    }

    private void SelfDestruct()
    {
        rb.velocity = rb.velocity * 0;
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Animator anim = explosion.GetComponent<Animator>();
        anim.Play("Explosion");
        Debug.Log("Shoudl create xplosion prefab");
        Destroy(explosion, .30f);
        Destroy(this.gameObject);

    }
}
