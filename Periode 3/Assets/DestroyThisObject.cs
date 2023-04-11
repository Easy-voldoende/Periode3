using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisObject : MonoBehaviour
{
    public bool destroy;
    public float multiplier;
    private void Start()
    {
        multiplier = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(destroy == true)
        {
            multiplier += 1f * Time.deltaTime;
            Vector3 baseScale = gameObject.transform.localScale;
            Vector3 targetScale = Vector3.zero;

            gameObject.transform.localScale = Vector3.Lerp(baseScale, targetScale, Time.deltaTime * multiplier);

            if (baseScale == targetScale)
            {
                Destroy(gameObject);
                multiplier = 1;
            }
        }
    }
}
