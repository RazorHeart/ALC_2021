using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool hasKey;
    public bool isdoorlocked;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isdoorlocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        //player unlocks the door and exits the room
        if(hasKey && !isdoorlocked )
            {
                print("Left Room");
            }
    }
}
