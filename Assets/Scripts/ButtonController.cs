using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite preesedImage;

    public KeyCode keyToPressR;
    public KeyCode keyToPressL; 
    // Start is called before the first frame update
    void Start()
    {
        theSR=GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPressR) || Input.GetKeyDown(keyToPressL))
        {
            theSR.sprite = preesedImage;
        }

        if(Input.GetKeyUp(keyToPressL) || Input.GetKeyUp(keyToPressR))
        {
            theSR.sprite= defaultImage;
        }
    }
}
