using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameConfig _gameConfig;

    [SerializeField] private AudioClip _gameFinishClip;
    [SerializeField] private Text _titleText;
    [SerializeField] private GameObject _finishUI;
    [SerializeField] private GameObject _pauseUI;
    
    private GameManager _gameManager;

    private void Start()
    {
        Init();
    }
    
    private void Init()
    {
        _finishUI.SetActive(false);
        _pauseUI.SetActive(false);
        _gameManager = Instantiate(_gameConfig.Level).GetComponent<GameManager>();
        _gameManager.Init(_gameConfig, this);
        _titleText.text = _gameConfig.LevelName;
    }

    public void SetPlayerPosition(Transform spawn)
    {
        _player.transform.position = spawn.position;
    }

    public void Pause(bool pause)
    {
        _pauseUI.SetActive(pause);
    }
    
    public IEnumerator FinishGame()
    {
        AudioManager.getInstance().PlayAudio(_gameFinishClip);
        
        yield return new WaitForSeconds(1.5f);
        
        _finishUI.SetActive(true);
        _finishUI.transform.Find("Panel").Find("Text").GetComponent<Text>().text = _gameConfig.LevelName;
    }
}
