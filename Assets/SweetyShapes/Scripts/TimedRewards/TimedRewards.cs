using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class TimedRewards : DailyRewardsCore {

    public static TimedRewards _instance;

    public DateTime lastRewardTime;     // The last time the user clicked in a reward
    public TimeSpan timer;
    public int rewardId;

    public List<Reward> rewards;

    public delegate void OnCanClaim();              // When the player can claim the reward
    public OnCanClaim onCanClaim;

    public delegate void OnClaimPrize(int index);   // When the player claims the prize
    public OnClaimPrize onClaimPrize;

    private bool canClaim;              // Checks if the user can claim the reward

    // Needed Constants
    private const string TIMED_REWARDS_TIME = "TIMED_REWARD_TIME";
    private const string FMT = "O";

    public enum RewardType { COINS, ITEM_SHUFFLER, MORE_MOVES, BOMB }

    private void Awake() {
        _instance = this;
    }

    void Start() {
        canClaim = false;

        rewardId = PlayerPrefs.GetInt("TIMED_REWARD_ID", 0);
        StartCoroutine(InitializeTimer());
    }

    // Initializes the timer in case the user already have a player preference
    private IEnumerator InitializeTimer() {
        yield return StartCoroutine(InitializeDate());

        LoadTimerData();

        if (onInitialize != null)
            onInitialize();

        CheckCanClaim();

    }

    void LoadTimerData() {
        string lastRewardTimeStr = PlayerPrefs.GetString(GetTimedRewardsTimeKey());

        if (!string.IsNullOrEmpty(lastRewardTimeStr)) {
            lastRewardTime = DateTime.ParseExact(lastRewardTimeStr, FMT, CultureInfo.InvariantCulture);
            timer = (lastRewardTime - currentDateTime).Add(TimeSpan.FromSeconds(rewards[rewardId].timeToClaimReward));
        } else {
            timer = TimeSpan.FromSeconds(rewards[rewardId].timeToClaimReward);
        }
    }

    protected override void OnApplicationPause(bool pauseStatus) {
        base.OnApplicationPause(pauseStatus);
        LoadTimerData();
        CheckCanClaim();
    }

    public override void TickTime() {
        base.TickTime();

        if (isInitialized) {
            // Keeps ticking until the player claims
            if (!canClaim) {
                timer = timer.Subtract(TimeSpan.FromSeconds(Time.unscaledDeltaTime));
                CheckCanClaim();
            }
        }
    }

    public void CheckCanClaim() {
        if (timer.TotalSeconds <= 0) {
            canClaim = true;
            if (onCanClaim != null)
                onCanClaim();
        } else {
            // We need to save the player time every tick. If the player exits the game the information keeps logged
            PlayerPrefs.SetString(GetTimedRewardsTimeKey(), currentDateTime.Add(timer - TimeSpan.FromSeconds(rewards[rewardId].timeToClaimReward)).ToString(FMT));
        }
    }

    private string GetTimedRewardsTimeKey() {
        return TIMED_REWARDS_TIME;
    }

    // The player claimed the prize. We need to reset to restart the timer
    public void ClaimReward() {
        PlayerPrefs.SetString(GetTimedRewardsTimeKey(), currentDateTime.Add(timer - TimeSpan.FromSeconds(rewards[rewardId].timeToClaimReward)).ToString(FMT));
        timer = TimeSpan.FromSeconds(rewards[rewardId].timeToClaimReward);

        canClaim = false;

        if (onClaimPrize != null)
            onClaimPrize(rewardId);

        rewardId++;
        PlayerPrefs.SetInt("TIMED_REWARD_ID", rewardId);
    }

    public string GetFormattedTime() {
        if (timer.Days > 0)
            return string.Format("{0:D2} days {1:D2}:{2:D2}:{0:D3}", timer.Days, timer.Hours, timer.Minutes, timer.Seconds);
        else
            return string.Format("{0:D2}:{1:D2}:{2:D2}", timer.Hours, timer.Minutes, timer.Seconds);
    }

    // Resets the Timed Rewards. For debug purposes
    public void Reset() {
        PlayerPrefs.DeleteKey(GetTimedRewardsTimeKey());
        canClaim = true;
        timer = TimeSpan.FromSeconds(0);

        if (onCanClaim != null)
            onCanClaim();
    }

    // Returns a reward from an index
    public Reward GetReward(int index) {
        return rewards[index];
    }
}
