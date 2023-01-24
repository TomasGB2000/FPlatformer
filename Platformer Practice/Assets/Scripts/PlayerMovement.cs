using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{   //riging player movement, animations, conditions and access to other scripts
    private bool aKeyPress, dKeyPress, jumpPress, attackPress;
    private Rigidbody2D playerRB;
    private SpriteRenderer starSprite;
    private Animator starAnim;
    public float walkSpeed, jumpSpeed;
    bool isGrounded, isAttacking;
    public GameObject soundManager;
    private SoundManager _soundScript;
    public GameObject gameManger;
    private GameManager _gameManager;

    /***************************************************************************************
* Title: Health Bar
* Author: Brackeys
* Date: 2020
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=859s
***************************************************************************************/
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    void Start()
    {   //setting player movement speed and use of aniamtion
        playerRB = GetComponent<Rigidbody2D>();
        walkSpeed = 30.0f;
        jumpSpeed = 1550.0f;
        starSprite = GetComponent<SpriteRenderer>();
        starAnim = GetComponent<Animator>();
        _soundScript = soundManager.GetComponent<SoundManager>();

        /***************************************************************************************
 * Title: Health Bar
 * Author: Brackeys
 * Date: 2020
 * Code version: N/A
 * Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=859s
 ***************************************************************************************/
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {  //instantly allowing player movement upon button press
        userInput();
        PlayerJump();
        PlayerAttack();
    }

    private void FixedUpdate()
    { //movement of player adjusted to framerate
        MovePlayer();
    }

    void userInput()
    {
        //input buttons of movement assigned
        if (Input.GetKey(KeyCode.A))
        {
            aKeyPress = true;
            starSprite.flipX = true;
        }
        else
        {
            aKeyPress = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dKeyPress = true;
            starSprite.flipX = false;
        }
        else
        {
            dKeyPress = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpPress = true;
        }
        else
        {
            jumpPress = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            attackPress = true;
        }
        else
        {
            attackPress = false;
        }
    }

    void MovePlayer()
    {   //physics and movement enabled
        if (aKeyPress)
        {
            playerRB.AddForce(Vector2.left * walkSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        if (dKeyPress)
        {
            playerRB.AddForce(Vector2.right * walkSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }


        if (aKeyPress || dKeyPress)
        {
            starAnim.SetBool("isRunning", true);
        }
        else
        {
            starAnim.SetBool("isRunning", false);
        }
    }

    void PlayerAttack()
    {
        if (attackPress)
        {
            starAnim.SetBool("isAttacking", true);
        }
        else
        {
            starAnim.SetBool("isAttacking", false);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Destroy(playerRB.gameObject);
            FindObjectOfType<GameManager>().EndGame();
            _soundScript.playLoseSound();
            starAnim.SetBool("isDead", true);
        }
        
    }

    void AddHealth(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);

    }
    void PlayerJump()
    {
        if (isGrounded && jumpPress)
        {
            playerRB.AddForce(Vector2.up * jumpSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
             starAnim.SetBool("isJumping", true);
        }

        if (jumpPress)
        {
            starAnim.SetBool("isJumping", true);
        }

        else
        {
            starAnim.SetBool("isJumping", false);
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        //conditions upon player collision
        if (other.gameObject.tag == "Grounded")
        {
            isGrounded = true;
        }

        else if (other.gameObject.tag == "Pit")
        {
            Destroy(playerRB.gameObject);
            FindObjectOfType<GameManager>().EndGame();
            _soundScript.playLoseSound();
            starAnim.SetBool("isDead", true);
        }

        else if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(25);
            _soundScript.playGruntSound();
        }

        else if (other.gameObject.tag == "Win")
        {
          //  FindObjectOfType<GameManager>().EndGame();
            _soundScript.playWinSound();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //conditions upon player non collision
        if (other.gameObject.tag == "Grounded")
        {
            isGrounded = false;
            _soundScript.playJumpSound();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            _soundScript.playCoinSound();
        }

        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            AddHealth(25);
        }
    }
}

