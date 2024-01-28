using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LocalMainSceneUI : MonoBehaviour
{
    public static LocalMainSceneUI instance;
    public InputField inputField; 
    public InputField inputFieldIP;
    public Text Iptext;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void UpdateIF()
    {
        if (inputFieldIP.text == "")
        {
            localLobbyScene.instance.CNManager.networkAddress = "localhost";
            return;
        }
        localLobbyScene.instance.CNManager.networkAddress = inputFieldIP.text;
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
