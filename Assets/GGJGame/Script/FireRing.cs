using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class FireRing : NetworkBehaviour
{
    public float timer=3;
    private void Update()
    {
        //if (isLocalPlayer || isServer)
        {
            if (GameController.instance.perform == false)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("emp");
            }
            else { gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("fir");
                StartCoroutine(eCoroutine());
                
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
    }
    IEnumerator eCoroutine()
    {
        
        yield return new WaitForSeconds(3);

        GameController.instance.perform = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OnCollisionEnter2D");
            //collision.gameObject.GetComponent<PlayerMoveScript>().isDead = true;
        }
    }
    [Command]
    void SetIsDead(Collision2D collision)
    {
    }
}
