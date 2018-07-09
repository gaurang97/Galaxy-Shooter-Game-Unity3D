using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public float speed1;
    public int powerupId;
    [SerializeField]
    private AudioClip audio;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed1 = Random.Range(5f, 7f);
        transform.Translate(Vector3.down * Time.deltaTime * speed1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position, 1f);
            Player _player = other.GetComponent<Player>();
            if (_player != null)
            {
                if (powerupId == 0)
                {
                    _player.triplepowerupshoton();
                }
                else if (powerupId == 1)
                {
                    _player.speedbooston();
                }
                else if (powerupId == 2)
                {

                    _player.sheildon();
                }

            }
            Destroy(this.gameObject);
        }

    }
}











