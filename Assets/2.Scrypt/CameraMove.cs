using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform Playertransform;
    Vector3 offset;
    void Awake()
    {
        Playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - Playertransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Playertransform.position + offset;
    }
}
