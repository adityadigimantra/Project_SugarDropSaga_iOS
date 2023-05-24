using System;
using UnityEngine;
using System.Collections;

public abstract class DailyRewardsCore : MonoBehaviour {

    public DateTime currentDateTime;

    public delegate void OnInitialize(bool error = false, string errorMessage = "");
    public OnInitialize onInitialize;

    protected bool isInitialized = false;

    public IEnumerator InitializeDate() {
        //WWW www = new WWW("http://worldclockapi.com/api/json/est/now");
        //DateTime currentDateTime = DateTime.Parse(www.text.Replace('/', ' '));

        currentDateTime = DateTime.Now;
        isInitialized = true;

        yield return null;
    }

    public void RefreshTime() {
        currentDateTime = DateTime.Now;
    }

    //Updates the current time
    public virtual void TickTime() {
        if (!isInitialized)
            return;

        currentDateTime = currentDateTime.AddSeconds(Time.unscaledDeltaTime);

    }

    public string GetFormattedTime(TimeSpan span) {
        return string.Format("{0:D2}:{1:D2}:{2:D2}", span.Hours, span.Minutes, span.Seconds);
    }


    protected virtual void OnApplicationPause(bool pauseStatus) {
        if (!pauseStatus)
            RefreshTime();
    }
}