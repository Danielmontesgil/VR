using UnityEngine;

public class GameStart : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Canvas perma;

    private float time;

	void Start () {
        player.GetComponent<PlayerMovement>().enabled = false;
    }
	
	void Update () {
        time += Time.deltaTime;
        if (time >= 10)
        {
            perma.gameObject.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = true;
            gameObject.SetActive(false);
        }
	}
}
