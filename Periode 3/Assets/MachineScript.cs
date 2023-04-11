using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject objectToPaint;
    public GameObject objectToPaintPrefab;
    public Transform spawnPos;
    public GameObject missionDropoff;
    public GameObject[] paintCanisters;
    public GameObject missionSystem, startingPoint;
    public int refills;
    public Color finalColor;
    public bool painted;
    public string missionColor;
    public bool canMix;
    public TextMeshProUGUI tmPro;
    public GameObject error;
    public GameObject buttons;
    public int colorMatchup;
    public int finalColorMatchup;
    public bool isMatching, missionCompleted;
    public string paintSelected;
    public int i;
    
    
    
    void Start()
    {
        painted = false;
        
        
    }
    public void Update()
    {
        if(objectToPaint != null)
        {
            WaypointMover wp = objectToPaint.GetComponent<WaypointMover>();
            if (painted == false && objectToPaint.GetComponent<WaypointMover>().finished == true)
            {
                Renderer rend = objectToPaint.GetComponent<Renderer>();
                Color color = finalColor;
                rend.material.color = color;
                painted = true;
            }

            if (colorMatchup == missionSystem.GetComponent<MissionSystem>().missionIndex && wp.finished == true)
            {
                missionDropoff.GetComponent<CheckForMissionComplete>().canCheck = true;
                isMatching = true;
            }
            else
            {
                missionDropoff.GetComponent<CheckForMissionComplete>().canCheck = false;
                isMatching = false;
            }
        }
    }
    public void NewCanister()
    {
        Destroy(objectToPaint);
        objectToPaint = Instantiate(objectToPaintPrefab, spawnPos.position, Quaternion.identity);
        objectToPaint.GetComponent<WaypointMover>().missionSystem = missionSystem.GetComponent<MissionSystem>();
    }
    public void ColorGreen()
    {
        i = 0;
        paintSelected = "Green";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = 0;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = Color.green;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }

    public void ColorRed()
    {
        i = 1;
        paintSelected = "Red";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = Color.red;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;
                    }
                }
                else
                {
                    finalColor = Color.white;
                    canMix = false;

                }
            }
        }
        
        
        
        
    }

    public void ColorBlue()
    {
        i = 2;
        paintSelected = "Blue";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {

                        finalColor = Color.blue;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;
                    }


                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }

        
        

    }


    public void ColorMagenta()
    {
        i = 3;
        paintSelected = "Magenta";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {

                        finalColor = Color.magenta;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;
                    }


                }
                else
                {
                    finalColor = Color.white;
                    canMix = false;

                }
            }
        }
        

        
    }

    public void ColorBlack()
    {

        i = 4;
        paintSelected = "Black";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {

                        finalColor = Color.black;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;
                    }


                }
                else
                {
                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
        
    }
    public void ColorYellow()
    {
        i = 5;
        paintSelected = "Yellow";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {

                        finalColor = Color.yellow;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;
                    }


                }
                else
                {
                    finalColor = Color.white;
                    canMix = false;

                }
            }
        }
        
    }

    public void ColorCyan()
    {

        i = 6;
        paintSelected = "Cyan";
        CheckForPaintLevel(i);

        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {

                        finalColor = Color.cyan;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;

                        canMix = true;
                    }


                }
                else
                {
                    finalColor = Color.white;
                    canMix = false;

                }
            }
        }
        
    }
    public void ColorGray()
    {
        i = 7;
        paintSelected = "Gray";
        CheckForPaintLevel(i);
        
        if(objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {

                        finalColor = Color.gray;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;
                    }


                }
                else
                {
                    finalColor = Color.white;
                    canMix = false;

                }
            }
        }
        
    }
    public void ColorOrange()
    {
        i = 8;
        paintSelected = "Orange";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = new Color(1, 0.482f, 0,1);
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }
    public void ColorBrown()
    {
        i = 9;
        paintSelected = "Brown";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = new Color(0.588f, 0.294f,0,1);
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }
    public void ColorWhite()
    {
        i = 10;
        paintSelected = "White";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = Color.white;
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }
    public void ColorPurple()
    {
        i = 11;
        paintSelected = "Purple";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = new Color(0.627f, 0.125f, 0.941f, 1);
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;
                        

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }

    public void ColorOlive()
    {
        i = 12;
        paintSelected = "Olive";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = new Color(0.501f, 0.501f,0,1);
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }
    public void ColorIndigo()
    {
        i = 13;
        paintSelected = "Indigo";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = new Color(0.509f,0.309f,1f,0.717f);
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }

    public void ColorGold()
    {
        i = 14;
        paintSelected = "Gold";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = new Color(1, 0.843f, 0f, 1f);
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }

    public void ColorSilver()
    {
        i = 15;
        paintSelected = "Silver";

        CheckForPaintLevel(i);
        if (objectToPaint != null)
        {
            if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = new Color(0.752f, 0.752f, 0.752f,1);
                        objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                        canMix = true;

                    }
                }
                else
                {

                    finalColor = Color.white;
                    canMix = false;
                }
            }
        }
    }



    public void CheckForPaintLevel(int i)
    {
        if(paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder !=null)
        {
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills <= 0)
            {
                error.SetActive(true);
                error.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "There is not enough " + paintSelected + " paint!";
                buttons.SetActive(false);
            }
        }
        else if(paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder == null)
        {
            error.SetActive(true);
            error.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "There is not enough " + paintSelected + " paint!";
            buttons.SetActive(false);
        }
    }
    public void ActivateMachine()
    {
        
        if(canMix == true && Vector3.Distance(objectToPaint.transform.position, startingPoint.transform.position)<0.25f)
        {

            WaypointMover move = objectToPaint.GetComponent<WaypointMover>();
            move.started = true;
            move.finished = false;
            painted = false;
            move.isMixing = true;
            move.checkPoints = 0;
            move.currentWaypoint = startingPoint.transform;
            paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;

        }

    }

    public void ErrorDismiss()
    {
        error.SetActive(false);
        buttons.SetActive(true);

    }
    
    
}
