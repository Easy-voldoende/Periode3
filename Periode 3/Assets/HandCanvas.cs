using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandCanvas : MonoBehaviour
{
    public GameObject canvas;
    public Slider slider;
    public float leaveProgress;
    float minProgress;
    float maxProgress;
    public bool buttonPressed;

    public void Start()
    {
        maxProgress = 1;
        minProgress = 0;
    }
    public void ActivateCanvas(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            canvas.SetActive(true);
        }
        else if (context.canceled)
        {
            canvas.SetActive(false);
        }
    }
    public void PressedLeaveButton()
    {        
        buttonPressed = true;
    }
    public void ReleasedLeaveButton()
    {
        buttonPressed = false;
    }
    public void Update()
    {
        if (leaveProgress > maxProgress)
        {
            leaveProgress = maxProgress;
        }

        if (leaveProgress < minProgress)
        {
            leaveProgress = minProgress;
        }
        if(buttonPressed != true)
        {
            leaveProgress -= 0.3f * Time.deltaTime;
        }
        else if(buttonPressed == true)
        {
            leaveProgress += 0.3f * Time.deltaTime;
        }
        if (leaveProgress >= maxProgress)
        {
            //Application.Quit();
            SceneManager.LoadScene(0);
            Debug.Log("Quit game");
        }
        slider.value = leaveProgress;
    }
}
