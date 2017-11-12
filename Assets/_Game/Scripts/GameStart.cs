using UnityEngine;

public class GameStart : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Canvas perma;
    [SerializeField]
    private AudioClip[] audioInstructions;
    private GvrAudioSource instructions;
    
    private float time;

	void Start () {
        player.GetComponent<PlayerMovement>().enabled = false;
        instructions = GetComponent<GvrAudioSource>();
        instructions.clip = audioInstructions[0];
        instructions.Play();
    }
	
	void Update () {
        time += Time.deltaTime;
        if (instructions.clip==audioInstructions[0] && time >= 6)
        {
            instructions.clip = audioInstructions[1];
            instructions.Play();
            Debug.Log(instructions.clip);
            Debug.Log(time);
        }
        if (instructions.clip == audioInstructions[1] && time >= 14)
        {
            instructions.clip = audioInstructions[2];
            instructions.Play();
        }
        if (instructions.clip == audioInstructions[2] && time >= 20.5)
        {
            instructions.clip = audioInstructions[3];
            instructions.Play();
        }
        if (instructions.clip == audioInstructions[3] && time >= 27.5)
        {
            instructions.clip = audioInstructions[4];
            instructions.Play();
        }
        if (instructions.clip == audioInstructions[4] && time >= 34)
        {
            instructions.clip = audioInstructions[5];
            instructions.Play();
        }
        if (instructions.clip == audioInstructions[5] && time >= 40)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            perma.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
