using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _rigidbody.velocity = _joystick.Direction * _speed;
    }
    
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Target"))
        {
            collider.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Target"))
        {
            collider2D.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
