using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager _instance;

    public enum GameType { CollectTarget, Score, Escape }
    public enum BoosterType { ITEM_SHUFFLER, MORE_MOVES, BOMB }

    public GameObject[] items; //The items for the gamefield
    [Header("Items According to Levels")]
    public GameObject[] Level1Items;
    public GameObject[] Level2Items;
    public GameObject[] Level3Items;
    public GameObject[] Level5Items;
    public GameObject[] Level6Items;
    public GameObject[] Level7Items;
    public GameObject[] Level8Items;
    public GameObject[] Level10Items;
    public GameObject[] Level12Items;
    public GameObject[] Level14Items;
    public GameObject[] Level15Items;
    public GameObject[] Level17Items;
    public GameObject[] Level18Items;
    public GameObject[] Level19Items;
    public GameObject[] Level20Items;
    public GameObject[] Level21Items;
    public GameObject[] Level22Items;
    public GameObject[] Level23Items;
    public GameObject[] Level25Items;
    public GameObject[] Level26Items;
    public GameObject[] Level28Items;
    public GameObject[] Level29Items;
    public GameObject[] Level30Items;
    public GameObject[] Level31Items;
    public GameObject[] Level32Items;
    public GameObject[] Level34Items;
    public GameObject[] Level36Items;
    public GameObject[] Level38Items;
    public GameObject[] Level39Items;
    public GameObject[] Level40Items;
    public GameObject[] Level41Items;
    public GameObject[] Level42Items;
    public GameObject[] Level43Items;
    public GameObject[] Level44Items;
    public GameObject[] Level46Items;
    public GameObject[] Level48Items;

    public GameObject[] animals; //for the ESCAPE game type

    public GameObject[] explosionEffects;

    public Text movesText;
    int currentMoves = 10; //how many moves the player has

    LevelPrefab level; //the current level

    // [HideInInspector]
    public int[] targets;

    public TargetUI[] targetUIs;

    public Booster[] boosters;

    public GameObject winPanel, loosePanel;

    public bool canClickItem = true; //if it is false, the player cannot click on the items

    [HideInInspector]
    public bool isBombActivated;
    public GameObject bombTopBar;

    [Header("Score Target")]
    public GameObject scoreBar;
    public Image fillImage;
    public Text percentText;
    int currentScore;
    public Text CurrentScoreText;
    string empty = "0";

    //variables for the ESCAPE game type
    [HideInInspector]
    public int percentToSpawnEscapeTarget;
    [HideInInspector]
    public int animalNum;

    [Header("Tutorial Panel for Levels")]

    public GameObject TutorialPanel;

    public Sprite[] itemsImages;

    public Sprite[] animalsImages;

    public GameObject[] PanelImagesCTC;

    public GameObject[] PanelImagesEscapeAni;

    public GameObject collectTargetContent;

    public GameObject fillbarContent;

    public GameObject escapeContent;

    public GameObject MovesTextForFBC;

    public GameObject ScoreToReachtext;

    public GameObject MovesTextForCTC;

    public GameObject MovesTextForEscapeAnim;

    public GameObject SettingsButton;

    public GameObject SettingsMenu;

    [Header("Sounds")]
    public AudioClip[] audioClips;
    public AudioSource MainBgMusic;
    public AudioSource audioSource;
    public GameObject MusicOnImage;
    public GameObject MusicOffImage;
    public bool ispassed = false;
    private void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        targets = new int[3];
        audioSource = GetComponent<AudioSource>();
    }
    public void OpenSettingMenu()
    {
        SettingsMenu.SetActive(true);
    }
    public void CloseSettingMenu()
    {
        SettingsMenu.SetActive(false);
    }


    /// <summary>
    /// Gets the random explosion effect from a public array.
    /// </summary>
    /// <returns>The random explosion.</returns>
    public GameObject GetRandomExplosion() 
    {
        return explosionEffects[Random.Range(0, explosionEffects.Length)];

    }

    public void DecreaseMoves(int n = -1) {
        currentMoves += n;
        movesText.text = currentMoves + "";
        canClickItem = false;
        StartCoroutine(DelayedGameOverCheck());
    }

    public void playButtonSound()
    {
        for(int i=0;i<audioClips.Length;i++)
        {
            
            audioSource.clip = audioClips[8];
            audioSource.Play();
        }
    }
    public void CloseMusicandSound()
    {
        if(MusicOnImage.activeSelf)
        {
            MusicOffImage.SetActive(true);
            MusicOnImage.SetActive(false);
            MainBgMusic.volume = 0;
            audioSource.volume = 0;
        }
        else
        {
            MusicOffImage.SetActive(false);
            MusicOnImage.SetActive(true);
            MainBgMusic.volume = 0.8f;
            audioSource.volume = 0.8f;
        }
        
    }
    public void OpenInstaLink()
    {
        Application.OpenURL("https://www.instagram.com/digimantralabs/");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator DelayedGameOverCheck()
    {

        yield return new WaitForSeconds(0f);
        // for Collect Target and Score Target Type

        //Start------------------------------------------------------------------------------------------------------------------------
        if (IsTargetCompleted())
        {
            winPanel.SetActive(true);
            for(int i=0;i<audioClips.Length;i++)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            ispassed = true;
            Debug.Log("Maine Khola Isse-Delayed wala Coroutine hu mai ");
            if (PlayerPrefs.GetInt("HIGHEST_LEVEL", 1) == LevelManager._instance.GetCurrentLevel() + 1)
            {
                //Making Changes Here check this item.
                if (LevelManager._instance.highestLevel == 50)
                {
                    PlayerPrefs.GetInt("HIGHEST_LEVEL");
                }
                else
                {
                    PlayerPrefs.SetInt("HIGHEST_LEVEL", PlayerPrefs.GetInt("HIGHEST_LEVEL", 1) + 1);
                }
                CurrencyManager._instance.AddCoins(1000);
            }
            yield break;
        }

        if (IsTargetCompleted() && currentMoves == 0)
        {
            winPanel.SetActive(true);
            for (int i = 0; i < audioClips.Length; i++)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            ispassed = true;
            loosePanel.SetActive(false);
            Debug.Log("Maine Khola Isse-Delayed wala Coroutine hu mai ");
            if (PlayerPrefs.GetInt("HIGHEST_LEVEL", 1) == LevelManager._instance.GetCurrentLevel() + 1)
            {
                //Making Changes Here check this item.
                if (LevelManager._instance.highestLevel == 50)
                {
                    PlayerPrefs.GetInt("HIGHEST_LEVEL");
                }
                else
                {
                    PlayerPrefs.SetInt("HIGHEST_LEVEL", PlayerPrefs.GetInt("HIGHEST_LEVEL", 1) + 1);
                }
                CurrencyManager._instance.AddCoins(1000);
            }
            yield break;
        }

        if (currentMoves == 0 && !IsTargetCompleted())
        {
            loosePanel.SetActive(true);
            for (int i = 0; i < audioClips.Length; i++)
            {
                audioSource.clip = audioClips[1];//Fail Sound
                audioSource.Play();
            }
            ispassed = false;
            MainBgMusic.Stop();
            canClickItem = false;
            StartCoroutine(PlayAds());
            //if (!EnergySystem._instance.alwaysDecreaseEnergy)
            //{
            //    EnergySystem._instance.AddEnergy(-1);
            //}
            yield break;
        }

        if (currentMoves == 0)
        {
            //Your Game is Over baby

            loosePanel.SetActive(true);
            for (int i = 0; i < audioClips.Length; i++)
            {
                audioSource.clip = audioClips[1];//Fail Sound
                audioSource.Play();
            }
            ispassed = false;
            canClickItem = false;
            StartCoroutine(PlayAds());

            //if (!EnergySystem._instance.alwaysDecreaseEnergy)
            //{
            //    EnergySystem._instance.AddEnergy(-1);
            //}
            yield break;
        }

        if (IsEscapeTargetCompleted() && currentMoves == 0)
        {
            winPanel.SetActive(true);
            for (int i = 0; i < audioClips.Length; i++)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            ispassed = true;
            loosePanel.SetActive(false);
            canClickItem = false;
            yield break;
        }

        if (!IsEscapeTargetCompleted() && currentMoves == 0)
        {
            loosePanel.SetActive(true);
            for (int i = 0; i < audioClips.Length; i++)
            {
                audioSource.clip = audioClips[1];//Fail Sound
                audioSource.Play();
            }
            ispassed = false;
            canClickItem = false;
            StartCoroutine(PlayAds());
            yield break;
        }
        //End--------------------------------------------------------------------------------------------------------------------------
        canClickItem = true;
    }
    IEnumerator PlayAds()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<UnityAds>().ShowInterstialAd();
    }
    /// <summary>
    /// Called on the winPanel or loosePanel if you click the NEXT button
    /// </summary>
    public void OnClickNext()
    {
        Destroy(level.gameObject);
        if(!ispassed)
        {
            MainBgMusic.Play();
        }
        LevelManager._instance.SetMap();
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
        foreach (GameObject g in LevelManager._instance.GameItems)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in LevelManager._instance.hideInGame)
        {
            g.SetActive(true);
        }
        LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarfor0;
        LevelManager._instance.TopBar.gameObject.transform.GetChild(2).GetComponent<Image>().enabled = true;
        //LevelManager._instance.gameUi.SetActive(false);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene(2);
    }

    public void SetLevel(LevelPrefab l) {
        level = l;

        currentMoves = l.allMoves;
        movesText.text = currentMoves + "";
        CurrentScoreText.text = empty;

        switch (level.gameType)
        {
            //Type-Collect Target
            case GameType.CollectTarget:
                for (int i = 0; i < targetUIs.Length; i++)
                {
                    scoreBar.SetActive(false);

                    if (level.targetCount > i)
                    {
                        targetUIs[i].gameObject.SetActive(true);

                        targetUIs[i].remainingItemNum = level.targetNums[i];
                        targetUIs[i].amountText.text = level.targetNums[i] + "";

                        targetUIs[i].picture.sprite = items[i].GetComponent<SpriteRenderer>().sprite;

                        StartCoroutine(tutoialPanels());

                        if (fillbarContent.activeSelf || escapeContent.activeSelf)
                        {
                            collectTargetContent.SetActive(true);
                            fillbarContent.SetActive(false);
                            escapeContent.SetActive(false);

                        }

                        if (level.targetCount == 1)
                        {
                            LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarFor1;
                            for (int j = 0; j < PanelImagesCTC.Length; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        if (!PanelImagesCTC[j].activeSelf)
                                        {
                                          
                                            Vector2 OneImagePos = new Vector2(6, -48);
                                            PanelImagesCTC[j].SetActive(true);
                                            Debug.Log("Opening Image till here");
                                            PanelImagesCTC[i].gameObject.transform.localPosition = OneImagePos;
                                            PanelImagesCTC[i].GetComponent<Image>().sprite = itemsImages[i];

                                        }

                                        break;
                                    case 1:
                                        PanelImagesCTC[j].gameObject.SetActive(false);
                                        break;
                                    case 2:
                                        PanelImagesCTC[j].gameObject.SetActive(false);
                                        break;
                                }

                            }


                        }

                        if (level.targetCount == 2)
                        {

                            LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarFor2;

                            for (int j = 0; j < PanelImagesCTC.Length; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        if (!PanelImagesCTC[j].activeSelf)
                                        {
                                            PanelImagesCTC[j].SetActive(true);

                                            PanelImagesCTC[j].gameObject.transform.localPosition = new Vector2(-75, -48);
                                            Debug.Log("Target Count 2 Image 1");
                                            PanelImagesCTC[j].GetComponent<Image>().sprite = itemsImages[j];
                                           
                                        }
                                        break;
                                    case 1:
                                        if (!PanelImagesCTC[j].activeSelf)
                                        {
                                            PanelImagesCTC[j].SetActive(true);

                                            PanelImagesCTC[j].gameObject.transform.localPosition = new Vector2(79, -48);
                                            Debug.Log("Target Count 2 Image 2");
                                            PanelImagesCTC[j].GetComponent<Image>().sprite = itemsImages[j];
                                        }

                                        break;
                                    case 2:
                                        PanelImagesCTC[j].gameObject.SetActive(false);
                                        break;
                                }
                            }

                        }

                        if (level.targetCount == 3)
                        {
                            LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarFor3;
                            for (int j = 0; j < PanelImagesCTC.Length; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        if (!PanelImagesCTC[j].activeSelf)
                                        {
                                            PanelImagesCTC[j].SetActive(true);
                                            Debug.Log("Target Count 3 Image 1");
                                            PanelImagesCTC[j].gameObject.transform.localPosition = new Vector2(-140, -45);
                                            PanelImagesCTC[j].GetComponent<Image>().sprite = itemsImages[j];
                                        }
                                        break;
                                    case 1:
                                        if (!PanelImagesCTC[j].activeSelf)
                                        {
                                            PanelImagesCTC[j].SetActive(true);
                                            Debug.Log("Target Count 3 Image 2");
                                            PanelImagesCTC[j].gameObject.transform.localPosition = new Vector2(-7.1f, -48);
                                            PanelImagesCTC[j].GetComponent<Image>().sprite = itemsImages[j];
                                        }
                                        break;
                                    case 2:
                                        if (!PanelImagesCTC[j].activeSelf)
                                        {
                                            PanelImagesCTC[j].SetActive(true);
                                            Debug.Log("Target Count 3 Image 3");
                                            PanelImagesCTC[j].gameObject.transform.localPosition = new Vector2(131, -48);
                                            PanelImagesCTC[j].GetComponent<Image>().sprite = itemsImages[j];
                                        }
                                        break;

                                }
                            }
                        }

                        MovesTextForCTC.GetComponent<Text>().text = FindObjectOfType<LevelPrefab>().allMoves.ToString();

                    }

                    else
                    {
                        targetUIs[i].gameObject.SetActive(false);
                    }
                }
                break;

            //Type-Score fill
            case GameType.Score:

                foreach (TargetUI t in targetUIs)
                {
                    t.gameObject.SetActive(false);
                }
                scoreBar.SetActive(true);
                fillImage.fillAmount = 0;
                percentText.text = "0%";
                LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarfor0;
                StartCoroutine(tutoialPanels());

                if (collectTargetContent.activeSelf || escapeContent.activeSelf)
                {
                    fillbarContent.SetActive(true);
                    collectTargetContent.SetActive(false);
                    escapeContent.SetActive(false);

                }
                MovesTextForFBC.GetComponent<Text>().text = FindObjectOfType<LevelPrefab>().allMoves.ToString();
                ScoreToReachtext.GetComponent<Text>().text = FindObjectOfType<LevelPrefab>().scoreToReach.ToString();
                break;

            case GameType.Escape:
                for (int i = 0; i < targetUIs.Length; i++)
                {
                    scoreBar.SetActive(false);

                    if (level.targetCount > i)
                    {
                        targetUIs[i].gameObject.SetActive(true);

                        targetUIs[i].remainingItemNum = level.targetNums[i];
                        targetUIs[i].amountText.text = level.targetNums[i] + "";

                        targetUIs[i].picture.sprite = animals[i].GetComponent<SpriteRenderer>().sprite;//giving imgaes
                        StartCoroutine(tutoialPanels());

                        if (fillbarContent.activeSelf || collectTargetContent.activeSelf)
                        {
                            escapeContent.SetActive(true);
                            fillbarContent.SetActive(false);
                            collectTargetContent.SetActive(false);
                        }

                        if (level.targetCount == 1)
                        {
                            LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarFor1;
                            for (int j = 0; j < PanelImagesEscapeAni.Length; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        if(!PanelImagesEscapeAni[j].activeSelf)
                                        {
                                            PanelImagesEscapeAni[j].SetActive(true);
                                            PanelImagesEscapeAni[j].gameObject.transform.localPosition = new Vector2(6, -48);
                                            PanelImagesEscapeAni[j].GetComponent<Image>().sprite = animalsImages[j];
                                        }
                                        break;


                                    case 1:
                                        PanelImagesEscapeAni[j].gameObject.SetActive(false);
                                        break;
                                    case 2:
                                        PanelImagesEscapeAni[j].gameObject.SetActive(false);
                                        break;

                                }
                            }
                        }

                        if (level.targetCount == 2)
                        {
                            LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarFor2;
                            for (int j = 0; j < PanelImagesEscapeAni.Length; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        if (!PanelImagesEscapeAni[j].activeSelf)
                                        {
                                            PanelImagesEscapeAni[j].SetActive(true);
                                            PanelImagesEscapeAni[j].gameObject.transform.localPosition = new Vector2(-75, -48);
                                            PanelImagesEscapeAni[j].GetComponent<Image>().sprite = animalsImages[j];
                                        }
                                        break;
                                    case 1:
                                        if (!PanelImagesEscapeAni[j].activeSelf)
                                        {
                                            PanelImagesEscapeAni[j].SetActive(true);
                                            PanelImagesEscapeAni[j].gameObject.transform.localPosition = new Vector2(79, -48);
                                            PanelImagesEscapeAni[j].GetComponent<Image>().sprite = animalsImages[j];
                                        }
                                        break;
                                    case 3:
                                        PanelImagesEscapeAni[j].gameObject.SetActive(false);
                                        break;
                                }
                            }

                        }
                        if (level.targetCount == 3)
                        {
                            LevelManager._instance.TopBar.GetComponent<Image>().sprite = LevelManager._instance.TopPanelBarFor3;
                            for (int j = 0; j < PanelImagesEscapeAni.Length; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        if(!PanelImagesEscapeAni[j].activeSelf)
                                        {
                                            PanelImagesEscapeAni[j].SetActive(true);
                                            PanelImagesEscapeAni[j].gameObject.transform.localPosition = new Vector2(-123, -48);
                                            PanelImagesEscapeAni[j].GetComponent<Image>().sprite = animalsImages[j];
                                        }
                                        break;
                                    case 1:
                                        {
                                            if(!PanelImagesEscapeAni[j].activeSelf)
                                            {
                                                PanelImagesEscapeAni[j].SetActive(true);
                                                PanelImagesEscapeAni[j].gameObject.transform.localPosition = new Vector2(15, -48);
                                                PanelImagesEscapeAni[j].GetComponent<Image>().sprite = animalsImages[j];
                                            }
                                            break;
                                        }
                                    case 2:
                                        if(!PanelImagesEscapeAni[j].activeSelf)
                                        {
                                            PanelImagesEscapeAni[j].SetActive(true);
                                            PanelImagesEscapeAni[j].gameObject.transform.localPosition = new Vector2(148, -48);
                                            PanelImagesEscapeAni[j].GetComponent<Image>().sprite = animalsImages[j];
                                        }
                                        break;
                                }
                            }
                        }
                        MovesTextForEscapeAnim.GetComponent<Text>().text = FindObjectOfType<LevelPrefab>().allMoves.ToString();
                    }

                    else
                    {
                        targetUIs[i].gameObject.SetActive(false);
                    }

                }
                break;
        }

        percentToSpawnEscapeTarget = level.percentToSpawnAnimal;
        animalNum = level.targetCount;

        currentScore = 0;
    }

    IEnumerator tutoialPanels()
    {
        TutorialPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        TutorialPanel.SetActive(false);
        //Closing all Images
        for (int i=0;i<PanelImagesCTC.Length;i++)
        {
            PanelImagesCTC[i].SetActive(false);
        }
        for(int i=0;i<PanelImagesEscapeAni.Length;i++)
        {
            PanelImagesEscapeAni[i].SetActive(false);
        }
        
    }

    /// <summary>
    /// Called from TargetAnimal.cs
    /// </summary>
    public void CheckTargetDone()
    {
        if (IsEscapeTargetCompleted())
        {
            winPanel.SetActive(true);
            if (PlayerPrefs.GetInt("HIGHEST_LEVEL", 1) == LevelManager._instance.GetCurrentLevel() + 1)
            {
                //Making Changes Here check this item.
                if (LevelManager._instance.highestLevel == 50)
                {
                    PlayerPrefs.GetInt("HIGHEST_LEVEL");
                }
                else
                {
                    PlayerPrefs.SetInt("HIGHEST_LEVEL", PlayerPrefs.GetInt("HIGHEST_LEVEL", 1) + 1);
                }
                for (int i = 0; i < audioClips.Length; i++)
                {
                    audioSource.clip = audioClips[0];
                    audioSource.Play();
                }
                CurrencyManager._instance.AddCoins(1000);
            }
        }  
    }

    /// <summary>
    /// Checking if the target is completed or not
    /// </summary>
    bool IsTargetCompleted()
    {
        if (level.gameType == GameType.CollectTarget)
        {
            for (int i = 0; i < level.targetCount; i++)
            {
                if (!targetUIs[i].IsCompleted())
                {
                    return false;
                }
            }
            return true;
        }

        if (level.gameType == GameType.Score)
        {
            if (level.scoreToReach <= currentScore)
                return true;
        }

        return false;
    }

     bool IsEscapeTargetCompleted()
    {
        if (level.gameType == GameType.Escape)
        {
            for (int i = 0; i < level.targetCount; i++)
            {
                if (!targetUIs[i].IsCompleted())
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    public void DecreaseTargetCollection(int id) {
        if (level.gameType != GameType.CollectTarget && level.gameType != GameType.Escape) return;

        for (int i = 0; i < level.targetCount; i++) {
            if (i == id)
                targetUIs[i].DecreaseItemNum();
        }
    }

    public void IncreaseScore() {
        if (level.gameType != GameType.Score) return;

        currentScore += 10;
    }

    /// <summary>
    /// Fill animation for the fillBar
    /// </summary>
    IEnumerator FillUp(int prevProgression) {
        float t = 0;
        while (t < 1) {
            t += Time.deltaTime * 1.5f;
            fillImage.fillAmount = Mathf.Lerp(prevProgression, currentScore, t) / level.scoreToReach;
            percentText.text = (int)(fillImage.fillAmount * 100) + "%";
            
            CurrentScoreText.text = (int)(fillImage.fillAmount*currentScore) + "";
            yield return null;
        }

        fillImage.fillAmount = currentScore / (float)level.scoreToReach;
        percentText.text = (int)(fillImage.fillAmount * 100) + "%";
        Debug.Log("Current Score is=" + currentScore);
       
        
    }

    public void DoFillUp() {
        if (level.gameType == GameType.Score) {
            
            StartCoroutine(FillUp(currentScore));
           
        }
    }

    public GameType GetGameType()
    {
        return level.gameType;
    }
    public void LevelButtons(int value)
    {
        PlayerPrefs.SetInt("WhichLevelSelected", value);
    }
}
