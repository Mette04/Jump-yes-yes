using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI.Table;

public class player_move : MonoBehaviour
{
    public float playerSpeed = 5;
    public Vector2 moveInput;
    public Rigidbody2D rb2d;
    public float jumpForce;
    public int jumpTime;

    public GameObject[] sprites;
    public int hvilkenSprite;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip pow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(moveInput.x * playerSpeed, rb2d.linearVelocity.y) ;
    }

    public void OnMove(InputValue dir)
    {
        moveInput = dir.Get<Vector2>();
    }

 
    public void OnJump()
    {

        if (jumpTime > 0)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTime--;
            audioSource.PlayOneShot(jumpSound);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Floor"))
        {
            jumpTime = 2;
        }

        if (collision.CompareTag("PickUp") && hvilkenSprite < sprites.Length-1)
        {
            AudioSource.PlayClipAtPoint (pow, transform.position, 0.7f);
            collision.gameObject.SetActive(false);
            hvilkenSprite++;
            activateSprite();
        }
    }

    public void activateSprite()
    {
        foreach (GameObject g in sprites)
        {
            g.SetActive(false);
        }
        sprites[hvilkenSprite].SetActive(true);
    }
}

