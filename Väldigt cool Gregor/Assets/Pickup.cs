using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private PersistantData persisntatData;

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (CompareTag("Player"))
        {

            Destroy(gameObject, 0.0f);

            persisntatData.speedBoost = 2;

        }


    }


}
