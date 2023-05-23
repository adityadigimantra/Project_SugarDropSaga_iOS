using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour {
    public bool maintainWidth = true;
    [Range(-1, 1)]
    public int adaptPosition;


    float defaultWidth;
    float defaultHeight;


    Vector3 CameraPos;

    // Use this for initialization
    void Start() {
        Camera camera = GetComponent<Camera>();
        CameraPos = camera.transform.position;

        defaultHeight = 5;
        defaultWidth = 5f * 720f / 1280f;

        if (maintainWidth) {

            camera.orthographicSize = Mathf.Max(4.2f, defaultWidth / Camera.main.aspect);


            //CameraPos.y was added in case camera in case camera's y is not in 0
            camera.transform.position = new Vector3(CameraPos.x, CameraPos.y + adaptPosition * (defaultHeight - camera.orthographicSize), CameraPos.z);


        } else {
            //CameraPos.x was added in case camera in case camera's x is not in 0
            camera.transform.position = new Vector3(CameraPos.x + adaptPosition * (defaultWidth - camera.orthographicSize * camera.aspect), CameraPos.y, CameraPos.z);

        }
    }

    // Update is called once per frame
    void Update() {




    }
}
