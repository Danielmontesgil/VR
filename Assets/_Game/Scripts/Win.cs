using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Canvas canvasWin;

    private float time;

	void Start () {
	}
	
	void Update () {
        if (canvasWin.gameObject.activeInHierarchy)
        {
            time += Time.deltaTime;
        }
        if (time >= 2)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvasWin.gameObject.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
