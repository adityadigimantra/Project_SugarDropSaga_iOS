
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used on animals if the gametype is ESCAPE
/// </summary>
public class TargetAnimal : MonoBehaviour {

    public int id;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator ChainAnim() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;

        float t = 0;

        Vector3 startPos = transform.position;

        while (t < 1) {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, new Vector3(-2.7f, 6), t);
            transform.localScale = Vector3.Lerp(Vector3.one * 1.2f, Vector3.one * .3f, t);

            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Boundary" || collision.gameObject.name.Contains("Boundary")) {
            GameManager._instance.DecreaseTargetCollection(id);

            StartCoroutine(ChainAnim());

            var effect = Instantiate(GameManager._instance.GetRandomExplosion());
            effect.transform.position = transform.position + Vector3.forward * .01f;

            ItemSpawner._instance.currentItemNumber--;

            GameManager._instance.CheckTargetDone();
        }
    }
}
