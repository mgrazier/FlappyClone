using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    void Awake()
    {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        Advertisement.Initialize("1195694");
        Debug.Log("Unity Ads initialized: " + Advertisement.isInitialized);
        Debug.Log("Unity Ads is supported: " + Advertisement.isSupported);
        Debug.Log("Unity Ads test mode enabled: " + Advertisement.testMode);
    }

    private IEnumerator WaitForAdEditor()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        AudioListener.pause = true;

        yield return null;

        while (Advertisement.isShowing) {
            yield return null;
        }

        AudioListener.pause = false;
        if (currentTimeScale > 0f) {
            Time.timeScale = currentTimeScale;
        } else {
            Time.timeScale = 1f;
        }
    }

    public void ShowStandardVideoAd()
    {
        ShowVideoAd();
    }

    public void ShowVideoAd(Action<ShowResult> adCallBackAction = null, string zone = "")
    {
        StartCoroutine(WaitForAdEditor());

        if (string.IsNullOrEmpty(zone)) {
            zone = null;
        }

        var options = new ShowOptions();
        if (adCallBackAction == null) {
            options.resultCallback = DefaultAdCallBackHandler;
        }
        else {
            options.resultCallback = adCallBackAction;
        }

        if (Advertisement.IsReady(zone)) {
            Debug.Log("Showing ad for zone: " + zone);
            Advertisement.Show(zone, options);
        }
        else {
            Debug.LogWarning("Ad was not ready. Zone: " + zone);
        }
    }

    private void DefaultAdCallBackHandler(ShowResult result)
    {
        switch (result) {
            case ShowResult.Finished:
                Time.timeScale = 1f;
                break;
            case ShowResult.Failed:
                Time.timeScale = 1f;
                break;
            case ShowResult.Skipped:
                Time.timeScale = 1f;
                break;
        }
    }
    public bool IsAdWithZoneIdReady(string zoneId)
    {
        return Advertisement.IsReady(zoneId);
    }
}