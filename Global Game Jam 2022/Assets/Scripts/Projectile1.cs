using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
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
        //Physics.IgnoreLayerCollision(6, 7, true);


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
        if ((collision.gameObject.layer != LayerMask.NameToLayer("Player") || collision.gameObject.layer != LayerMask.NameToLayer("Projectile")) && collision.gameObject.tag != "enemyred")
        {
            //Debug.Log("I have collided with " + collision.transform.gameObject.name);

            if (collision.gameObject.GetComponent<EnemyBehaviour>())
            {
                collision.gameObject.GetComponent<EnemyBehaviour>().TakeDamage();
            }

            SelfDestruct();
        }

        else if (collision.gameObject.tag == "enemyred")
            SelfDestruct();

    }

    private void SelfDestruct()
    {
        rb.velocity = rb.velocity * 0;
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Animator anim = explosion.GetComponent<Animator>();
        anim.Play("Explosion2");
        Destroy(explosion, .30f);
        Destroy(this.gameObject);

    }
}
