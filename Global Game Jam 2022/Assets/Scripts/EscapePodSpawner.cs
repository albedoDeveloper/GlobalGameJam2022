using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EscapePodSpawner : MonoBehaviour
{
    public GameObject[] _spawnNodes;

    public GameObject _podPrefab;

    // Start is called before the first frame update
    void Start()
    {
            int randNum = Random.Range(0, _spawnNodes.Length);

            Instantiate(_podPrefab, _spawnNodes[randNum].transform.position, Quaternion.identity);
    }
}
