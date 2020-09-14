# UX-Plane-AR
The objective of this project is to prepare a simplified version of [Unity's AR Foundation Demos - UX Onboarding](https://assetstore.unity.com/packages/templates/ar-foundation-demos-onboarding-ux-164766) asset for **plane detection based AR experiences**. 

## Demo:
 <img src="Images/demo.gif" width="350">

## How to build?
1. Use Unity **2019.4** and above with Android/iOS build modules downloaded and installed from Unity Hub.
2. Clone/Download and open the project in Unity
3. Change the build platform to Android/iOS
4. Settings for Android are already in place, just do a build and run. Check the AR Foundation specific platform settings for iOS.

## Features:
1. Explore UXMain scene inside Assets/UX/Scenes to learn more. Included are the modified versions of `UIManager.cs`, `ARUXReasonsManager.cs`, and `ARUXAnimationManager.cs`.
2. `FadeOffUI()` and `FadeOnUI()` public functions can be called for animating the UI elements.  
3. `ShowCrossPlatformFindAPlane()`function shows the UI elements for guiding users to scan the ground. 
4. `ShowTapToPlace()` function shows the UI elements for interaction with the AR planes. 

5. `ARUXReasonsManager.cs` script is tested to handle UI for the following runtime scenarios:
- Tracking initialisation
- Device moving fast
- Low lighting
- Low feature availability

## Other Assets Used:
[DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)


