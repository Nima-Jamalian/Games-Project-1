using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float fireRate = 2f;
    [SerializeField] float currentFireTime;
    [SerializeField] GameObject laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 6f);
        fireRate = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        Shootin();
    }

    void Shootin() {
        currentFireTime += Time.deltaTime;
        if (currentFireTime > fireRate)
        {
            currentFireTime = 0;
            GameObject myLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            myLaser.GetComponent<Laser>().isEnemyLaser = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.name == "Laser(Clone)") {
        //    Destroy(this.gameObject);
        //}

        if (collision.gameObject.CompareTag("Laser") == true)
        {
            if(collision.GetComponent<Laser>().isPlayerLaser == true)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
        //Debug.Log(collision.gameObject.name);
    }
}
