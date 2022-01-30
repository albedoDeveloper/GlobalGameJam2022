using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LampPlacer : NetworkBehaviour
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
            CmdSpawnLampAll(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane);

            GameObject.Find("BuildController").GetComponent<BuildController>().ResetTimer();

            NetworkServer.Destroy(gameObject);
        }

        transform.position = _cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane)
        );
    }

    [Command(requiresAuthority = false)]
    public void CmdSpawnLampAll(float x, float y, float z)
    {
        GameObject var = Instantiate(
                _lampPrefab,
                _cam.ScreenToWorldPoint(
                new Vector3(x, y, z)
                ),
                Quaternion.identity
            );
        NetworkServer.Spawn(
            var
        );
    }
}
