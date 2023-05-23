using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class UnityAds : MonoBehaviour
{
    public Button _showRewardedAdButton;
    private string gameID = "5070804";
    string rewardedplacementIdIos = "Rewarded_iOS";
    string interstitialAdID = "Interstitial_iOS";
    public GameObject AdNotReadyPanel;
    public bool isRewardedAdReady = false;
    public bool isInterstitialAdReady = false;

    public static UnityAds _instance; 


    private void Start()
    {
        //Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, true);
        LoadRewaredAd();
        LoadInterstitialAd();
        //StartCoroutine(BannerAdsWhenReady());
        //Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

    }

    
    /*
    IEnumerator BannerAdsWhenReady()
    {
        yield return new WaitForSeconds(0.5f);
        OnBannerLoaded();

    }
    public void LoadBannerAds()
    {
        BannerLoadOptions bannerLoadOptions = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
        Advertisement.Banner.Load("Banner_Android", bannerLoadOptions);
    }

    public void OnBannerLoaded()
    {
        Debug.Log("Banner Loaded");
        Advertisement.Banner.Show("Banner_Android");
    }

    public void OnBannerError(string message)
    {
        Debug.Log("Banner Error:{message}");
    }

    */


    public void ShowInterstialAd()
    {
        if(isInterstitialAdReady)
        {
            Advertisement.Show(interstitialAdID);
        }
        else
        {
            Debug.Log("Interstitial Ad is not ready yet");
        }
    }

    public void ShowRewardedAds()
    {
        if(isRewardedAdReady)
        {
            Advertisement.Show(rewardedplacementIdIos);
        }
        else
        {
            Debug.Log("Rewarded Ad is not ready yet");
            StartCoroutine(AdNotReadyPanels());
        }
    }


    IEnumerator AdNotReadyPanels()
    {
        yield return new WaitForSeconds(0.2f);
        AdNotReadyPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        AdNotReadyPanel.SetActive(false);
    }

    private void Update()
    {

    }

    public void OnUnityAdsReady(string placementId)
    {
       if(placementId==rewardedplacementIdIos)
        {
            isRewardedAdReady = true;
            Debug.Log("Rewarded Ads are now Ready");
        }
       else if(placementId==interstitialAdID)
        {
            isInterstitialAdReady = true;
            Debug.Log("Interstitial Ads are now Ready");
        }
        
    }
    

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Unity Ads Error:" + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //ads playing
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
       if(placementId==rewardedplacementIdIos)
        {
            if(showResult==ShowResult.Finished)
            {
                CurrencyManager._instance.AddCoins(1000);
            }
            else if(showResult==ShowResult.Skipped)
            {
                Debug.Log("ADs Skipped");
            }
            LoadRewaredAd();
        }
    }

    public void LoadRewaredAd()
    {
        isRewardedAdReady = false;
        Advertisement.Load(rewardedplacementIdIos);
    }

    public void LoadInterstitialAd()
    {
        isInterstitialAdReady = false;
        Advertisement.Load(interstitialAdID);
    }


}

