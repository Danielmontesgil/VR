using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAnimations : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Collider collider;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("startIdle",true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            animator.SetBool("startMove", true);
        }
    }
}
