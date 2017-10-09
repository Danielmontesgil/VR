using UnityEngine;
using UnityEngine.UI;

public class CollectChests : MonoBehaviour {

    [SerializeField]
    private Text chests;

    [HideInInspector]
    public float count;
    
    public void PointerEnter(GameObject outline)
    {
        outline.GetComponent<Renderer>().material.SetFloat("_Outline", 0.02f);
        this.GetComponent<PlayerMovement>().enabled = false;
    }

    public void PointerExit(GameObject outline)
    {
        outline.GetComponent<Renderer>().material.SetFloat("_Outline", 0f);
        this.GetComponent<PlayerMovement>().enabled = true;
    }

    public void PointerClick(GameObject chest)
    {
        count += 1;
        chests.text = count.ToString();
        chest.SetActive(false);
        this.GetComponent<PlayerMovement>().enabled = true;
    }
}
