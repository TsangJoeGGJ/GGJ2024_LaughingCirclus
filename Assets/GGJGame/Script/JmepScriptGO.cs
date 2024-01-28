using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JmepScriptGO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OnCollisionEnter2D");
         Vector2   move = new Vector2(0, +2000) * 2;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(move);
        }
    }
}
