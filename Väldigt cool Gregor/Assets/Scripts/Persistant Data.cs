using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    public int PlayerCoins = 0;
    //public bool "item" = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
