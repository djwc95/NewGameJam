using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableOnClick : MonoBehaviour
{
    public Button newButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickDisabled()
    {
        newButton.interactable = false;
    }
}
