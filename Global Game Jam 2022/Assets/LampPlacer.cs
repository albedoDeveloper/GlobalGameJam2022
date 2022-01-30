using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LampPlacer : MonoBehaviour
{
    public GameObject _lampPrefab;
    public Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_lampPrefab,
                _cam.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane)
                 )
                , Quaternion.identity);
        }

        transform.position = _cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane)
        );
    }
}
