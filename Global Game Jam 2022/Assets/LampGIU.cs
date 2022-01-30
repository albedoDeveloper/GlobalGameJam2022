using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LampGIU : MonoBehaviour
{
    public BuildController buildController;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTime(int time)
    {
        text.text = time.ToString();
        if (time < 1)
        {
            text.text = "Ready";
        }
    }
}
