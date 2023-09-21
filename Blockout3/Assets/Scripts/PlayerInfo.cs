using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    static public float stars;
    public JobInfo currentJob;
    public float timer;
    public GameController _game;

    private void Update()
    {
        if (currentJob)
        {
            timer += Time.deltaTime;
        }
    }

    void BeginJob()
    {
        timer = 0;
    }

    void CompleteJob()
    {
        JobInfo.TimePerStar timePerStar = currentJob.timePerStar;
        
        float collectedStars;
        if (timer < timePerStar.s5)
            collectedStars = 5;
        else if (timer < timePerStar.s4)
            collectedStars = 4;
        else if (timer < timePerStar.s3)
            collectedStars = 3;
        else if (timer < timePerStar.s2)
            collectedStars = 2;
        else if (timer < timePerStar.s1)
            collectedStars = 1;
        else
            collectedStars = 1; // can set to 0

        Debug.Log($"You collected {collectedStars} star(s)");
        stars += collectedStars;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Job"))
        {
            if (!currentJob)
            {
                currentJob = other.GetComponentInParent<JobInfo>();
                currentJob.BeginJob();
                BeginJob();
                return;
            }

            if (other.GetComponentInParent<JobInfo>() == currentJob)
            {
                //Debug.Log("complete");
                currentJob.EndJob();
                CompleteJob();
                currentJob = null;
                _game.NextJob();
                return;
            }
        }
    }
}
