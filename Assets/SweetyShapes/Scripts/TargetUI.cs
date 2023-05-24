using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour {
    public Text amountText;
    public Image picture;

    public int remainingItemNum;

    public void DecreaseItemNum() {
        if (remainingItemNum <= 0) return;

        remainingItemNum--;
        amountText.text = remainingItemNum + "";

        if (remainingItemNum == 0)
            Debug.Log("Target done");
    }

    public bool IsCompleted() {
        if (remainingItemNum <= 0) return true;

        return false;
    }
}
