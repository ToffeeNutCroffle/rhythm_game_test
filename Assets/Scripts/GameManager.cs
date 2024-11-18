using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    // Start is called before the first frame update
    void Start()
    {
       Invoke("PlayMusic",3f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void PlayMusic()
    {
        theMusic.Play(); 
    }
}
