using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float fireRate = 2f;
    [SerializeField] float currentFireTime;
    [SerializeField] GameObject laserPrefab;
    Animator animator;
    AudioSource audioSource;
    bool isAlive = true;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Destroy(this.gameObject, 6f);
        fireRate = Random.Range(1, 3);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            Shootin();
        }
    }

    void Shootin() {
        currentFireTime += Time.deltaTime;
        if (currentFireTime > fireRate)
        {
            currentFireTime = 0;
            GameObject myLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAlive == true) {
            if (collision.gameObject.CompareTag("PlayerLaser"))
            {
                Destroy(collision.gameObject);
                StartCoroutine(Death());
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Death());
            }
        }
    }

    IEnumerator Death()
    {
        animator.SetTrigger("Explostion");
        audioSource.Play();
        gameManager.UpdateScore();
        isAlive = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject,2f);
    }


}
