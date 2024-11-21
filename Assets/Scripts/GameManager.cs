using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Audio(3.8f));
        theMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}