using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public GameObject[] _spawnNodes;

    public GameObject _crystalPrefab;

    private Stack<int> _spentNumbers = new Stack<int>();

    public int _crystalCount = 6;
        
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _crystalCount; i++)
        {
            bool crystalSpawned = false;

            do
            {
                int randNum = Random.Range(0, _spawnNodes.Length);

                foreach (var item in _spentNumbers)
                {
                    if (item != randNum)
                    {
                        _spentNumbers.Push(randNum);
                        crystalSpawned = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                if (_spentNumbers.Count < 1)
                {
                    _spentNumbers.Push(randNum);
                    crystalSpawned = true;
                }

                if (crystalSpawned)
                {
                    Instantiate(_crystalPrefab, _spawnNodes[randNum].transform.position, Quaternion.identity);
                    break;
                }
            } while (true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
