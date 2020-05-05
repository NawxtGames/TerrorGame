using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour
{
    public GameObject mobileUI;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            mobileUI.SetActive(true);
        }
        else
            mobileUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
