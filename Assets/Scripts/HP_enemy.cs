using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HP_enemy : MonoBehaviour
{
    [SerializeField]
    public int HP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(HP<=0)
        {
            print("im ded");
            transform.position = new Vector3(0, 0, 0);
        }
    }
   
   
}

