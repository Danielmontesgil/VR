using UnityEngine;
using UnityEngine.VR;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private GvrAudioSource steps;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Rigidbody rb;
    [HideInInspector]
    public static float count=0f;

    public void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary || OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKey(KeyCode.W))
        {
            if (!steps.isPlaying)
            {
                steps.Play();
            }
            Move();
        }
        else
        {
            if (steps.isPlaying)
            {
                steps.Stop();
            }
        }
    }

    public void Move()
    {
        rb.velocity = cam.transform.forward * velocity * Time.deltaTime;
    }
}
