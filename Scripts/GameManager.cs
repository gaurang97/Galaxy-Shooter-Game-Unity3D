using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver = true;
    public GameObject player;
    private UImanager _uimanager;

    private void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        

    }
    private void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                gameOver = false;

                _uimanager.hide();
            }
        }
    }
}
