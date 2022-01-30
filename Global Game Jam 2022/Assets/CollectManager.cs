using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class CollectManager : NetworkBehaviour
{
    [SyncVar(hook = nameof(UpdateText))]
    public int numberOfcrystals = 0;

    public TextMeshProUGUI text;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfcrystals == 1)
            Application.Quit();
    }

    void UpdateText(int old, int newint)
    {
        text.text = newint.ToString();
    }

}
