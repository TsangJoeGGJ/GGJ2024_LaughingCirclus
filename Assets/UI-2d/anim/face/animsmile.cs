using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class animsmile : NetworkBehaviour
{
    public static animsmile instance;
    AudioSource Aud;
    Animator anim;
    public GameObject face;
    public GameObject TargetPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Aud = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        TargetPlayer = PlayerMoveScript.instance.PlayerModel;
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerMoveScript.instance.isdead) { PlayAnim(); }
        /*else
        {
            if (TargetPlayer.transform.position.x > Leye.transform.position.x)
            {
                Leye.transform.position = new Vector3((Leye.transform.position.x + 0.05f), 3.564815f, 0);
                Reye.transform.position = new Vector3((Reye.transform.position.x + 0.05f), 3.564815f, 0);

            }
            else
            {
                Leye.transform.position = new Vector3((Leye.transform.position.x -0.05f), 3.564815f, 0);
                Reye.transform.position = new Vector3((Reye.transform.position.x - 0.05f), 3.564815f, 0);
            }

            */

       
    } 
    public void PlayAud()
    {
        Aud.Play();
    }
    public void Idel()
    {
        face.SetActive(true);

    }
    public void PlayAnim()
    {
        face.SetActive(false);
        anim.Play("smile1");

    }
}
