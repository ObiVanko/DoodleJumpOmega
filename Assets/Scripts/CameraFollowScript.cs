using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform doodlePoz;

    void Update()
    {
        if (doodlePoz.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, doodlePoz.position.y, transform.position.z);
        }
    }
}
