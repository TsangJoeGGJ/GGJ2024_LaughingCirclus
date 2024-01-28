using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CheckPlayerList : NetworkBehaviour
{

    public static CheckPlayerList instance;
    public List<CheckPlayerPoint> checkPlayerPoints = new List<CheckPlayerPoint>();
   [SyncVar] public CheckPlayerPoint checkPlayerPoint;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        for (int x = 0; x < checkPlayerPoints.Count; x++)
        {
            Debug.Log("0" + x);
            if (checkPlayerPoints[x] == null)
            {
                return;
            }
            checkPlayerPoints[x].checkPlayerList = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < checkPlayerPoints.Count; x++)
        {
            Debug.Log("checkPlayerPoints" + x);
            if (checkPlayerPoints[x] == null)
            {
                return;
            }
            if (checkPlayerPoints[x].Open)
            {
                Debug.Log("checkPlayerPoints"+x);
            }
        }
    }
}
