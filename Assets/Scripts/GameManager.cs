using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float worldSizeHight;
    public float worldSizeWidth;
    // Start is called before the first frame update
    void Start()
    {
        worldSizeHight = Camera.main.orthographicSize;
        worldSizeWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
