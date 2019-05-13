using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : MonoBehaviour
{
    [SerializeField]
        public float MaxVelocity = 25;
        public float Mass = 0;
        public float MaxForce = 15;

        private Vector3 velocity;
        public Transform target;
 
	// Use this for initialization
	void Start ()
    {
        velocity = Vector3.zero;
	}
    
	// Update is called once per frame
	void Update ()
    {
        var desiredVelocity = target.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
	}
}
