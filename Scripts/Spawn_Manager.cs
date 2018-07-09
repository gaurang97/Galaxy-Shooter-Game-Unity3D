using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour {
    [SerializeField]
    private GameObject _enemySpawn;
    [SerializeField]
    private GameObject[] _powerUps;
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {

        

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    IEnumerator enemySpawn()
    {
        while (gameManager.gameOver == false)
        {
            float randomTime = Random.Range(3.0f, 5.0f);

            Instantiate(_enemySpawn, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }



    }
    IEnumerator powerSpawn()
    {
        int randompower = Random.Range(0, 3);
        while (gameManager.gameOver == false)
        {
            Instantiate(_powerUps[randompower], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(7.0f);

        }



    }
    public void startSpawn()
    {
        StartCoroutine(enemySpawn());
        StartCoroutine(powerSpawn());
    }


    // Update is called once per frame

}

