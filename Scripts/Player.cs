using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool canTripleShot = false;
    public bool canBoostSpeed = false;
    public bool isSheildActive = false;
    [SerializeField]
    private GameObject[] engines;
    private GameObject _canvas;
    [SerializeField]


    public AudioSource audio;
    private int hitcount = 0;
    public GameObject sheildGameObject;
    public int life = 3;
    private UImanager _uimanager;
    private GameManager _gamemanager;
    private Spawn_Manager _spawnmanager;
    private float _speed = 10.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _playerExplosion;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;
    ///// public bool value1 = Input.GetKey("up");
    // public bool value2 = Input.GetKey("down");
    // Use this for initialization
    void Start()
    {
        
           
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        _uimanager.UpdateLives(life);
        
        _spawnmanager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _spawnmanager.startSpawn();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        if (Input.GetKey(KeyCode.Space))
        {
            Shooting();
        }



    }
    private void Shooting()
    {
        if (Time.time > _canFire)
        {
            audio.Play();
            if (canTripleShot == true)
            {

                Instantiate(_tripleShotPrefab, this.transform.position, Quaternion.identity);

            }






            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }


    private void Movement()
    {
        float axes1 = Input.GetAxis("Horizontal");
        float axes2 = Input.GetAxis("Vertical");
        if (canBoostSpeed == true)
        {

            transform.Translate(Vector3.up * Time.deltaTime * _speed * 2 * axes2);
            transform.Translate(Vector3.right * Time.deltaTime * _speed * 2 * axes1);
        }
        else
            transform.Translate(Vector3.up * Time.deltaTime * _speed * axes2);
        transform.Translate(Vector3.right * Time.deltaTime * _speed * axes1);
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -3.75)
        {
            transform.position = new Vector3(transform.position.x, -3.75f, 0);
        }
        else if (transform.position.x > 9.6f)
        {
            transform.position = new Vector3(-9.6f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.6f)
        {
            transform.position = new Vector3(9.6f, transform.position.y, 0);
        }
    }
    public void triplepowerupshoton()
    {
        canTripleShot = true;
        StartCoroutine(Tripleshotstop());
    }
    public IEnumerator Tripleshotstop()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
    public void speedbooston()
    {
        canBoostSpeed = true;
        StartCoroutine(boostStop());
    }
    IEnumerator boostStop()
    {
        yield return new WaitForSeconds(5.0f);
        canBoostSpeed = false;

    }
    public void sheildon()
    {
        isSheildActive = true;
        sheildGameObject.SetActive(true);
       
    }
    public void Damage()
    {
        
        if (isSheildActive == true)
        {
            isSheildActive = false;
            sheildGameObject.SetActive(false);
            
            return;
        }
        hitcount++;
        if (hitcount == 1)
        {
            engines[0].SetActive(true);
        }
        else if (hitcount == 2)
        {
            engines[1].SetActive(true);
        }
        life = life - 1;
        _uimanager.UpdateLives(life);
        if(life < 1)
        {
            Destroy(this.gameObject);
            Instantiate(_playerExplosion, transform.position, Quaternion.identity);
            _uimanager.UpdateLives(life);
            
            _uimanager.show();
            _gamemanager.gameOver = true;
        }
        
    }

}