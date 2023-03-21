using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimations : MonoBehaviour
{
    public GameObject anim;
    public bool activated;
    public void Update()
    {
        anim.GetComponent<Animator>().SetBool("Activated", activated);
    }
    public void Activate()
    {
        if(activated == true)
        {
            activated = false;
        }
        else
        {
            activated = true;
        }
    }
}
