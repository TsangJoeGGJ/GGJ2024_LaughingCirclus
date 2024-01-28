using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour
{
    public static GameController instance;
    public PlayerMoveScript LocalPlayermanger;
   
    // public localPlayerController LocalPlayermanger;
    public GameObject endpanal;
    public GameObject atc,boo, box;
    public bool isEnd = false;
    public bool perform;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd) { endpanal.SetActive(true); }
    }
    public void SetQuit()
    {
        LocalLobbyController.instance.OnApplicationQuit();

    }
}
