using TMPro;
using UnityEngine;

public class level_trig : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text text;

    public AudioSource audioSource;
    public AudioClip bo;
    void Start()
    {
        ClearText();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D c)
    {
       if (c.tag == "Player" && c.GetComponent<player_move>().hvilkenSprite ==4)
        {
            gameManager.LoadLevel("WinScreen");
        }
       else
        {
            audioSource.PlayOneShot(bo);
            text.text = "Hmm, seems like you have too many corners?";
            Invoke("ClearText",4);
        }
    }

    public void ClearText()
    {
        text.text = "";
    }
}
