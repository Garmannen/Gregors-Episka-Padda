using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;

public class LadderMovement : MonoBehaviour
{
    [SerializeField] private float vertical;
    [SerializeField] private bool isLadder;
    [SerializeField] private bool isClimbing;
    public Player_Movement player_Movement;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            //Debug.Log("Text: " + "kuk");
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            
            rb.velocity = new Vector2(rb.velocity.x, vertical * 8);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            //Debug.Log("Text: " + "1kuk1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
