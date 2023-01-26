using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1;
    float horizontalInput;
    float verticalInput;
  
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position);
        //Moves object to the set position
        //transform.position = new Vector3(0,0,0);

        //Moves an object up by 2 units
        //transform.position = transform.position + new Vector3(0, 2, 0);
        //transform.position += new Vector3(0, 2, 0);

        //Moves the object up by 2 unites
        //transform.Translate(0, 2, 0);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * Time.deltaTime * speed);
    
        if(transform.position.x >= 5)
        {
            transform.position = new Vector3(-5, transform.position.y, 0);
        } else if(transform.position.x <= -5)
        {
            transform.position = new Vector3(5, transform.position.y, 0);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 0), 0);

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
    }
}
