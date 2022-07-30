using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinHiz;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, coinHiz, 0));
    }

}
