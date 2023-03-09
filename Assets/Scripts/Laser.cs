using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float playerLaserSpeed = 5f;
    [SerializeField] float enemyLaserSpeed = 10f;
    public bool isEnemyLaser, isPlayerLaser;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnemyLaser == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * enemyLaserSpeed);
        }

        if(isPlayerLaser == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * playerLaserSpeed);
        }


        //if(transform.position.y >= 6)
        //{
        //    Destroy(this.gameObject);
        //}
    }

 
}
