using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimedRewardsInterface : MonoBehaviour {

    public Button buttonClaim;
    public Text textInfo;

    public GameObject panelReward;
    public Text textReward;
    public Image imageRewardMessage;

    private TimedRewards timedRewards;

    void Awake() {
        timedRewards = GetComponent<TimedRewards>();
    }

    void Start() {
        InitializeAvailableRewardsUI();
        buttonClaim.interactable = false;

        buttonClaim.onClick.AddListener(() => {
            buttonClaim.interactable = false;

            ClaimReward();
        });
    }

    void OnEnable() {
        timedRewards.onCanClaim += OnCanClaim;
        timedRewards.onInitialize += OnInitialize;
    }

    void OnDisable() {
        if (timedRewards != null) {
            timedRewards.onCanClaim -= OnCanClaim;
            timedRewards.onInitialize -= OnInitialize;
        }
    }

    private void UpdateTextInfo() {
        if (timedRewards.timer.TotalSeconds > 0)
            textInfo.text = timedRewards.GetFormattedTime();
    }

    // Initializes the UI List based on the rewards size
    private void InitializeAvailableRewardsUI() {
        // Initializes only when there is more than one Reward

    }

    // The action on the button when claiming the reward
    private UnityEngine.Events.UnityAction OnClickReward() {
        return () => {
            ClaimReward();
        };
    }

    // Claimed the reward
    private void ClaimReward() {
        timedRewards.ClaimReward();

        panelReward.GetComponent<Canvas>().enabled = true;
        panelReward.GetComponent<ScaleAnim>().Anim();
        for(int i=0;i<GameManager._instance.audioClips.Length;i++)
        {
            GameManager._instance.audioSource.clip = GameManager._instance.audioClips[5];
            GameManager._instance.audioSource.Play();
        }
        var reward = timedRewards.GetReward(timedRewards.rewardId);
        var rewardQt = reward.reward;

        imageRewardMessage.sprite = reward.sprite;
        textReward.text = rewardQt + "x";

        if (reward.type == TimedRewards.RewardType.COINS)
        {
            CurrencyManager._instance.AddCoins(rewardQt);
        } 
        else 
        {
            for (int i = 0; i < GameManager._instance.boosters.Length; i++)
            {
                if (GameManager._instance.boosters[i].type == reward.type)
                {
                    GameManager._instance.boosters[i].AddItem(rewardQt);
                }
            }
        }
    }

    // Delegate
    // Updates the UI
    private void OnCanClaim() {
        buttonClaim.interactable = true;
        textInfo.text = "Reward Ready!";
        if (!buttonClaim.gameObject.activeInHierarchy)
            buttonClaim.gameObject.SetActive(true);
    }

    private void OnInitialize(bool error, string errorMessage) {
        if (!error) {
            StartCoroutine(TickTime());
        }
    }

    private IEnumerator TickTime() {
        for (; ; ) {
            // Updates the timer UI
            timedRewards.TickTime();
            UpdateTextInfo();
            yield return null;
        }
    }
}