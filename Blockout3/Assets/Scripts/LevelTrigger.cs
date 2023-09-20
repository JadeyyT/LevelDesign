using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTrigger : MonoBehaviour
{
    public GameObject gps;
    [SerializeField] GameObject waypoint;
    [SerializeField] GameObject panel1;
    [SerializeField] GameObject end;
    [SerializeField] GameObject start
        ;
    private void Start()
    {
        start.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            waypoint.SetActive(false);
            gps.SetActive(true);
            panel1.SetActive(true);
            end.SetActive(true);
        }
    }
}
