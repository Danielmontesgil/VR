using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

    [SerializeField]
    private GameObject parasite;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GvrAudioSource scream;
    [SerializeField]
    private Canvas canvasLose;

    private float time;

	void Start () {
		
	}
	
	void Update () {
        if (parasite.activeInHierarchy || canvasLose.gameObject.activeInHierarchy)
        {
            time += Time.deltaTime;
        }
        if (time >= 2)
        {
            canvasLose.gameObject.SetActive(true);
            parasite.gameObject.SetActive(false);
        }
        if (time >= 5)
        {
            SceneManager.LoadScene(0);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        parasite.gameObject.SetActive(true);
        scream.Play();
    }
}
