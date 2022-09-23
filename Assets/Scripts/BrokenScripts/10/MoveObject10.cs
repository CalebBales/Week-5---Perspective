using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject10 : MonoBehaviour
{
    // Added in serialize to moveSpeed so it could be altered
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;

    // Added float type to this declaration so the value could be used without error
    float totalMoveDistance;
    Vector3 startingLocation;

    // Start is called before the first frame update
    void Start()
    {
       totalMoveDistance = 10f;
       startingLocation = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       float distanceTraveled = GetDistanceTraveled();

       if (distanceTraveled > totalMoveDistance)
       {
           FlipMoveDirection();
           // Added in the false enable, so the script would stop and not bump into each other
           this.enabled = false;
       }

       gameObject.transform.Translate(moveDirection * moveSpeed);
    }

    void FlipMoveDirection()
    {
       moveDirection = -moveDirection;
       // Added the startingLocation line so that when the flip does happen it only goes back to the actual starting
       // position
       startingLocation = gameObject.transform.position;
    }

    float GetDistanceTraveled()
    {
       return Vector3.Distance(gameObject.transform.position, startingLocation);
    }
}
