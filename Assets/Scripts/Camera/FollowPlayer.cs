using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speedCamera = 1f;
    // Update is called once per frame
    void Update()
    {
        Vector3 positionPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, positionPos, speedCamera * Time.deltaTime);
    }
}
