using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BoardManager : S_Singleton<S_BoardManager>
{
    public S_Space startingSpace;

    [SerializeField] private float _playerSpeed = 5f;
    public float playerSpeed 
    { 
        get
        {
            return _playerSpeed;
        }
        private set
        {
            _playerSpeed = value;
        }
    }

    public S_GameEvent boardStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// sets board to starting state
    /// </summary>
    public void StartGame()
    {
        boardStartEvent.Raise();
    }
}
