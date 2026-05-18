using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject goal;
    public float speed = 10.0f;
    private Vector3 _direction;
    public float arrivalThreshold = 2.0f;
    public float fieldOfView = 20.0f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // Call AI logic in late update so it occurs after other movement/physics calculations.
    void LateUpdate()
    {
        _direction = goal.transform.position - transform.position;
        if (Vector3.Angle(_direction, transform.forward) > fieldOfView/2)
        {
            transform.LookAt(goal.transform.position);
            if (_direction.sqrMagnitude > arrivalThreshold * arrivalThreshold)
            {
                Vector3 velocity = Time.deltaTime * speed * _direction.normalized;
                transform.Translate(velocity, Space.World);
            }
        }
    }
}
