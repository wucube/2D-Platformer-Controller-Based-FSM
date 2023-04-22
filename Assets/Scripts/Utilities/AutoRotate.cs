using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
