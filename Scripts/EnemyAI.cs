using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private float _speed = 5f;
    private GameObject _enemyPrefab;
    public UImanager _uimanager;
    [SerializeField]
    private GameObject _enemyExplosion;
    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private GameObject _playerExplosion;
    
    [SerializeField]
    private AudioClip clip;
    
    // Use this for initialization
    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);


        
        if (transform.position.y < -6)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
            Player _player = other.GetComponent<Player>();
            if (_player != null)
            {

                _player.Damage();
                _uimanager.UpdateScore();
                
                Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
                
                Destroy(this.gameObject);

            }
            

        }
        if (other.tag == "Laser")
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
            Destroy(other.gameObject);
            _uimanager.UpdateScore();
            
            Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
        }
        
        

    }
}
