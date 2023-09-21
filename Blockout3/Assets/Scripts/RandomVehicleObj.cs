using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVehicleObj : MonoBehaviour
{
    public GameObject[] bodies;
    
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, bodies.Length);

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].SetActive(i==rand);
        }
    }

}
