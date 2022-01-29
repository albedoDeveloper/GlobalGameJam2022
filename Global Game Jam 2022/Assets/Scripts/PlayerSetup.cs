using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{

   public List<GameObject> ActivePlayers = new List<GameObject>();
  //  int activePlayersSize = 0;

    // Start is called before the first frame update
    void Start()
    {
    }


    public override void OnStartClient()
    {
        if (isClientOnly) {
            CmdSetCharacters();

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
    public void CmdSetCharacters()
    {
        var a = Instantiate(ActivePlayers[0]);

        a.GetComponent<PlayerMovement>().rb = a.GetComponent<Rigidbody2D>();

        var b = Instantiate(ActivePlayers[1]);

        b.GetComponent<PlayerMovement1>().rb = b.GetComponent<Rigidbody2D>();

        NetworkServer.Spawn(a);

        NetworkServer.Spawn(b);
    }



}
