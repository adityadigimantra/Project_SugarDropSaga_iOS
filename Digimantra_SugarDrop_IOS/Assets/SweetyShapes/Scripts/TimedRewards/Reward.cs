using UnityEngine;



[System.Serializable]
public class Reward {
    public TimedRewards.RewardType type;
    public float timeToClaimReward; // How many seconds until the player can claim the reward
    public int reward;
    public Sprite sprite;
}
