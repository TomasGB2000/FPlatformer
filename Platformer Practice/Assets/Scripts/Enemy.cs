using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   //Creating object detection
    public Transform groundDetectionObj, rightDetectionObj, leftDetectionObj;
    //Used to enable animations
    private SpriteRenderer zomSprite;
    private Animator zomAnim;

    public int maxHealth = 50;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        //used to pull animations
        zomSprite = GetComponent<SpriteRenderer>();
        zomAnim = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {   //detects if there is ground for enemy
        Move();
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetectionObj.position, Vector2.down, 2f);
        RaycastHit2D rightInfo = Physics2D.Raycast(rightDetectionObj.position, Vector2.right, 1f);
        RaycastHit2D leftInfo = Physics2D.Raycast(leftDetectionObj.position, Vector2.left, 1f);

        //rotates enemy if no ground is present
        if (groundInfo.collider == false)
        {
            transform.Rotate(0f, 180f, 0f);
        }
        if (rightInfo.collider == true)
        {
            transform.Rotate(0f, 180f, 0f);          
        }
        if (leftInfo.collider == true)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Move()
    {   //moves the enemy
        transform.Translate(Vector2.right * 2.0f * Time.deltaTime);
        zomAnim.SetBool("isWalking", true);
        zomAnim.SetBool("IdleZombie", false);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pit")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(25);
        }
    }
}
