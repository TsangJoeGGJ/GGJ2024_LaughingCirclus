using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Selfdestory : NetworkBehaviour
{
    AudioSource Aud;
    // Start is called before the first frame update
    void Start()
    {
        Aud = GetComponent<AudioSource>();
    }
    public void PlayAud()
    {
        Aud.Play();
    }
    public void destoryself()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
