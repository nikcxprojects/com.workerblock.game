using UnityEngine;

public class MovementCamera : MonoBehaviour
{

    [SerializeField] private float _time;
    [SerializeField] private float length;
    [SerializeField] private float _speedX;
    
    private float minY;
    private float refA;

    private void Start()
    {
        minY = transform.position.y;
    }
    
    private void FixedUpdate()
    {
        var x = Mathf.SmoothDamp(transform.position.x, transform.position.x + _speedX,  ref refA, 0.1f);
        var y = Mathf.PingPong(Time.time * _time, length) + minY;
        transform.position = new Vector3(x, y, transform.position.z);    }
}
