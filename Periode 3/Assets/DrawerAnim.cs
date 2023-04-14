using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public bool open;
    void Start()
    {
       anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Open", open);
    }
}
