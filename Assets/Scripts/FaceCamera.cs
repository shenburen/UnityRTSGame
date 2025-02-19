using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera facingCamera;
    private Transform localTrans;

    private void Start()
    {
        facingCamera = Camera.main;
        localTrans = GetComponent<Transform>();
    }

    private void Update()
    {
        if (facingCamera)
        {
            localTrans.LookAt(2 * localTrans.position - facingCamera.transform.position);
        }
    }
}
