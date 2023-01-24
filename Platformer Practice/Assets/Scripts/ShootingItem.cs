using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingItem : MonoBehaviour
{
    public float speed;
    bool facingRight = true;

    public void Update()
    {
        if(facingRight == true)
        {
            transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
        }
        else if(facingRight == false)
        {
            transform.Translate(transform.right * transform.localScale.x * -speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            return;
        }

        if (collision.GetComponent<ShootingAction>())
        {
            collision.GetComponent<ShootingAction>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
