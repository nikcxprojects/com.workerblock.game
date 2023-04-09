using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawn;


    private GameConfig _gameConfig;
    private GameController _gameController;
    
    private int _currentTargetsCount;

    public void Init(GameConfig config, GameController controller)
    {
        _gameConfig = config;
        _gameController = controller;
        _gameController.SetPlayerPosition(_playerSpawn);
    }

    public void TargetComplete(bool complete)
    {
        _currentTargetsCount += complete ? 1 : -1;
        if (_currentTargetsCount == _gameConfig.TargetCount)
        {
            StartCoroutine(_gameController.FinishGame());
        }
    }
}
