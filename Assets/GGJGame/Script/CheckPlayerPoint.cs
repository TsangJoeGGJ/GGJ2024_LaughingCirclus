using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CheckPlayerPoint : NetworkBehaviour
{
  [SyncVar] public bool Open;
  public  CheckPlayerList checkPlayerList;
    private void Start()
    {
        Open = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"&&!Open)
        {
            checkPlayerList.checkPlayerPoint = this;
            SetActive();
                    Open = true;
        }
    }
    public void SetActive()
    {
        Debug.Log("CmdSet");
        GameSceneUI.instance.CmdSetA();
    }
}
