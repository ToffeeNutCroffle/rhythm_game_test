using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerBeat : MonoBehaviour
{
    public GameObject[] Arrows;
    public GameObject note;
    BeatController[] Beats;
    // Start is called before the first frame update
    void Start()
    {
        SetNote(4);
        //Arrows = new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        //Arrows[0].GetComponent<BeatController>().LeftMove();
    }

    public void SetNote(int length)
    {
        Arrows = new GameObject[length];
        Beats = new BeatController[length];
        for(int i=0; i<length; i++)
        {
            Beats[i] = Arrows[i].GetComponent<BeatController>();
        }
    }
}
