using UnityEngine;
using System.Collections;

public class Skitter : Enemy {

    public float moveSpeed = 0f;
    public float stopDistance = 0f;

	// Use this for initialization
	new void Start () {
        base.Start(); //Calling Enemy Start

    }

    // Update is called once per frame
    new void Update () {
        base.Update(); //Calling Enemy Update

        SetSpeed(moveSpeed);
        SetStopDistance(stopDistance);
    }
}
