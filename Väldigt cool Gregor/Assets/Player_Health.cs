using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Health : MonoBehaviour
{

    [SerializeField] private Image healthbar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = PersistantData.playerHealth / 5f;

        if (PersistantData.playerHealth  <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
