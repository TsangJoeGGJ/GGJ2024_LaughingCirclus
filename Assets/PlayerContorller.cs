using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    public static PlayerContorller instance;
    

    public bool isdead = false;
    public GameObject deadvfx;
    Rigidbody2D rb;
    public float speed;
    public float jumpforce = 100f;
    bool onground = true;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdead) {
            if (!isdead)
            {

                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);

                if (onground && Input.GetMouseButtonUp(0))
                {

                    Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);

                    Vector3 dirToMouse = Input.mousePosition - posInScreen;
                    dirToMouse.Normalize();
                    Debug.Log(dirToMouse);
                    Vector3 ty = new Vector3(0, 0, 0);

                    ty = new Vector3(dirToMouse.x, 0.1f, transform.position.z);

                    rb.AddForce(ty * jumpforce * 100);
                    // rb.AddForce(dirToMouse * jumpforce * 100);
                    onground = false;
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;

            //respwan
            isdead = false;
            Instantiate(deadvfx);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Remove")
        {
            onground = true;
        }
    }
}
