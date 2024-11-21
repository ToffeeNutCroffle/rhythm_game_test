using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BeatController : MonoBehaviour
{
    public GameObject Arrow;
    public static BeatController instance;
    public int DefaultCapacity = 15;
    public int MaxPoolSize = 20;

    public IObjectPool<GameObject> PoolLeft{get; set;}
    
    private void Awake()
    {
        if(instance==null) instance=this;
        else Destroy(this.gameObject);

        Init();
    }
    
    private void Init()
    {
        PoolLeft = new ObjectPool<GameObject>(CreateLeft,TakePool,ReturnPool,DestroyObject,
        true, DefaultCapacity,MaxPoolSize);

        /*PoolRight = new ObjectPool<GameObject>(CreateLeft,TakePool,ReturnPool,DestroyObject,
        true, DefaultCapacity,MaxPoolSize);*/
        for(int i=0; i<DefaultCapacity; i++)
        {
            NoteController note = CreateLeft().GetComponent<NoteController>();
            note.keyToPressL=KeyCode.A;
            note.keyToPressR=KeyCode.LeftArrow;
            note.state = NoteController.Direction.left;
            note.Pool.Release(note.gameObject); 
        }
    }   

    private GameObject CreateLeft()
    {
        GameObject poolgo = Instantiate(Arrow, new Vector3(-13,5,-1),Quaternion.Euler(0,180,0));
        poolgo.GetComponent<NoteController>().Pool = this.PoolLeft;
        return poolgo;

    }

    private void TakePool(GameObject poolgo)
    {
        poolgo.SetActive(true);
    }

    private void ReturnPool(GameObject poolgo)
    {
        poolgo.SetActive(false);
    }

    private void DestroyObject(GameObject poolgo)
    {
        Destroy(poolgo);
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
