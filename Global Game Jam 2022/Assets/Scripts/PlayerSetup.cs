using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkManager
{

  //  public static List<PlayerSetup> ActivePlayers = new List<PlayerSetup>();
  //  int activePlayersSize = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void OnStartClient()
    {
        if (isClientOnly)
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            CmdSetCharacters(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* if (!isLocalPlayer)
             return;

         if (ActivePlayers.Count > activePlayersSize)
         {
             cmdSetCharacters()

         }*/


    }

    [Command(requiresAuthority = false)]
    public void CmdSetCharacters(GameObject thisgameobject)
    {
       //if(isServer)
       // thisgameobject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
    }



}
