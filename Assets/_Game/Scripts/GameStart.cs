using UnityEngine;

public class GameStart : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    private float time;

	void Start () {
        player.GetComponent<PlayerMovement>().enabled = false;
    }
	
	void Update () {
        time += Time.deltaTime;
        if (time >= 8)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            gameObject.SetActive(false);
        }
	}
}
