using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Movement : NetworkBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(new Vector3(0.01f, 0, 0));
       /* if(Input.GetKeyDown(KeyCode.B))
        {
            ColourChange();
        }*/

    }

}
