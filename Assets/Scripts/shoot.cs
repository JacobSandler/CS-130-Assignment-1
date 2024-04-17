using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    int counter = 0;
    GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter % 60 == 0)
        {
            //shoot
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
