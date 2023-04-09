using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioClip _targetComplete;

    [SerializeField] private Sprite _complete;
    private Sprite _default;

    private SpriteRenderer _renderer;
    
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _default = _renderer.sprite;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Finish"))
        {
            AudioManager.getInstance().PlayAudio(_targetComplete);
            _gameManager.TargetComplete(true);
            _renderer.sprite = _complete;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag.Equals("Finish"))
        {
            _gameManager.TargetComplete(false);
            _renderer.sprite = _default;
        }
    }
}
