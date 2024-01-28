using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Boom : NetworkBehaviour
{
    public static Boom instance;
    public GameObject bsound;
    public bool boom,atc;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (atc) { transform.position = new Vector3(transform.position.x-0.01f, transform.position.y , transform.position.z);
      }
        if (boom) {
            transform.position = new Vector3(transform.position.x , transform.position.y+ 0.01f, transform.position.z);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"||collision.gameObject.tag == "Remove")
        {
            if (bsound != null) { Instantiate(bsound);}

            NetworkServer.
            Destroy(gameObject);
        }
       
    }
   
}
