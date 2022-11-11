using UnityEngine;
using System.Collections;

/**
 *	Rotate (game object | camera | etc.) in <direction> at <speed> around the <target> looking at point
 */

public class RotateAround : MonoBehaviour
{
	[Tooltip("Transform to rotate around")]
    public Transform target;
    private Vector3 targetPosition;

	[Tooltip("Axis of rotation (defaults is Y-axis))")]
    public Vector3 axis = Vector3.one;

	[Tooltip("Speed of rotation")]
    public float speed = 10.0f;

	public bool lookAtTarget = true;


    void Start()
    {
        // get target's coords
        targetPosition = target.position;
	    // make the camera look to it
		if (lookAtTarget)  transform.LookAt(targetPosition);
    }

    void Update() => RotateObject();

	void RotateObject (){
		// rotates around "targetPosition" coords, about axis * speed modifier
		// https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html
		transform.RotateAround(targetPosition, axis, Time.deltaTime * speed);
	}


}
