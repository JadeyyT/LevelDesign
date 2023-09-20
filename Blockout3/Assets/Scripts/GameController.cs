using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Player")]
    public PlayerInfo _playerInfo;

    public Transform player;
    
    [Header("Jobs")]
    public List<JobInfo> jobsToDo;
    public List<JobInfo> jobsComplete;
    
    


    void NextJob()
    {
        if (jobsToDo.Count == 0)
        {
            Debug.Log("all jobs done");
            return;
        }

        JobInfo currentJob = jobsToDo[0];
        currentJob.BeginJob();
        jobsComplete.Add(currentJob);
        jobsToDo.Remove(currentJob);
    }
}
