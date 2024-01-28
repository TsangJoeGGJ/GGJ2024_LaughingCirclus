using UnityEngine;
using UnityEngine.UI;

public class LocalPlayerListItem : MonoBehaviour
{
    public string PlayerName;
    public int ConnectionID;
    public ulong PlayerSteamID;
    private bool AvatarReceived;
    public Texture g1,g2;
  

    public Text PlayerNameText;
    public RawImage PlayerIcon;
    public Text PlayerReadyText;
    public bool bReady;

    public bool bV2 = false;
    private void Update()
    {
        if (bV2)
        {
            return;
        }
        else
        {
            transform.localPosition = new Vector3(0, 80 * ConnectionID, 0);
            bV2 = true;
            Debug.Log("TRP");
        }
    }

    public void ChangeReadyStatus()
    {
        if (bReady)//Ready
        {
            PlayerReadyText.text = "Ready";
            PlayerReadyText.color = Color.green;
        }
        else//not Ready
        {
            PlayerReadyText.text = "UnReady";
            PlayerReadyText.color = Color.red;
        }
    }

    private void Start()
    {
        Debug.Log("PLI:Start");
    }

    public void SetPlayerValues()
    {
        if (PlayerName != "")
        {
            PlayerNameText.text = PlayerName;
            if (PlayerName.Contains("P1")) {
                PlayerIcon.texture = g1;
            }
            if (PlayerName.Contains("P2"))
            {
                PlayerIcon.texture = g2;
            }
        }
        else
        {
            PlayerNameText.text = "Error";
        }
        ChangeReadyStatus();
    }
}