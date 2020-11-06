using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public float movementInput;
    public float movementSpeed = 10f;
    Rigidbody2D rb;
    private float movement = 0f;

    private bool isStarted = false;

    private float topScore = 0.0f;

    public Text scoreText;
    public Text startText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        {
            isStarted = true;
            startText.gameObject.SetActive(false);
        }

        if(isStarted == true)
        {
            rb.gravityScale = 1f;

            if (movementInput < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }

            movement = Input.GetAxis("Horizontal") * movementSpeed;

            if (rb.velocity.y > 0 && transform.position.y > topScore)
            {
                topScore = transform.position.y;
            }

            scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        }


    }

    void FixedUpdate()
    {
        if (isStarted == true)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = movement;
            rb.velocity = velocity;
            movementInput = Input.GetAxis("Horizontal");
        }

    }
}
