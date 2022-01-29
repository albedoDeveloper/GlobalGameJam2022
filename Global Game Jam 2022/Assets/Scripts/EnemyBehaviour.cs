using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject playerTarget;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        if (playerTarget == null)
        {
            playerTarget = FindObjectOfType<PlayerMovement>().gameObject;
        }

    }
}
