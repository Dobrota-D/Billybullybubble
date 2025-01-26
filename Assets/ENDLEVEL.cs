using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDLEVEL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(eNDcOUROUTINE());
    }

    private IEnumerator eNDcOUROUTINE()
    {
        yield return new WaitForSeconds(3f);
        Application.Quit();
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
