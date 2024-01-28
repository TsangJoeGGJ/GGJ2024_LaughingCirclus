using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class point : NetworkBehaviour
{
    public GameObject door;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            door.SetActive(false);

        }
    }
}
