﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewSetting2 : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
