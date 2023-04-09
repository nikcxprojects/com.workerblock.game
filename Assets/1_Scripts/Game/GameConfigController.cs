using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GameConfigController : MonoBehaviour
{

    [SerializeField] private GameConfig[] _configs;
    [SerializeField] private GameConfig _config;

    public void OpenLevel(int id)
    {
        _config.Level = _configs[id].Level;
        _config.LevelName = _configs[id].LevelName;
        _config.TargetCount = _configs[id].TargetCount;
        
        SceneLoader.getInstance().LoadScene("Game");
    }

    public void NextLevel()
    {
        var id = Int32.Parse(Regex.Match(_config.LevelName, @"\d+").Value);
        if(id < _configs.Length) OpenLevel(id);
        else SceneLoader.getInstance().LoadScene("MainMenu");
    }

}
