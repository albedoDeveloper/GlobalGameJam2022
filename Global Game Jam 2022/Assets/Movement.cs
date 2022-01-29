using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            gameObject.transform.Translate(new Vector3(0.1f, 0, 0));
        if(Input.GetKeyDown(KeyCode.B))

    }
}
