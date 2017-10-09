using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OxigenPoison : MonoBehaviour {

    [SerializeField]
    private Image poisonBar;
    [SerializeField]
    private Image oxygenBar;
    [SerializeField]
    private Canvas lose;
    [SerializeField]
    private GameObject player;

    private float time;
    private float timeLose;

    void Start () {
        time = 0;
	}
	
	void Update () {
        time += Time.deltaTime;
        if (time >= 30)
        {
            poisonBar.fillAmount = 0.1f;
            oxygenBar.fillAmount = 0.9f;
        }
        if (time >= 60)
        {
            poisonBar.fillAmount = 0.2f;
            oxygenBar.fillAmount = 0.8f;
        }
        if (time >= 90)
        {
            poisonBar.fillAmount = 0.3f;
            oxygenBar.fillAmount = 0.7f;
        }
        if (time >= 120)
        {
            poisonBar.fillAmount = 0.4f;
            oxygenBar.fillAmount = 0.6f;
        }
        if (time >= 150)
        {
            poisonBar.fillAmount = 0.5f;
            oxygenBar.fillAmount = 0.5f;
        }
        if (time >= 180)
        {
            poisonBar.fillAmount = 0.6f;
            oxygenBar.fillAmount = 0.4f;
        }
        if (time >= 210)
        {
            poisonBar.fillAmount = 0.7f;
            oxygenBar.fillAmount = 0.3f;
        }
        if (time >= 240)
        {
            poisonBar.fillAmount = 0.8f;
            oxygenBar.fillAmount = 0.2f;
        }
        if (time >= 270)
        {
            poisonBar.fillAmount = 0.9f;
            oxygenBar.fillAmount = 0.1f;
        }
        if (time >= 300)
        {
            poisonBar.fillAmount = 1f;
            oxygenBar.fillAmount = 0.01f;
        }
        if (oxygenBar.fillAmount <= 0.3f)
        {
            oxygenBar.color = Color.red;
        }
        if (poisonBar.fillAmount == 1)
        {
            lose.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (lose.gameObject.activeInHierarchy)
        {
            timeLose += Time.deltaTime;
        }
        if (timeLose >= 4)
        {
            SceneManager.LoadScene(0);
        }
    }
}
