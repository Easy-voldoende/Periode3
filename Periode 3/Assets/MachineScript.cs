using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject objectToPaint;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorGreen()
    {
        Renderer rend = objectToPaint.GetComponent<Renderer>();
        Color color = Color.green;
        rend.material.color = color;
    }

    public void ColorRed()
    {
        Renderer rend = objectToPaint.GetComponent<Renderer>();
        Color color = Color.red;
        rend.material.color = color;
    }

    public void ColorBlue()
    {
        Renderer rend = objectToPaint.GetComponent<Renderer>();
        Color color = Color.blue;
        rend.material.color = color;
    }
}
