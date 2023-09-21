using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [Header("Player")]
    public PlayerInfo _playerInfo;

    public Transform player;
    
    [Header("Jobs")]
    public List<JobInfo> jobsToDo;
    public List<JobInfo> jobsComplete;

    [Header("Jobs")] 
    public GameObject pauseScreen;
    [SerializeField] private bool isPaused;
    void Start()
    {
        NextJob();
        Resume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0;
                pauseScreen.SetActive(true);

            }
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

    }

    public void NextJob()
    {
        if (jobsToDo.Count == 0)
        {
            Debug.Log("all jobs done");
            SceneManager.LoadScene(2);
            return;
        }

        JobInfo currentJob = jobsToDo[0];
        currentJob.DisplayJob();
        jobsComplete.Add(currentJob);
        jobsToDo.Remove(currentJob);
    }
}
