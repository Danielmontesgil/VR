using System.Collections;
using UnityEngine;
using UnityEngine.VR;

public class TorchManager : MonoBehaviour {

    [SerializeField][Range(0,1)]
    private float density;
    [SerializeField]
    private float timer;
    [SerializeField]
    private GameObject parasite;
    [SerializeField]
    private Camera cam;

    private float darkness = 0.6f;
    private IEnumerator lerpCorroutineEnter;
    private IEnumerator lerpCorroutineExit;

    public float newTimer;

    private void Start()
    {
        newTimer = timer;   
    }

    private void Update()
    {
        if (parasite.gameObject.activeInHierarchy)
        {
            VRDevice.DisableAutoVRCameraTracking(cam, true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            StopAllCoroutines();
            StartCoroutine(LerpCorroutine(-1, density, darkness));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Light")
        {
            StopAllCoroutines();
            StartCoroutine(LerpCorroutine(1, density, darkness));
        }
    }
    
    IEnumerator LerpCorroutine(float negative, float densityy, float darknesss)
    {
        while (negative > 0 ? newTimer < timer : newTimer > 0)
        {
            newTimer += negative * Time.deltaTime;
            RenderSettings.fogDensity = Mathf.Lerp(densityy, darknesss, newTimer / timer);
            yield return null;
        }

    }
}
