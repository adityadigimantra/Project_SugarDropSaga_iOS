using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public static ItemSpawner _instance;

    private void Awake() {
        _instance = this;
    }


    public int currentItemNumber;

    public int itemNumber; // The maximum number of the items
    public int itemVariations; // How many different types of items can be spawned
    public int animalvariations;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Spawn(itemNumber));
    }

    IEnumerator Spawn(int num) {
        GameManager._instance.canClickItem = false;

        for (int i = 0; i < num; i++) {
            CreateItem();

            yield return new WaitForSeconds(.05f);
        }

        GameManager._instance.canClickItem = true;

        while (gameObject != null) {
            if (itemNumber != currentItemNumber) {
                while (itemNumber != currentItemNumber) {
                    CreateItem();

                    yield return new WaitForSeconds(.05f);
                }
            }

            yield return new WaitForSeconds(.05f);
        }
    }

    void CreateItem()
    {
        GameObject g;

        if (GameManager._instance.GetGameType() == GameManager.GameType.Escape && Random.Range(0, 100) < GameManager._instance.percentToSpawnEscapeTarget)
        {

            int num = Random.Range(0, Mathf.Min(GameManager._instance.animals.Length, GameManager._instance.animalNum));///animalVariations
            Debug.Log("Minimum Value of Animal" + Mathf.Min(GameManager._instance.animals.Length, GameManager._instance.animalNum));
            g = Instantiate(GameManager._instance.animals[num]);
            g.GetComponent<TargetAnimal>().id = num;

        }
        else
        {
            Debug.Log("Items Variations" + itemVariations);

            if(PlayerPrefs.GetInt("WhichLevelSelected")==1)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level1Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level1Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 2)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level2Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level2Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if(PlayerPrefs.GetInt("WhichLevelSelected") == 3)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level3Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level3Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 5)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level5Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level5Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }

            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 6)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level6Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level6Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 7)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level7Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level7Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 8)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level8Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level8Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 10)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level10Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level10Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 12)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level12Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level12Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 14)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level14Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level14Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 15)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level15Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level15Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 17)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level17Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level17Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 18)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level18Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level18Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 19)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level19Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level19Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 20)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level20Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level20Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 21)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level21Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level21Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 22)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level22Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level22Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 23)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level23Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level23Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 25)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level25Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level25Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 26)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level26Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level26Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 28)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level28Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level28Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 29)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level29Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level29Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 30)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level30Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level30Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 31)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level31Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level31Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 32)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level32Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level32Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 34)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level34Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level34Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 36)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level36Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level36Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 38)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level38Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level38Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 39)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level39Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level39Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 40)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level40Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level40Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 41)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level41Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level41Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 42)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level42Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level42Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 43)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level43Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level43Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 44)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level44Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level44Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 46)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level46Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level46Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else if (PlayerPrefs.GetInt("WhichLevelSelected") == 48)
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.Level48Items.Length, itemVariations));

                g = Instantiate(GameManager._instance.Level48Items[num]);
                g.GetComponent<MatchItem>().id = num;
            }
            else
            {
                int num = Random.Range(0, Mathf.Min(GameManager._instance.items.Length, itemVariations));

                g = Instantiate(GameManager._instance.items[num]);
                g.GetComponent<MatchItem>().id = num;
            }

        }

        g.transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(5f, 6f), 0);
        g.transform.SetParent(transform);

        currentItemNumber++;

    }
}
