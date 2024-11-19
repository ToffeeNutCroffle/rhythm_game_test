using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    public float BeatTempo;
    public GameObject Arrow;
    public GameObject[] Arrows;
   

    // Start is called before the first frame update
    void Start()
    {
        BeatTempo=BeatTempo/60f;    
        Arrows = new GameObject[6];
        Arrows[0]=LeftArrow(13);
        Arrows[1]=LeftArrow(14.5f);
        Arrows[2]=UpArrow(20);
        Arrows[3]=RightArrow(17.5f);
        Arrows[4]=RightArrow(19);
        Arrows[5]=DownArrow(14.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //left and right scale must bigger then 13
    public GameObject LeftArrow(float scale)
    {
        GameObject obj = Instantiate(Arrow, new Vector3(0-scale,5,-1),Quaternion.Euler(0,180,0));
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.A;
        note.keyToPressR=KeyCode.LeftArrow;
        note.state = NoteController.Direction.left;
        return obj;
       
    }

    public GameObject RightArrow(float scale)
    {
        GameObject obj = Instantiate(Arrow, new Vector3(scale,5,-1),Quaternion.identity);
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.D;
        note.keyToPressR=KeyCode.RightArrow;
        note.state = NoteController.Direction.right;
        return obj;
    }
    //up and down scale must bigger then 11
    public GameObject UpArrow(float scale)
    {
        GameObject obj = Instantiate(Arrow, new Vector3(0,scale,-1),Quaternion.Euler(0,0,90));
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.W;
        note.keyToPressR=KeyCode.UpArrow;
        note.state = NoteController.Direction.up;
        return obj;
    }

    public GameObject DownArrow(float scale)
    {
        GameObject obj = Instantiate(Arrow, new Vector3(0,0-scale,-1),Quaternion.Euler(0,0,270));
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.S;
        note.keyToPressR=KeyCode.DownArrow;
        note.state = NoteController.Direction.down;
        return obj;
    }

  
    //코루틴 생성
   // public IEnumerator LeftSpawn(int i, float time)
   // {
       // yield return new WaitForSecondsRealtime(time);
      //  Arrows[i] = LeftArrow();
    //}
}
