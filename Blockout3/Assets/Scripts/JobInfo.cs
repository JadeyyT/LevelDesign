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
    
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void BeginJob()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void EndJob()
    {
        Debug.Log("Job end");
        
        Start();// remove ------------------------------
        
    }
}
