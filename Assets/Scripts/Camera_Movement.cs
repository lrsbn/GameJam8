using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public float cameraDistance = -10f;
    public float heightDif = -1f;

    private float startHeight;

    void Start() {
        startHeight = transform.parent.position.y + heightDif;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.parent.position.x, startHeight + transform.parent.position.y * 0.05f, cameraDistance);
    }
}
