using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Threading.Tasks;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsCanvas, creditsCanvas, mainCanvas;
    public Animator mainAnim, optionsAnim;
    public Animator gearAnim;
    public Animator crossFade;
    public int menuState, gearState;
    private AudioManager audioManager;
    public GameObject[] gears;
    private bool animDone;

    public void Start()
    {
        menuState = 0;
        
    }

    #region Buttons


    public void StartGame()
    {
        StartCoroutine(nameof(LoadNextScene));
    }

    public void Options()
    {
        menuState = 1;
        gearState = 1;
        animDone = false;
        StartCoroutine(nameof(MainMenuInactive));
        StartCoroutine(nameof(OptionsActive));

    }
    #region IEnumerators
    public IEnumerator MainMenuInactive()
    {
        yield return new WaitForSeconds(1);
        mainCanvas.SetActive(false);
    }

    public IEnumerator MainMenuActive()
    {
        yield return new WaitForSeconds(1);
        optionsCanvas.SetActive(true);
    }

    public IEnumerator OptionsActive()
    {
        yield return new WaitForSeconds(1);
        optionsCanvas.SetActive(true);
    }
    public IEnumerator OptionsInactive()
    {
        
        yield return new WaitForSeconds(1);
        optionsCanvas.SetActive(false);
        

    }
    #endregion
    public void OptionsBack()
    {
        menuState = 0;
        mainCanvas.SetActive(true);
        StartCoroutine(nameof(OptionsInactive));
        StartCoroutine(nameof(ResetGearSpeed));
    }
    public IEnumerator ResetGearSpeed()
    {
        gearState = 0;
        yield return new WaitForSeconds(1.5f);
        animDone = true;

    }
    public void Credits()
    {
        menuState = 1;
    }
    #endregion

    public IEnumerator LoadNextScene()
    {
        crossFade.SetTrigger("Crossfade");
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene(null);

    }

    public void Update()
    {
        gearAnim.SetInteger("MenuState", menuState);
        mainAnim.SetInteger("MenuState", menuState);
        optionsAnim.SetInteger("MenuState", menuState);
        if (menuState == 0 && animDone == true)
        {
            foreach (GameObject gear in gears)
            {
                gear.GetComponent<GearTurning>().turnSpeed -= 100f * Time.deltaTime;
                if(gear.GetComponent<GearTurning>().turnSpeed <= 100f)
                {
                    gear.GetComponent<GearTurning>().turnSpeed = 100f;
                }
            }
        }
        else if (menuState == 1)
        {
            foreach (GameObject gear in gears)
            {
                gear.GetComponent<GearTurning>().turnSpeed = 360f;
            }
        }
    }
}
