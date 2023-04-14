using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnim : MonoBehaviour
{
    public DrawerAnim anim;
    public DrawerAnimTwo animTwo;
    public bool open;
    Vector3 oldPos;
    Vector3 newPos;
    public GameObject[] handles;
    public bool cycled;
    public GameObject[] canisters;
    public bool toggleActive;
    
    void Start()
    {
        oldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = oldPos;
        newPos.x += 0.02382f;

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        
        if(anim!= null)
        {
            anim.open = open;
        }

        if(animTwo != null)
        {
            animTwo.open = open;
        }
        

    }
    public IEnumerator CanisterCycle()
    {
        foreach (GameObject can in canisters)
        {
            can.GetComponent<BoxCollider>().enabled = false;
        }
        yield return new WaitForSeconds(1);
        foreach (GameObject can in canisters)
        {
            can.GetComponent<BoxCollider>().enabled = true;
        }
    }
    
}
