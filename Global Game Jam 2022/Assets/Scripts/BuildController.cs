using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BuildController : NetworkBehaviour
{
    public GameObject _lightPlacer;
    public int _timer = 10;
    public LampGIU gui;
    bool ready = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Tick");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _timer < 1 && ready)
        {
            ready = false;
            CmdSpawnLampSpawner();
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSpawnLampSpawner()
    {
        GameObject obj = Instantiate(_lightPlacer);
        NetworkServer.Spawn(obj);
    }

    public void ResetTimer()
    {
        _timer = 10;
        ready = true;
        StartCoroutine("Tick");
    }

    IEnumerator Tick()
    {
        do
        {
            _timer--;
            gui.UpdateTime(_timer);
            yield return new WaitForSeconds(1);
        } while (_timer >= 0);
    }
}
