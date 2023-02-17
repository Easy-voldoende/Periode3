using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject objectToPaint;
    public int refills;
    bool refilled;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Refill")
        {
            Refill();
        }
    }
    public void Refill()
    {
        if(refilled == false)
        {
            refills = 10;
            refilled = true;
        }
    }
    public void ColorGreen()
    {
        if (refills > 0)
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.green;
            rend.material.color = color;
            refills -= 1;
        }
    }

    public void ColorRed()
    {
        if(refills > 0)
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.red;
            rend.material.color = color;
            refills -= 1;
        }
    }

    public void ColorBlue()
    {
        if(refills > 0)
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.blue;
            rend.material.color = color;
            refills -= 1;
        }
    }

    public void ColorMagenta()
    {
        if (refills > 0)
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.magenta;
            rend.material.color = color;
            refills -= 1;
        }
    }



}
