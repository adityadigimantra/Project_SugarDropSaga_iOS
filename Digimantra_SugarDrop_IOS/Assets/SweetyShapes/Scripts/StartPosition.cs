using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {
    public float posX;
    // Start is called before the first frame update
    void Update() {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, GetComponent<RectTransform>().anchoredPosition.y);
    }

}
