using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour {

    [SerializeField][Range(0,1)]
    private float density;
    [SerializeField]
    private float timer;
    private float darkness = 0.86f;
    private IEnumerator lerpCorroutineEnter;
    private IEnumerator lerpCorroutineExit;

    public float newTimer;

    private void Start()
    {
        newTimer = timer;   
        //lerpCorroutineEnter = LerpCorroutine(1, density, darkness);
        //lerpCorroutineExit = LerpCorroutine(-1, density, darkness);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            //newTimer = timer;
            StopAllCoroutines();
            StartCoroutine(LerpCorroutine(-1, density, darkness));
            Debug.Log(RenderSettings.fogDensity);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Light")
        {
            //newTimer = 0;
            StopAllCoroutines();
            StartCoroutine(LerpCorroutine(1, density, darkness));
            Debug.Log(RenderSettings.fogDensity);
        }
    }
    
    IEnumerator LerpCorroutine(float negative, float densityy, float darknesss)
    {
        print("entro");
        while (negative > 0 ? newTimer < timer : newTimer > 0)
        {
            print(RenderSettings.fogDensity);
            print(timer);
            newTimer += negative * Time.deltaTime;
            RenderSettings.fogDensity = Mathf.Lerp(densityy, darknesss, newTimer / timer);
            yield return null;
        }

    }
}
