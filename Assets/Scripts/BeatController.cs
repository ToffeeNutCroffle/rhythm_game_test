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
        Arrows = new GameObject[2];
        Arrows[0]=LeftArrow();
        StartCoroutine(LeftSpawn(1, 1));
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftMove(Arrows[0]);
        //LeftMove(Arrows[1]);
    }

    //left and right scale must bigger then 13
    public GameObject LeftArrow()
    {
        GameObject obj = Instantiate(Arrow, new Vector3(-13,5,-1),Quaternion.Euler(0,180,0));
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.A;
        note.keyToPressR=KeyCode.LeftArrow;
        return obj;
       
    }

    public GameObject RightArrow(float scale)
    {
        GameObject obj = Instantiate(Arrow, new Vector3(scale,5,-1),Quaternion.identity);
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.D;
        note.keyToPressR=KeyCode.RightArrow;
        return obj;
    }
    //up and down scale must bigger then 11
    public GameObject UpArrow(float scale)
    {
        GameObject obj = Instantiate(Arrow, new Vector3(0,scale,-1),Quaternion.Euler(0,0,90));
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.W;
        note.keyToPressR=KeyCode.UpArrow;
        return obj;
    }

    public GameObject DownArrow(float scale)
    {
        GameObject obj = Instantiate(Arrow, new Vector3(0,0-scale,-1),Quaternion.Euler(0,0,270));
        NoteController note = obj.GetComponent<NoteController>();
        note.keyToPressL=KeyCode.S;
        note.keyToPressR=KeyCode.DownArrow;
        return obj;
    }

    // #Move함수는 Arrow를 움직임
    public void UpMove(GameObject obj)
    {
        obj.transform.position -= new Vector3(0f, BeatTempo*Time.deltaTime ,0f);
    }

    public void LeftMove(GameObject obj)
    {
        obj.transform.position += new Vector3(BeatTempo*Time.deltaTime, 0f ,0f);
    }

    public void RightMove(GameObject obj)
    {
        obj.transform.position -= new Vector3(BeatTempo*Time.deltaTime, 0f ,0f);   
    }

    public void DownMove(GameObject obj)
    {
        obj.transform.position += new Vector3(0f, BeatTempo*Time.deltaTime ,0f);
    }


    //코루틴 생성
    public IEnumerator LeftSpawn(int i, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Arrows[i] = LeftArrow();
    }
}