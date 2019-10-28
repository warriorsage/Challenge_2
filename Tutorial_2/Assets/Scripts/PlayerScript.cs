using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;

    public float speed;
    public Text lives;
    public Text score;
    public Text winText;
    public Text loseText;
    private int scoreValue = 0;
    private int livesValue = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text = "";
        loseText.text = "";

    
        lives.text = livesValue.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

        if (Input.GetKey("escape"))
            Application.Quit();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetCountText();


        }
        else if (collision.collider.tag == "Enemy")
        {
            scoreValue -= 0;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetCountText();

            livesValue -= 1;
            lives.text = livesValue.ToString();

        }


        if (livesValue == 0)
        {
            Destroy(gameObject);

        }
    }
    void SetCountText()
    {
        if (livesValue <= 1)
        {
            loseText.text = "You Lose Game Over";
        }
        if (scoreValue == 4)
        {
            transform.position = new Vector2(48f, 3f);
        }


        if (scoreValue >= 8)
        {
            winText.text = "You Win! Game created by Juan Quevedo";
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            }
        }
    }

    
    

       
            
            
}

    

