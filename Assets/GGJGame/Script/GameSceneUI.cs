using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class GameSceneUI : NetworkBehaviour
{
    public static GameSceneUI instance;
    public Text SavePoint;
    public float Timer = 0;
    public float curTimer;
   [SyncVar] public bool bSetActive;
    // Start is called before the first frame update
    void Start()
    {
        curTimer = 0;
        SavePoint.gameObject.SetActive(false);
        bSetActive = false;
           instance = this;
        if (SavePoint != null)
        {
            SavePoint.text = "Save Point";
        }
    }

    // Update is called once per frame
    void Update()
    {
        SavePoint.gameObject.SetActive(bSetActive);
        if (SavePoint.gameObject.activeSelf == false)
        {
            Debug.Log("GSUI:" + SavePoint.gameObject.activeSelf);
        }
        else
        {
            curTimer += Time.deltaTime; 
            if (curTimer > 5)
            {
                bSetActive = false;
                curTimer = 0;
            }
            Debug.Log("GSUI:" + SavePoint.gameObject.activeSelf);
        }
    }
   public void CmdSetA()
    {
        bSetActive = true;
    }

}
