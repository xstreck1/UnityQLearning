// Created by Dr. Adam Streck, 2023, adam.streck@gmail.com

using System;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScreenCapture.CaptureScreenshot(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png");
            Debug.Log("Screenshot " + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png");
        }
    }
}