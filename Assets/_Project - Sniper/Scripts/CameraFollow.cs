using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerCraft"))
        {
            target = GameObject.FindGameObjectWithTag("PlayerCraft").transform;
        }
    }

    void LateUpdate()
    {
        transform.position = target.position;
        transform.position = new Vector3(transform.position.x, 100, transform.position.z);
        transform.LookAt(target);
    }
}