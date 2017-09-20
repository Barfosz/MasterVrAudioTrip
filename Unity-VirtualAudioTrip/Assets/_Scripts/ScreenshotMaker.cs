using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ScreenshotMaker : MonoBehaviour {

    SteamVR_Controller.Device left;
    SteamVR_Controller.Device right;

    IEnumerator Start() {
        yield return new WaitForSeconds(1);

        var leftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        var rightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

        left = SteamVR_Controller.Input(leftIndex);
        right = SteamVR_Controller.Input(rightIndex);
    }

    void Update() {
        if(left == null || right == null)
            return;

        if (left.GetHairTriggerDown()) {
            DoScreenshot();
        }
        if (right.GetHairTriggerDown()) {
            DoScreenshot();
        }
    }

    int screenshotId;

    void DoScreenshot() {
        screenshotId++;
        var path = "Assets/Screenshots/Screenshot" + screenshotId + ".png";
        Application.CaptureScreenshot(path);
        Debug.Log("Saving screenshot at path: " + path);
    }
}
