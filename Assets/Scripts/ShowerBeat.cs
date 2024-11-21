using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerBeat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<30; i++)
        {
            StartCoroutine(LeftSpawn(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

       //코루틴 생성
    public IEnumerator LeftSpawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GameObject LeftArrow = BeatController.instance.PoolLeft.Get();
    }
}
