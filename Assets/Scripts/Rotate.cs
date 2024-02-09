using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float random = 200;
    private void Start()
    {
        random = Random.Range(200, 205);
    }   

    void Update()
    {
        transform.Rotate(0, random * Time.deltaTime, 0, Space.World);
    }
}
