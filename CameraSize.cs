using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public Vector2 ReferenceResolution = new Vector2(1280f, 600f);

    // Use this for initialization
    void Start()
    {
        float aspect = (float)Screen.width / Screen.height;
        float newHeight = ReferenceResolution.x / aspect;
        Camera.main.orthographicSize = newHeight / 200f;
    }

}