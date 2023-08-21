using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uIManager : MonoBehaviour
{
    private GameObject player;      // Pemain yang ingin diikuti

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
