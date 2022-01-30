using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Collect : NetworkBehaviour
{
    // Start is called before the first frame update

    public CollectManager manager;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "crystal")
        {
            //cmdCollect();
            Destroy(collision.gameObject);
            Debug.Log("fe");
        }
    }

    [Command(requiresAuthority = false)]
    void cmdCollect()
    {
        var manager = GameObject.Find("Canvas").GetComponent<CollectManager>();
        manager.numberOfcrystals++;

    }
}
