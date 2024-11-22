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

    //4종류의 pool 정의
    public IObjectPool<GameObject> PoolLeft{get; set;}
    public IObjectPool<GameObject> PoolRight{get; set;}
    public IObjectPool<GameObject> PoolUp{get; set;}
    public IObjectPool<GameObject> PoolDown{get; set;}
    
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

        PoolRight = new ObjectPool<GameObject>(CreateRight,TakePool,ReturnPool,DestroyObject,
        true, DefaultCapacity,MaxPoolSize);

        PoolUp = new ObjectPool<GameObject>(CreateUp,TakePool,ReturnPool,DestroyObject,
        true, DefaultCapacity,MaxPoolSize);

        PoolDown = new ObjectPool<GameObject>(CreateDown,TakePool,ReturnPool,DestroyObject,
        true, DefaultCapacity,MaxPoolSize);

        for(int i=0; i<DefaultCapacity; i++)
        {
            NoteController noteleft = CreateLeft().GetComponent<NoteController>();
            noteleft.keyToPressL=KeyCode.A;
            noteleft.keyToPressR=KeyCode.LeftArrow;
            noteleft.state = NoteController.Direction.left;
            noteleft.Pool.Release(noteleft.gameObject); 

            NoteController noteright = CreateRight().GetComponent<NoteController>();
            noteright.keyToPressL=KeyCode.D;
            noteright.keyToPressR=KeyCode.RightArrow;
            noteright.state = NoteController.Direction.right;
            noteright.Pool.Release(noteright.gameObject);

            NoteController noteup = CreateUp().GetComponent<NoteController>();
            noteup.keyToPressL=KeyCode.W;
            noteup.keyToPressR=KeyCode.UpArrow;
            noteup.state = NoteController.Direction.up;
            noteup.Pool.Release(noteup.gameObject);

            NoteController notedown = CreateDown().GetComponent<NoteController>();
            notedown.keyToPressL=KeyCode.S;
            notedown.keyToPressR=KeyCode.DownArrow;
            notedown.state = NoteController.Direction.down;
            notedown.Pool.Release(notedown.gameObject);            

        }
    }   

    private GameObject CreateLeft()
    {
        GameObject poolgo = Instantiate(Arrow, new Vector3(-13,5,-1),Quaternion.Euler(0,180,0));
        poolgo.GetComponent<NoteController>().Pool = this.PoolLeft;
        return poolgo;
    }

    private GameObject CreateRight()
    {
        GameObject poolgo = Instantiate(Arrow, new Vector3(13,5,-1),Quaternion.identity);
        poolgo.GetComponent<NoteController>().Pool = this.PoolRight;
        return poolgo;
    }

    private GameObject CreateUp()
    {
        GameObject poolgo = Instantiate(Arrow, new Vector3(0,13,-1), Quaternion.Euler(0,0,90));
        poolgo.GetComponent<NoteController>().Pool = this.PoolUp;
        return poolgo;
    }

    private GameObject CreateDown()
    {
        GameObject poolgo = Instantiate(Arrow, new Vector3(0,-13,-1), Quaternion.Euler(0,0,270));
        poolgo.GetComponent<NoteController>().Pool = this.PoolDown;
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

   
}
