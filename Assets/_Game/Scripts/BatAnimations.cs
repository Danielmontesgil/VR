using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAnimations : MonoBehaviour {

    private Animator[] animator;
    [SerializeField]
    private GameObject[] children;
    [SerializeField]
    private float velocity;

    private void Awake()
    {
        animator = new Animator[12];
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i] = children[i].GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
        if(collision.gameObject.tag=="Player")
        {
            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].SetBool("startMove", true);
            }
        }
    }
}
