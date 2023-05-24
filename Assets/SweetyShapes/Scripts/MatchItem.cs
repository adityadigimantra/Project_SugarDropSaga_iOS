using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchItem : MonoBehaviour {

    public int id;
    bool isDestroyed;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseUpAsButton() {
        if (!GameManager._instance.canClickItem) return;

        CheckBomb();
        for(int i=0;i<GameManager._instance.audioClips.Length;i++)
        {
            GameManager._instance.audioSource.clip = GameManager._instance.audioClips[2];
            GameManager._instance.audioSource.Play();
        }
        ChainReaction(true);
    }


    /// <summary>
    /// Returns the items which has the same ID around a 0.46f circle
    /// </summary>
    /// <returns>The neighbouring same items.</returns>
    public List<Collider2D> GetNeighbouringSameItems() {
        List<Collider2D> cols = new List<Collider2D>();
        foreach (Collider2D c in Physics2D.OverlapCircleAll(transform.position, .46f)) {
            if (c.GetComponent<MatchItem>() != null && c.GetComponent<MatchItem>().id == id) {
                cols.Add(c);
            }
        }

        return cols;
    }

    public void ChainReaction(bool isStarter) {
        if (isDestroyed) return;

        List<Collider2D> cols = GetNeighbouringSameItems();

        if (cols.Count < 2 && isStarter) {
            return;
        }

        if (isStarter) {
            GameManager._instance.DoFillUp();

            var effect = Instantiate(GameManager._instance.GetRandomExplosion());
            effect.transform.position = transform.position + Vector3.forward * .01f;

            GameManager._instance.DecreaseMoves();
        }

        StartCoroutine(ChainAnim());

        DestroyItem();

        foreach (Collider2D c in cols) {
            c.GetComponent<MatchItem>().ChainReaction(false);
        }
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

    void DestroyItem() {
        isDestroyed = true;
        ItemSpawner._instance.currentItemNumber--;

        if (GameManager._instance.GetGameType() == GameManager.GameType.CollectTarget)
            GameManager._instance.DecreaseTargetCollection(id);

        GameManager._instance.IncreaseScore();
    }

    void CheckBomb() {
        if (!GameManager._instance.isBombActivated)
            return;

        DestroyItem();
        
        Destroy(gameObject);
        
        var effect = Instantiate(GameManager._instance.GetRandomExplosion());
        effect.transform.position = transform.position + Vector3.forward * .01f;

        foreach (Booster b in GameManager._instance.boosters) {
            if (b.type == TimedRewards.RewardType.BOMB) {
                b.OnClickBomb();
                
                b.AddItem(-1);
            }
        }

    }
}
