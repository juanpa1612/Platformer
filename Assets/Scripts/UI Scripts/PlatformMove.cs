using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Vector3 newPosition;
    private Vector3 posA;
    private Vector3 posB;

    public float speed;
    public Transform transformB;
    public Transform childTransform;

    void Start()
    {
        newPosition = posB;
        posB = transformB.localPosition;
        posA = childTransform.localPosition;
    }
    private void Move ()
    {
        childTransform.localPosition = Vector3.Lerp(childTransform.localPosition, newPosition, 3);
        if (Vector3.Distance(childTransform.localPosition, newPosition) <= 0.1)
        {
            ChangePosition();
        }
    } 
    private void ChangePosition()
    {
        newPosition = newPosition != posA ? posA : posB;
    }
    private void Update()
    {
        Move();
    }


}
