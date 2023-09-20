using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject gps;
    public GameObject panel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gps.SetActive(false);
            panel.SetActive(false);
        }
    }
}
