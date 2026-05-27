using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace PetZombie
{
    public class ZombieFollower : MonoBehaviour
    {
        public GameObject goal;
        public float speed = 10.0f;
        public float minChaseDistance = 2.0f;
        public float maxChaseDistance = 10.0f;
        public float fieldOfView = 20.0f;
    
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        // Call AI logic in late update so it occurs after other movement/physics calculations.
        void LateUpdate()
        {
            Vector3 targetPosXZ = new Vector3(goal.transform.position.x, transform.position.y, goal.transform.position.z);
            Vector3 direction = targetPosXZ - transform.position;
   
            if ((Vector3.Angle(direction, transform.forward) <= fieldOfView/2) && (direction.sqrMagnitude > minChaseDistance * minChaseDistance) && (direction.sqrMagnitude < maxChaseDistance*maxChaseDistance))
            {
                transform.LookAt(targetPosXZ);
                Vector3 velocity = Time.deltaTime * speed * direction.normalized;
                transform.Translate(velocity, Space.World);
            }
            
        }
    }
}
