using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerBeat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RightSpawn(1.5f));
        StartCoroutine(LeftSpawn(0.5f));
        StartCoroutine(UpSpawn(1));
        StartCoroutine(DownSpawn(2));

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

    public IEnumerator RightSpawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GameObject RightArrow = BeatController.instance.PoolRight.Get();
    }

    public IEnumerator UpSpawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GameObject UptArrow = BeatController.instance.PoolUp.Get();
    }

    public IEnumerator DownSpawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GameObject DownArrow = BeatController.instance.PoolDown.Get();
    }
}
