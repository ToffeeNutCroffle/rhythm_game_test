using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPressR;
    public KeyCode keyToPressL;
    public Sprite ArrowSP;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = ArrowSP;
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckHit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed=true;
        }

        else if(other.tag == "Destroy")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag =="Activator")
        {
            canBePressed=false;
        }
    }

    public void CheckHit()
    {
        if(Input.GetKeyDown(keyToPressR) || Input.GetKeyDown(keyToPressL))
        {
            if(canBePressed==true)
            {
                gameObject.SetActive(false);
            }
        }
      
    }
}
