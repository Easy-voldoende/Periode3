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
    public Animator MainAnim;
    public Animator crossFade;
    public int MenuState;

    public void Start()
    {
        MenuState = 0;
    }

    #region Buttons


    public void StartGame()
    {
        StartCoroutine(nameof(LoadNextScene));
    }

    public void Options()
    {
        MenuState = 1;
    }

    public void Credits()
    {
        MenuState = 2;
    }
    #endregion

    public IEnumerator LoadNextScene()
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(null);

    }
}
