using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public Animator mainAnim, optionsAnim,creditsAnim;
    public Animator gearAnim;
    public Animator crossFade;
    public int menuState, gearState;
    private AudioManager audioManager;
    public GameObject[] gears;
    private bool animDone;
    public bool exitedOptions;
    public bool exitedCredits;

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
        exitedOptions = false;
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
        yield return new WaitForSeconds(2);
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
        mainCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        

    }
    #endregion
    public void OptionsBack()
    {
        menuState = 0;
        
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
        exitedOptions = false;
        menuState = 2;
        gearState = 1;
        animDone = false;
        StartCoroutine(nameof(MainMenuInactive));
        StartCoroutine(nameof(CreditsActive));
    }
    public IEnumerator CreditsActive()
    {
        yield return new WaitForSeconds(1);
        creditsCanvas.SetActive(true);
    }
    public void CreditsBack()
    {
        menuState = 0;

        StartCoroutine(nameof(CreditsInactive));
        
        StartCoroutine(nameof(ResetGearSpeed));
    }
    public IEnumerator CreditsInactive()
    {
        
        yield return new WaitForSeconds(1);
        
        creditsCanvas.SetActive(false);
        mainCanvas.SetActive(true);


    }
    #endregion

    public IEnumerator LoadNextScene()
    {
        //crossFade.SetTrigger("Crossfade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartCleanScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Update()
    {
        gearAnim.SetInteger("MenuState", menuState);
        mainAnim.SetInteger("MenuState", menuState);
        optionsAnim.SetInteger("MenuState", menuState);
        creditsAnim.SetInteger("MenuState", menuState);
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
