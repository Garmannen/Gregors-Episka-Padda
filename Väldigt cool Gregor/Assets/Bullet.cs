using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1000f;

    [SerializeField] private float lifeTime = 10f;

    
    


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ladder"))
        {

        }
        else if (other.gameObject.CompareTag("SpeedBoost"))
        {

        }
        else if (other.gameObject.CompareTag("Coins"))
        {

        }
        else if (other.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }



}
