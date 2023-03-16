using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] int health = 3;
    bool isSheildActive = false;
    float objectScaleUnit;
    GameManager gameManager;
    [SerializeField] float speed = 1f;

    [Header("Shooting")]
    [SerializeField] float fireRate = 1f;
    float fireTimer = 0;
    [SerializeField] GameObject laserPrefab,tripleShotLaserPrefab;

    [Header("Power Ups")]
    [SerializeField] float powerUpDuration = 3f;
    [SerializeField] float speedIncreament = 5f;
    bool isSpeedPowerUpActive = false;
    bool isTripleShotPowerUpActive = false;

    [Header("Visual Effects")]
    [SerializeField] GameObject[] wingFire;
    [SerializeField] GameObject sheildPowerUp;

    [Header("Audio Effect")]
    [SerializeField] AudioClip fireLaserAudioClip;
    [SerializeField] AudioClip explotionAudioClip;
    AudioSource audioSource;

    //UI
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        objectScaleUnit = transform.localScale.x / 2;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Debug.Log(gameManager.worldSizeWidth);
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * Time.deltaTime * speed);

        if (transform.position.x >= gameManager.worldSizeWidth + objectScaleUnit)
        {
            transform.position = new Vector3(-gameManager.worldSizeWidth - objectScaleUnit, transform.position.y, 0);
        }
        else if (transform.position.x <= -gameManager.worldSizeWidth - objectScaleUnit)
        {
            transform.position = new Vector3(gameManager.worldSizeWidth + objectScaleUnit, transform.position.y, 0);
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -gameManager.worldSizeHight + objectScaleUnit, 0), 0);
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Time.time > fireTimer)
            {
                //Player Audio
                audioSource.clip = fireLaserAudioClip;
                audioSource.Play();
                fireTimer = Time.time + fireRate;
                //Debug.Log("Time:" + Time.time);
                //Debug.Log("Fire Time: " + fireTimer);
                if(isTripleShotPowerUpActive == false)
                {
                    GameObject myLaser = Instantiate(laserPrefab, transform.position, transform.rotation);
                    myLaser.GetComponent<Laser>().isPlayerLaser = true;
                } else
                {
                    Instantiate(tripleShotLaserPrefab, transform.position, transform.rotation);
                }
            }
            //laser.transform.position = transform.position;
            //laser.SetActive(true);
        }
    }

    IEnumerator ActivateSpeedPowerUp()
    {
        if(isSpeedPowerUpActive == false)
        {
            isSpeedPowerUpActive = true;
            speed = speed + speedIncreament;
            yield return new WaitForSeconds(powerUpDuration);
            speed = speed - speedIncreament;
            isSpeedPowerUpActive = false;
        }
    }

    IEnumerator ActivateTripleShotPowerUp()
    {
        isTripleShotPowerUpActive = true;
        yield return new WaitForSeconds(powerUpDuration);
        isTripleShotPowerUpActive = false;
    }

    private void TakeDamage()
    {
        if(isSheildActive == true)
        {
            ActivateSheild(false);
        } else
        {
            health--;
            if(health == 2) {
                wingFire[0].SetActive(true);
            }
            if(health == 1) {
                wingFire[1].SetActive(true);
            }
            if (health < 0)
            {
                health = 0;
                uIManager.DisplayGameOverPanle(true);
                Destroy(this.gameObject);
            }
            uIManager.UpldateHealthUI(health);
        }
    }

    private void ActivateSheild(bool value)
    {
        isSheildActive = value;
        sheildPowerUp.SetActive(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Enemy") == true)
        {
            TakeDamage();
        }

        if(collision.gameObject.CompareTag("EnemyLaser") == true)
        {
            audioSource.clip = explotionAudioClip;
            audioSource.Play();
            TakeDamage();
        }

        if(collision.gameObject.CompareTag("ShieldPowerUp") == true)
        {
            Debug.Log("I have sheild!");
            ActivateSheild(true);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("SpeedPowerUp") == true)
        {
            StartCoroutine(ActivateSpeedPowerUp());
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("TripleShotPowerUp") == true)
        {
            StartCoroutine(ActivateTripleShotPowerUp());
            Destroy(collision.gameObject);
        }
    }
}


//Debug.Log(transform.position);
//Moves object to the set position
//transform.position = new Vector3(0,0,0);

//Moves an object up by 2 units
//transform.position = transform.position + new Vector3(0, 2, 0);
//transform.position += new Vector3(0, 2, 0);

//Moves the object up by 2 unites
//transform.Translate(0, 2, 0);


//if(transform.position.y >= 0)
//{
//    transform.position = new Vector3(transform.position.x, 0, 0);
//}else if(transform.position.y <= -4.4f)
//{
//    transform.position = new Vector3(transform.position.x, -4.4f, 0);
//}
//transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
//if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
//{
//    //move up
//    transform.Translate(Vector3.up * Time.deltaTime * speed);
//} else if (Input.GetKey(KeyCode.DownArrow))
//{
//    //move down
//    transform.Translate(Vector3.down * Time.deltaTime * speed);
//} else if (Input.GetKey(KeyCode.LeftArrow))
//{
//    //move left
//    transform.Translate(Vector3.left * Time.deltaTime * speed);
//} else if (Input.GetKey(KeyCode.RightArrow))
//{
//    //move right
//    transform.Translate(Vector3.right * Time.deltaTime * speed);
//}