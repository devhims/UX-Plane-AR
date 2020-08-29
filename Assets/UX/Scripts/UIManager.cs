using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class UIManager : MonoBehaviour
{
    [SerializeField] ARPlaneManager planeManager;
    [SerializeField] ARUXAnimationManager animationManager;

    bool foundPlane;
    bool goalReached;

    void OnEnable()
    {
        PlaceObjectsOnPlane.OnObjectPlaced += () => animationManager.FadeOffUI();
        ARSession.stateChanged += ShowFindPlaneUI;
    }

    void ShowFindPlaneUI(ARSessionStateChangedEventArgs args)
    {
        if (args.state == ARSessionState.SessionTracking)
        {
            animationManager.ShowCrossPlatformFindAPlane();
        }
    }

    void Update()
    {
        if (PlanesFound() && !foundPlane)
        {
            // Hide scan ground anim
            animationManager.FadeOffUI();
            foundPlane = true;
        }

        if (foundPlane && animationManager.fadeOffComplete && !goalReached)
        {
            // Show tap anim
            animationManager.ShowTapToPlace();
            goalReached = true;
        }
    }

    bool PlanesFound()
    {
        return planeManager?.trackables.count > 0;
    }
}

