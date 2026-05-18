using UnityEngine;
using UnityEngine.Serialization;

public class Move : MonoBehaviour
{
    public GameObject goal;
    public float speed = 10.0f;
    private Vector3 _direction;
    public float minChaseDistance = 2.0f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // Call AI logic in late update so it occurs after other movement/physics calculations.
    void LateUpdate()
    {
        _direction = goal.transform.position - transform.position;
        transform.LookAt(goal.transform.position);
        if (_direction.sqrMagnitude > minChaseDistance*minChaseDistance)
        {
            Vector3 velocity = Time.deltaTime * speed * _direction.normalized;
            transform.Translate(velocity, Space.World);
        }
    }
}
