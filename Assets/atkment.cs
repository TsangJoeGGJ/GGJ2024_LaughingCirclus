using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class atkment : NetworkBehaviour
{

    public bool active;
    public float timer;
    public float angs;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if ((active && GameController.instance.perform) && timer <= 0)
        {
            /* if (isLocalPlayer || isServer)
             { Instantiate(bullet, transform.position, Quaternion.identity);
                 timer += 5;
                 GameController.instance.perform = false;
             }*/
         
                CmdSpwan(GameController.instance.LocalPlayermanger.gameObject);
            
 
            }
        
            if (timer >= 0)
            {

                timer -= Time.deltaTime;
            }
        
    }
 [Command(requiresAuthority = false)]
   // [Command]
    void CmdSpwan(GameObject player)
    {
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
        NetworkServer.Spawn(bul);
        timer += 5;
        GameController.instance.perform = false;
        active = false;
     //   bullet.GetComponent<>
    }
    

}
