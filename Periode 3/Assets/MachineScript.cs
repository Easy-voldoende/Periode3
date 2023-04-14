using OVR;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject instantiatedObject;
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
    public GameObject elevator;
    public AudioManager manager;
    public bool machineOn;
    
    
    
    
    void Start()
    {
        painted = false;
        machineOn = false;
        
    }
    public void Update()
    {
        if(objectToMove != null)
        {
            WaypointMover wp = objectToMove.GetComponent<WaypointMover>();
            if (painted == false && objectToMove.GetComponent<WaypointMover>().finished == true)
            {
                Renderer rend = objectToMove.transform.GetChild(0).GetComponent<Renderer>();
                Renderer rend2 = objectToMove.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>();
                Color color = finalColor;
                rend.material.color = color;
                rend2.material.color = color;
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
    public void TurnOnMachine()
    {
        if(machineOn == false)
        {
            buttons.SetActive(true);
            error.SetActive(false);
            machineOn = true;
        }
        else
        {
            buttons.SetActive(false);
            error.SetActive(false);
            machineOn = true;
        }
    }
    public void NewCanister()
    {
        if (objectToMove != null)
        {
            Destroy(objectToMove);
        }
        Quaternion rot = new Quaternion(0,90,90,0);
        instantiatedObject = Instantiate(objectToPaintPrefab, spawnPos.position, rot);
        objectToMove = instantiatedObject;
        instantiatedObject.GetComponent<WaypointMover>().missionSystem = missionSystem.GetComponent<MissionSystem>();
        instantiatedObject.GetComponent<WaypointMover>().elevator = elevator;
        manager.PlayAudio(0, 1, 1);
    }
    public void ColorGreen()
    {
        i = 0;
        paintSelected = "Green";

        CheckForPaintLevel(i);
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = 0;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                    {
                        finalColor = Color.green;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = Color.red;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {

                        finalColor = Color.blue;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {

                        finalColor = Color.magenta;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {

                        finalColor = Color.black;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {

                        finalColor = Color.yellow;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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

        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {

                        finalColor = Color.cyan;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;

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
        
        if(objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {

                        finalColor = Color.gray;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = new Color(1, 0.482f, 0,1);
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = new Color(0.588f, 0.294f,0,1);
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = Color.white;
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = new Color(0.627f, 0.125f, 0.941f, 1);
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = new Color(0.501f, 0.501f,0,1);
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = new Color(0.509f,0.309f,1f,0.717f);
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = new Color(1, 0.843f, 0f, 1f);
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        if (objectToMove != null)
        {
            if (objectToMove.GetComponent<WaypointMover>().isMixing == false)
            {
                colorMatchup = i;

                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
                {
                    if (paintCanisters[i].GetComponent<PaintLevel>().refills > 0)
                    {
                        finalColor = new Color(0.752f, 0.752f, 0.752f,1);
                        objectToMove.GetComponent<WaypointMover>().color = finalColor;
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
        manager.PlayAudio(0,1,1);
        if(paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder !=null)
        {
            if (paintCanisters[i].GetComponent<PaintLevel>().refills <= 0)
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
        
        if(canMix == true && Vector3.Distance(objectToMove.transform.position, startingPoint.transform.position)<0.25f)
        {
            manager.PlayAudio(0, 1, 1);
            WaypointMover move = objectToMove.GetComponent<WaypointMover>();
            move.started = true;
            move.finished = false;
            painted = false;
            move.isMixing = true;
            move.checkPoints = 0;
            move.currentWaypoint = startingPoint.transform;
            paintCanisters[i].GetComponent<PaintLevel>().refills -= 1;

        }

    }

    public void ErrorDismiss()
    {
        error.SetActive(false);
        buttons.SetActive(true);

    }
    
    
}
