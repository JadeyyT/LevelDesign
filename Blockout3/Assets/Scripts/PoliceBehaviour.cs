using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBehaviour : MonoBehaviour
{
    [SerializeField] private GameController _game;
    [SerializeField] private Transform player;

    [SerializeField]
    private PlayerInfo _playerInfo;
    public Transform orientation;

    

    [Header("Looking")]     
    public float sightDistance;
    public LayerMask whatIsPlayer;

    private bool isPlayerSeen;
    [SerializeField] private float timer;
    
    private void Start()
    {
        _game = GameObject.Find("GameController").GetComponent<GameController>();
        _playerInfo = _game._playerInfo;
        player = _game.player;
    }

    // Update is called once per frame
    void Update()
    {
        LookForPlayer();
    }
    

    void LookForPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceFromPlayer < sightDistance)
        {
            DetectedPlayer();
        }
        else
        {
            LostVision();
        }
    }

    void DetectedPlayer()
    {
        if (!isPlayerSeen)
        {
            Debug.Log("player seen");
            timer = 0;
            isPlayerSeen = true;
            return;
        }

        timer += Time.deltaTime;

    }

    void LostVision()
    {
        if (!isPlayerSeen) return;
        
        isPlayerSeen = false;
        Debug.Log("player lost");
    }
}
