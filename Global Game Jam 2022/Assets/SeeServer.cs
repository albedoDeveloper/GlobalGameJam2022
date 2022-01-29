using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SeeServer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SeeServ()
    {
        if (isClientOnly)
            return 0;
        else
            return 1;

    }
}
