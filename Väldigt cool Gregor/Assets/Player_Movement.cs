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
    public float speed = 7;
    public float jumpForce = 8;
    [SerializeField] ContactFilter2D groundFilter;
    Vector2 inputDir;
    CapsuleCollider2D coll;
    Rigidbody2D rb;
    bool grounded = false;
    bool jump = false;
    public PersistantData persistantData;
    public Vector2 mousePos;

    //Gun variables
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform Firingpoint;
    [Range(0.1f, 1f)][SerializeField] private float fireRate = 0.5f;


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
<<<<<<< Updated upstream
        speed = speed + persistantData.speedBoost;
=======
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        speed = 12 + persistantData.speedBoost;
>>>>>>> Stashed changes

        rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);

        grounded = coll.IsTouching(groundFilter);

        if (jump)
        {
            Jump();
        }

        PrintText();
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
            //Debug.Log("Text: " + persistantData.PlayerCoins);
        }
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            persistantData.speedBoost = persistantData.speedBoost + 4;
            Destroy(other.gameObject);
            Debug.Log("Text: " + speed);
        }
    }

    private void PrintText()
    {
        CoinText.text = "Coins: " + persistantData.PlayerCoins;
    }
}