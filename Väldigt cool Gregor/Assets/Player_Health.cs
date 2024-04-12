using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            //Restarta spelet
        }
    }
}
