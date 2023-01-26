using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToProgamming : MonoBehaviour
{
    //Data Types
    /*
     * int 0,1,2,3
     * float 1.5, -4.1, 3.0
     * Boolean: true (1), false(0)
     * String: Hello
     */
    [SerializeField] private int score = 20;
    [SerializeField] private float health = 100.0f;
    [SerializeField] private bool isPlayerAlive = true;
    [SerializeField] private string message;
    [SerializeField] private int day = 1;
    //[SerializeField] private GameObject square;
    [SerializeField] List<GameObject> SquareList = new List<GameObject>();
    bool isSquareActive = true;
    //array
    [SerializeField] int[] ArrayNumber = new int[10];

    //list
    [SerializeField] List<int> ListNumber = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

        //ArrayNumber[0] = 100;
        //ListNumber.Add(500);

        //score = 100;

        //For loop
        //for(int i=0; i < ArrayNumber.Length; i++)
        //{
        //    Debug.Log(ArrayNumber[i]);
        //}

        foreach (int value in ArrayNumber)
        {
            Debug.Log(value);
        }


        //Debug.Log(message);

        //if(day == 1)
        //{
        //    Debug.Log("Monday");
        //} else if (day == 2)
        //{
        //    Debug.Log("Tuesday");
        //} else if(day == 3)
        //{
        //    Debug.Log("Wednesday");
        //} else
        //{
        //    Debug.Log("Wrong Date");
        //}

        //DateManger(1);
        
       // Debug.Log(Addition(0,1));
        //Debug.Log(DatePrinter());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isSquareActive == true)
            {
                for (int i = 0; i < SquareList.Count; i++)
                {
                    SquareList[i].SetActive(false);
                }
                isSquareActive = false;
            } else {
                for (int i = 0; i < SquareList.Count; i++)
                {
                    SquareList[i].SetActive(true);
                }
                isSquareActive = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            for(int i=0; i < SquareList.Count; i++)
            {
                if (i == 0)
                {
                    SquareList[i].GetComponent<SpriteRenderer>().color = Color.red;
                } else if (i == 1)
                {
                    SquareList[i].GetComponent<SpriteRenderer>().color = Color.green;
                } else if (i == 2)
                {
                    SquareList[i].GetComponent<SpriteRenderer>().color = Color.blue;
                }
                
            }
        }
    }

    private void DateManger(int value)
    {
        switch (value)
        {
            case 1:
                Debug.Log("Monday");
                break;
            case 2:
                Debug.Log("Tuesday");
                break;
            case 3:
                Debug.Log("Wednesday");
                break;
            default:
                Debug.Log("Wrong Date");
                break;
        }
    }

    private string DatePrinter()
    {
        return "Hello!!!";
        //switch (day)
        //{
        //    case 1:
        //        Debug.Log("Monday");
        //        break;
        //    case 2:
        //        Debug.Log("Tuesday");
        //        break;
        //    case 3:
        //        Debug.Log("Wednesday");
        //        break;
        //    default:
        //        return "Wron";
        //        Debug.Log("Wrong Date");
        //        break;
        //}
        
    }

    private int Addition(int value1=1, int value2=1)
    {
        return value1 + value2;
    }
}
