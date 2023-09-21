using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobInfo : MonoBehaviour
{
    [Serializable]
    public struct TimePerStar
    {
        public int s5;
        public int s4;
        public int s3;
        public int s2;
        public int s1;
    }
    public TimePerStar timePerStar;

    private Outline _outline;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);

        _outline = GetComponent<Outline>();
    }

    public void DisplayJob()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        _outline = GetComponent<Outline>();
    }

    public void BeginJob()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void EndJob()
    {
        Debug.Log("Job end");
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
