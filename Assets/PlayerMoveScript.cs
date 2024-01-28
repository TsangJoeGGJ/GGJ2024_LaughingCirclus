using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
public class PlayerMoveScript : NetworkBehaviour
{
    public static PlayerMoveScript instance;
    public float speed = 0.1f;
    public int PID = -1;
    Rigidbody2D rb;
    public bool isdead = false;
    public GameObject deadvfx;
    AudioSource Aud;
    public float jumpforce = 100f;
    bool onground = true;
    public GameObject PlayerModel;
    public GameObject EnemyBullet;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PlayerModel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        Aud = GetComponent<AudioSource>();


        //   SetPlayericon();

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {

            if (PlayerModel.activeSelf == false)
            {
                //SetPosition();
                // SetPlayericon();


                PlayerModel.SetActive(true);
            }
          
            if(isLocalPlayer || isServer) {
                SetPlayericon();
                
            }
            if (hasAuthority)
            {
                GameController.instance.LocalPlayermanger = this;
                moveing();

                /* MovePlayer(); 
                 if (Input.GetKeyDown(KeyCode.E))
                 {
                     CmdHello(gameObject);

                 }*/
            }
        }
    }
    public void SetPlayericon()
    {
        if (PID == 1)
        {
            PlayerModel.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("player1");
        }
        if (PID == 2)
        {
            PlayerModel.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("player2");
        }
    }
    public void SetPosition()
    {
        transform.position = new Vector3(Random.Range(-5, 5), 0.8f, Random.Range(-15, 7));
    }
    public void moveing()
    {
        if (!isdead)
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);

            if (onground && Input.GetMouseButtonUp(0))
            {
                Aud.Play();
                Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);

                Vector3 dirToMouse = Input.mousePosition - posInScreen;
                dirToMouse.Normalize();
                Debug.Log(dirToMouse);
                Vector3 ty = new Vector3(0, 0, 0);
                if (dirToMouse.x < -0.1) { ty = new Vector3(-0.3f, 0.35f, transform.position.z); }
                if (dirToMouse.x >= -0.1) { ty = new Vector3(0.3f, 0.35f, transform.position.z); }

                rb.AddForce(ty * jumpforce * 100);
                PlayerModel.transform.Rotate(0, 0.0f, 10.0f, Space.World);
                if (PlayerModel.transform.rotation.z != 0)
                {
                    PlayerModel.transform.Rotate(0, 0.0f, 10.0f, Space.World);
                }

                // rb.AddForce(dirToMouse * jumpforce * 100);
                onground = false;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;

            //respwan
            isdead = false;
            Vector3 n = PlayerModel.transform.position;
         
            //   CmdDead(PlayerModel, deadvfx);
            Instantiate(deadvfx, n, Quaternion.identity);
            transform.position = CheckPlayerList.instance.checkPlayerPoint.transform.position;
        }
    }
    public void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, y, 0f);
        transform.position += move * speed;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Remove")
        {
            onground = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Remove")
        {
            onground = true;

        }
        if (isLocalPlayer && ((collision.gameObject.tag == "FireRing"&& GameController.instance.perform == false )|| collision.gameObject.tag == "Danger" ))
        {
            isdead=true;
            //SetIsDead(true);
        }
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            RpcEnd();
            //SetIsDead(true);
        }
        if (isLocalPlayer && collision.gameObject.tag == "intact")
        {

            GameController.instance.perform = true;
            GameController.instance.boo.GetComponent<atkment>().active = true;
            //SetIsDead(true);
        }
        if (isLocalPlayer && collision.gameObject.tag == "atc")
        {

            GameController.instance.perform = true;
            GameController.instance.atc.GetComponent<atkment>().active = true;
            //SetIsDead(true);
        }
        if (isLocalPlayer && collision.gameObject.tag == "box")
        {
            NetworkServer.Destroy(GameController.instance.box);
            //SetIsDead(true);
        }
        if (isLocalPlayer && (collision.gameObject.tag == "Danger"))
        {
            isdead = true;
            //SetIsDead(true);
        }

    }
   
    [Command]
    void CmdHello(GameObject player)
    {
        GameObject bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        NetworkServer.Spawn(bullet, player);
    }
    [Command]
    void CmdDead(GameObject player, GameObject vfx)
    {
        Vector3 n = PlayerModel.transform.position;
        GameObject h=
        Instantiate(vfx, n, Quaternion.identity);
        NetworkServer.Spawn(h, player);
    }
    [ClientRpc]
    void RpcEnd()
    {
        GameController.instance.isEnd = true;
        Time.timeScale = 0;


    }
   
}
