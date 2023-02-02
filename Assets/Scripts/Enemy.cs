using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.name == "Laser(Clone)") {
        //    Destroy(this.gameObject);
        //}

        if (collision.gameObject.CompareTag("Laser") == true)
        {
            Destroy(this.gameObject);
        }

        Debug.Log(collision.gameObject.name);
    }
}
