using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Canvas canvasWin;
    [SerializeField]
    private Canvas canvasNeed;
    [SerializeField]
    private Canvas canvasPerma;

    private float time;
    private float timeNeed;
    private float chests;

	void Start () {

	}
	
	void Update () {
        chests = PlayerMovement.count;

        if (canvasWin.gameObject.activeInHierarchy)
        {
            time += Time.deltaTime;
        }
        if (time >= 4)
        {
            SceneManager.LoadScene(0);
        }
        if (canvasNeed.gameObject.activeInHierarchy)
        {
            timeNeed += Time.deltaTime;
        }
        if (timeNeed >= 4)
        {
            canvasNeed.gameObject.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (chests >= 6)
            {
                canvasWin.gameObject.SetActive(true);
                canvasPerma.gameObject.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            else
            {
                canvasNeed.gameObject.SetActive(true);
                canvasPerma.gameObject.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = false;
            }
        }
    }
}
