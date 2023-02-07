using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaling : MonoBehaviour
{
    public Vector3 minSize;
    public Vector3 maxSize;
    public Vector3 idleSize;
    
    private Vector3 baseScale;
    private Vector3 targetScale;
    private Vector3 otherTargetScale; 
    public GameObject[] otherButtons;
    public bool canChange;
    
    // Start is called before the first frame update

    public void Start()
    {        
        baseScale = transform.localScale;
        minSize = baseScale * 0.75f;
        maxSize = baseScale * 1.5f;
        idleSize = baseScale;
        targetScale = idleSize;
        
    }
    public void Update()
    {
        if(canChange == true)
        {
            ApplyScale();
        }
    }
    public void ScaleUp()
    {
        canChange = true;
        targetScale = maxSize;
        otherTargetScale = minSize;
    }
    public void ScaleIdle()
    {
        targetScale = baseScale;
        otherTargetScale = baseScale;
    }
    
    public void ApplyScale()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, targetScale, Time.deltaTime);

        foreach (GameObject button in otherButtons)
        {
            //button.GetComponent<ButtonScaling>().canChange = truel
            button.transform.localScale = Vector3.Lerp(button.transform.localScale, otherTargetScale, Time.deltaTime);
        }
    }

    
}
