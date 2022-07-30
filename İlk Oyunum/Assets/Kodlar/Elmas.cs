using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elmas : MonoBehaviour
{
    public int Elmashiz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Elmashiz, 0));
    }
}
