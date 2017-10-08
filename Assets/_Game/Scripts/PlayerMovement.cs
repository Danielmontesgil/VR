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

    public void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary || OVRInput.Get(OVRInput.Touch.One) || Input.GetKey(KeyCode.W))
        {
            if (!steps.isPlaying)
            {
                steps.Play();
            }
            Move();
        }
        else
        {
            steps.Stop();
        }
    }

    public void Move()
    {
        rb.velocity = cam.transform.forward * velocity * Time.deltaTime;
    }
}
