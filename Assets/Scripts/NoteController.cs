 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NoteController : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPressR;
    public KeyCode keyToPressL;
    public Sprite ArrowSP;
    public float BeatTempo;

    public IObjectPool<GameObject> Pool {get; set;}

    public enum Direction
    {
        none,
        left, 
        right, 
        up, 
        down 
    }

    public Direction state;

    void Start()
    {
        BeatTempo=BeatTempo/60f;  
        this.GetComponent<SpriteRenderer>().sprite = ArrowSP;
    }

    void Update()
    {
        this.CheckHit();
        switch(state)
        {
            case Direction.up: 
            gameObject.transform.position -= new Vector3(0f, BeatTempo*Time.deltaTime ,0f); break;
            
            case Direction.right: 
            gameObject.transform.position -= new Vector3(BeatTempo*Time.deltaTime, 0f ,0f); break;

            case Direction.left: 
            gameObject.transform.position += new Vector3(BeatTempo*Time.deltaTime, 0f ,0f); break;

            case Direction.down: 
            gameObject.transform.position += new Vector3(0f, BeatTempo*Time.deltaTime ,0f); break;
        }
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
            ResetPosition(state);
            Pool.Release(this.gameObject);
            
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
                ResetPosition(state);
                Pool.Release(this.gameObject);
            }
        }
      
    }

    public void ResetPosition(Direction dir)
    {
        switch(dir)
        {
            case Direction.up: gameObject.transform.position=new Vector3(0,18,-1); break;
            case Direction.right: gameObject.transform.position=new Vector3(13,5,-1); break;
            case Direction.left: gameObject.transform.position=new Vector3(-13,5,-1); break;
            case Direction.down: gameObject.transform.position=new Vector3(0,-8,-1); break;
        } 
    }
}
