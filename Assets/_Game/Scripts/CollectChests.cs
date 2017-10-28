using UnityEngine;
using UnityEngine.UI;

public class CollectChests : MonoBehaviour {

    [SerializeField]
    private Text chests;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.count += 1;
            chests.text = PlayerMovement.count.ToString();
            this.gameObject.SetActive(false);
        }
    }
}
