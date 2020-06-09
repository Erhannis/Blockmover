using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAdsScript : MonoBehaviour { 

    string gameIdIOS = "3642017"; // iOS
    string gameIdAndroid = "3642016"; // Android
    bool testMode = false;

    string placementId = "PlayScreen";

    void Start () {
        if (Application.platform == RuntimePlatform.IPhonePlayer) {
            Advertisement.Initialize (gameIdIOS, testMode);
            StartCoroutine (ShowBannerWhenReady ());
        }
        if (Application.platform == RuntimePlatform.Android) {
            Advertisement.Initialize (gameIdAndroid, testMode); 
            StartCoroutine (ShowBannerWhenReady ());
        }
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (placementId)) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show (placementId);
    }
}