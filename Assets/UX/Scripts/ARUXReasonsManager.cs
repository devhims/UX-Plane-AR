using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARUXReasonsManager : MonoBehaviour
{
    public bool showNotTrackingReasons = true;

    [SerializeField] GameObject _reasonParent;
    [SerializeField] TMP_Text _reasonText;
    [SerializeField] Image _reasonIcon;
    [SerializeField] Sprite _initRelocalSprite;
    [SerializeField] Sprite _motionSprite;
    [SerializeField] Sprite _lightSprite;
    [SerializeField] Sprite _featuresSprite;
    [SerializeField] Sprite _unsupportedSprite;
    [SerializeField] Sprite _noneSprite;

    NotTrackingReason _currentReason;
    bool _sessionTracking;

    const string k_InitRelocalText = "Initializing augmented reality.";
    const string k_MotionText = "Try moving at a slower pace.";
    const string k_LightText = "It’s too dark. Try going to a more well lit area.";
    const string k_FeaturesText = "Look for more textures or details in the area.";
    const string k_UnsupportedText = "AR content is not supported.";
    const string k_NoneText = "Wait for tracking to begin.";
    
    void OnEnable()
    {
        ARSession.stateChanged += ARSessionOnstateChanged;

        if (!showNotTrackingReasons)
        {
            _reasonParent.SetActive(false);
        }
    }

    void OnDisable()
    {
        ARSession.stateChanged -= ARSessionOnstateChanged;
    }

    void ARSessionOnstateChanged(ARSessionStateChangedEventArgs args)
    {
        _sessionTracking = args.state == ARSessionState.SessionTracking ? true : false;
        Debug.Log(args.state);

        if (showNotTrackingReasons)
        {
            if (_sessionTracking)
            {
                HideReason();
            }
            else
            {
                ShowReason();
            }
        }
    }

    void ShowReason()
    {
        _currentReason = ARSession.notTrackingReason;
        SetReason();
        _reasonParent.SetActive(true);
    }

    void HideReason()
    {
        _reasonParent.SetActive(false);
    }

    void SetReason()
    {
        switch (_currentReason)
        {
            case NotTrackingReason.Initializing:
            case NotTrackingReason.Relocalizing:
                SetReasonUI(k_InitRelocalText, _initRelocalSprite);
                break;
            case NotTrackingReason.ExcessiveMotion:
                SetReasonUI(k_MotionText, _motionSprite);
                break;
            case NotTrackingReason.InsufficientLight:
                SetReasonUI(k_LightText, _lightSprite);
                break;
            case NotTrackingReason.InsufficientFeatures:
                SetReasonUI(k_FeaturesText, _featuresSprite);
                break;
            case NotTrackingReason.Unsupported:
                SetReasonUI(k_UnsupportedText, _unsupportedSprite);
                break;
            case NotTrackingReason.None:
                SetReasonUI(k_NoneText, _noneSprite);
                break;
        }
    }

    void SetReasonUI(string reasonText, Sprite reasonSprite)
    {
        _reasonText.text = reasonText;
        _reasonIcon.sprite = reasonSprite;
    }

    public void TestForceShowReason(NotTrackingReason reason)
    {
        _currentReason = reason;
        SetReason();
        _reasonParent.SetActive(true);
    }
    
}
