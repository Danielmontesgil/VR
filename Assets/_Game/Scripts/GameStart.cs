using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Canvas perma;
    [SerializeField]
    private AudioClip[] audioInstructions;
    [SerializeField]
    private Text textCanvas;
    [SerializeField]
    private Image imageCanvas;
    [SerializeField]
    private Sprite[] imageInstructions;
    [SerializeField]
    private Image arrow;
    [SerializeField]
    private GvrAudioSource water;
    private GvrAudioSource instructions;
    
    private float time;

	void Start () {
        player.GetComponent<PlayerMovement>().enabled = false;
        instructions = GetComponent<GvrAudioSource>();
        instructions.clip = audioInstructions[0];
        instructions.Play();
        textCanvas.text = "Can you hear me? Hi, I'm Begonia, I speak to you from the base";
        imageCanvas.gameObject.SetActive(false);
        arrow.gameObject.SetActive(false);
    }
	
	void Update () {
        time += Time.deltaTime;
        if (instructions.clip==audioInstructions[0] && time >= 6)
        {
            instructions.clip = audioInstructions[1];
            instructions.Play();
            textCanvas.text = "You are in a cave to look the biggest treasure never seen, to move use control's pad";
            imageCanvas.gameObject.SetActive(true);
            imageCanvas.sprite = imageInstructions[0];
            arrow.gameObject.SetActive(true);
        }
        if (instructions.clip == audioInstructions[1] && time >= 14)
        {
            instructions.clip = audioInstructions[2];
            instructions.Play();
            textCanvas.text = "According to the legend you should follow the water drops' sound to find the exit";
            imageCanvas.gameObject.SetActive(false);
            arrow.gameObject.SetActive(false);
        }
        if (instructions.clip == audioInstructions[2] && time >= 20.5)
        {
            instructions.clip = audioInstructions[6];
            instructions.gainDb = 9f;
            instructions.Play();
        }
        if (instructions.clip == audioInstructions[6] && time >= 22.5)
        {
            instructions.clip = audioInstructions[3];
            instructions.gainDb = 0f;
            instructions.Play();
            textCanvas.text = "But don't forget you can't go out without the six treasure chest";
            imageCanvas.gameObject.SetActive(true);
            imageCanvas.sprite = imageInstructions[1];
            imageCanvas.rectTransform.sizeDelta = new Vector2(1f, 1.22f);
        }
        if (instructions.clip == audioInstructions[3] && time >= 29.5)
        {
            instructions.clip = audioInstructions[4];
            instructions.Play();
            textCanvas.text = "And take care of the poison, after a few time it will be letal";
            imageCanvas.gameObject.SetActive(true);
            imageCanvas.sprite = imageInstructions[2];
            imageCanvas.rectTransform.sizeDelta = new Vector2(1f, 1.29f);
        }
        if (instructions.clip == audioInstructions[4] && time >= 36)
        {
            instructions.clip = audioInstructions[5];
            instructions.Play();
            textCanvas.text = "Unfortunately we don't know who is there with you... Good luck!!";
            imageCanvas.gameObject.SetActive(false);
        }
        if (instructions.clip == audioInstructions[5] && time >= 42)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            perma.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(KeyCode.F))
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            perma.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
