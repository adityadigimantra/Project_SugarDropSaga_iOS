using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnim : MonoBehaviour {

    public Transform tr;

    private void OnEnable() {
        StartCoroutine(ScaleUp());
    }

    public void Anim() {
        StartCoroutine(ScaleUp());
    }

    IEnumerator ScaleUp() {
        tr.localScale = Vector3.zero;

        float t = 0;

        while (t < 1) {
            t += Time.deltaTime * 2;
            tr.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);

            yield return null;
        }
    }
}
