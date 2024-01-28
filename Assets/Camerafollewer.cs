using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Camerafollewer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.LocalPlayermanger != null)
       {
           
            if (GameController.instance.LocalPlayermanger.transform.position.x > transform.position.x)
                transform.position = new Vector3(transform.position.x + 0.025f, 0, -10);

            if (GameController.instance.LocalPlayermanger.transform.position.x < transform.position.x)
                transform.position = new Vector3(transform.position.x - 0.025f, 0, -10);
        }
    }
}
