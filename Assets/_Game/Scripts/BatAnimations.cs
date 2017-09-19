using UnityEngine;

public class BatAnimations : MonoBehaviour {

    private bool move;
    private Animator[] animator;
    private float time;

    [SerializeField]
    private GameObject[] children;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private GvrAudioSource bats;

    private void Awake()
    {
        move = false;
        animator = new Animator[12];
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i] = children[i].GetComponent<Animator>();
        }
    }

    private void Start()
    {
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].SetBool("startMove", true);
        }
    }

    private void Update()
    {
        if (move == true)
        {
            time += 1 * Time.deltaTime;
            transform.position += transform.forward * velocity * Time.deltaTime;
        }

        if (time >= 2)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].SetActive(true);
            }
            bats.Play();
            move = true;
        }
    }
}
