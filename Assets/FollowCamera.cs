using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    //This camera should be the same position as the car
    void LateUpdate()
    {
        if(thingToFollow.transform.position.x > -54.6f && thingToFollow.transform.position.x < 6.8f)
        transform.position = new Vector3(thingToFollow.transform.position.x, this.transform.position.y, -10);
        if(thingToFollow.transform.position.y < 6f && thingToFollow.transform.position.y > -30f)
        transform.position = new Vector3(this.transform.position.x, thingToFollow.transform.position.y, -10);

    }
}
