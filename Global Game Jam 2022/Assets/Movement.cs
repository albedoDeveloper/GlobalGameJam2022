using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Movement : NetworkBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(new Vector3(0.01f, 0, 0));
       /* if(Input.GetKeyDown(KeyCode.B))
        {
            ColourChange();
        }*/

    }

}
