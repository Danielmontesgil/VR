using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float velocity;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private Rigidbody rb;

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetKey(KeyCode.W))
        {
            rb.velocity = camera.transform.forward * velocity * Time.deltaTime;
        }
    }
}
