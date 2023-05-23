using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySystem : MonoBehaviour {
    public static EnergySystem _instance;

    private void Awake() {
        _instance = this;
    }

    public bool alwaysDecreaseEnergy; //always decrease energy or only after lost level
    public int maxEnergy, minutesToAddEnergy;

    [HideInInspector]
    public int currentEnergy;

    public Text energyText;

    DateTime currentDateTime, lastEnergyTime;

    // Start is called before the first frame update
    void Start() {
        currentDateTime = DateTime.Now;

        if (PlayerPrefs.HasKey("LAST_ENERGY_DATE"))
            lastEnergyTime = DateTime.Parse(PlayerPrefs.GetString("LAST_ENERGY_DATE")); 
        else {
            lastEnergyTime = currentDateTime;
            PlayerPrefs.SetString("LAST_ENERGY_DATE", currentDateTime.ToString());
        }

        currentEnergy = PlayerPrefs.GetInt("CURRENT_ENERGY", maxEnergy);
        energyText.text = currentEnergy + "/" + maxEnergy;
    }

    // Update is called once per frame
    void Update() {
        currentDateTime = currentDateTime.AddSeconds(Time.unscaledDeltaTime);

        if (currentDateTime > lastEnergyTime + TimeSpan.FromMinutes(minutesToAddEnergy)) {
            lastEnergyTime = currentDateTime;
            PlayerPrefs.SetString("LAST_ENERGY_DATE", currentDateTime.ToString());

            if (currentEnergy < maxEnergy)
                AddEnergy(1);

        }
    }

    public void AddEnergy(int n) {
        currentEnergy += n;
        energyText.text = currentEnergy + "/" + maxEnergy;

        PlayerPrefs.SetInt("CURRENT_ENERGY", currentEnergy);
    }

    public void BuyEnergy(int price) {
        if (CurrencyManager._instance.coins < price) {
            MessageHandler._instance.ShowMessage("You do not have enough coins", 2f, Color.red);
            return;
        }

        MessageHandler._instance.ShowMessage("Energy Purchased", 2f, Color.green);

        CurrencyManager._instance.AddCoins(-price);

        AddEnergy(1);
    }
}
