using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Ladder : MonoBehaviour
{

    [SerializeField] GameObject playerPrefab;

    Vector2 playerPosY;


    // Start is called before the first frame update
    void Start()
    {
        playerPosY = playerPrefab.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKey(KeyCode.W))
        {

            playerPosY = new Vector2(0, 0.2f);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if ()
        //{
        //    Debug.Log("Trycka W");


        //    howFastClimb = new Vector2(playerPrefab.transform.position.x, playerPrefab.transform.position.y);

        //    howFastClimb.y = howFastClimb.y + 2.5f;

        //}

    }

}
