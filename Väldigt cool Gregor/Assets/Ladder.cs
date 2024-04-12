using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour
{

    [SerializeField] GameObject playerPrefab;

    Vector2 howFastClimb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (Input.GetKeyDown("W"))
        {

            howFastClimb = new Vector2(playerPrefab.transform.position.x, playerPrefab.transform.position.y);

            howFastClimb.y = howFastClimb.y + 0.5f;

        }

    }

}
