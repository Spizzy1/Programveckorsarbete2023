using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vtfaubidns : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Item item = new SpearItem(1);
        print(item.GetAmount());
    }
}
