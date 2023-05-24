using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
/*
public class Ads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
#if UNITY_ANDROID
        Advertisement.Initialize("3262627");
#elif Unity_IOS
        Advertisement.Initialize("3262626");
#endif
    }

    public float timeToShowInterstitial = 180f;
    float timer;

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (timer > timeToShowInterstitial) {
            timer = 0;

            Advertisement.Show();
        }
    }

    public void WatchAdForEnergy() {
        ShowOptions sO = new ShowOptions();
        sO.resultCallback = EnergyCallBack;

        Advertisement.Show("rewardedVideo", sO);
    }

    private void EnergyCallBack(ShowResult result) {
        if (result == ShowResult.Finished) {
            EnergySystem._instance.AddEnergy(1);
        }
    }
*/

