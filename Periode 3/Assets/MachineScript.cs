using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject objectToPaint;
    public GameObject[] paintCanisters;
    public int refills;
    bool refilled;
    
    void Start()
    {
        
    }
 
    public void ColorGreen()
    {
        if (paintCanisters[0].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[0].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                Renderer rend = objectToPaint.GetComponent<Renderer>();
                Color color = Color.green;
                rend.material.color = color;
                paintCanisters[0].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }
        }
        else
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.white;
            rend.material.color = color;
        }
    }

    public void ColorRed()
    {
        if (paintCanisters[1].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[1].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                Renderer rend = objectToPaint.GetComponent<Renderer>();
                Color color = Color.red;
                rend.material.color = color;
                paintCanisters[1].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }
        }
        else
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.white;
            rend.material.color = color;
        }

    }

    public void ColorBlue()
    {
        if (paintCanisters[2].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[2].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                Renderer rend = objectToPaint.GetComponent<Renderer>();
                Color color = Color.blue;
                rend.material.color = color;
                paintCanisters[2].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }


        }
        else
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.white;
            rend.material.color = color;
        }
    }


    public void ColorMagenta()
    {
        if (paintCanisters[3].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[3].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                Renderer rend = objectToPaint.GetComponent<Renderer>();
                Color color = Color.magenta;
                rend.material.color = color;
                paintCanisters[3].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }


        }
        else
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = Color.white;
            rend.material.color = color;
        }
    }


}
