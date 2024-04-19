using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 3;
    [SerializeField] ContactFilter2D groundFilter;
    Vector2 inputDir;
    CapsuleCollider2D coll;
    Rigidbody2D rb;
    bool grounded = false;
    bool jump = false;
    public PersistantData persistantData;

    [SerializeField] TextMeshProUGUI CoinText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        persistantData = new PersistantData();

        //CoinText = GetComponent<TextMeshProUGUI>;
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);

        grounded = coll.IsTouching(groundFilter);

        if (jump)
        {
            Jump();
        }
    }

    public void SetMoveDir(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }

    public void ActivateJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jump = true;
        }
        if (context.performed || context.canceled)
        {
            jump = false;
        }
    }

    private void Jump()
    {
        if (grounded)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            persistantData.PlayerCoins++;
            Destroy(other.gameObject);
        }
    }

    private void PrintText()
    {
        CoinText.text = "Coins " + persistantData.PlayerCoins;
        Debug.Log("Text: " + persistantData.PlayerCoins);
    }
}