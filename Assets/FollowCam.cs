using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform target;
    private Vector3 offset;

    void Awake()
    {
       offset = transform.position = target.position;

    }

    private void LateUpdate()
    {
       transform.position = target.position + offset;
    }

}
