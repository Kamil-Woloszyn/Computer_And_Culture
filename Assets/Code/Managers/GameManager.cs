using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // === UI References ===
    public Text scoreText;
    public GameObject messagePanel;
    public Text messageText;
    public InputField inputField; // Legacy UI version
    public Button submitButton;
    public GameObject levelCompletePanel;
    public Button mainMenuButton;

    // === Spawn/Slot References ===
    public RectTransform cardSpawnArea;
    public GameObject countryCardPrefab;
    public GameObject dropSlotPanel;

    // === Country Data and Logic ===
    public List<CountryData> countryList = new List<CountryData>();
    public bool randomizeCards = false;
    public int cardsPerLevel = 1;

    private int currentCardIndex = 0;
    private List<CountryData> levelCountries = new List<CountryData>();
    private GameObject currentCard;
    private SlotManager slotManager;
    private int score = 0;

    void Start()
    {
        SetupLevel();
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // 
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // 🔁 Choose which cards to use
    void SetupLevel()
    {
        levelCountries.Clear();
        if (randomizeCards)
        {
            List<CountryData> tempList = new List<CountryData>(countryList);
            for (int i = 0; i < cardsPerLevel; i++)
            {
                int index = Random.Range(0, tempList.Count);
                levelCountries.Add(tempList[index]);
                tempList.RemoveAt(index);
            }
        }
        else
        {
            // Just take first N cards if random not enabled
            for (int i = 0; i < Mathf.Min(cardsPerLevel, countryList.Count); i++)
            {
                levelCountries.Add(countryList[i]);
            }
        }

        currentCardIndex = 0;
        score = 0;
        scoreText.text = "Score: 0";

        slotManager = dropSlotPanel.GetComponent<SlotManager>();
        levelCompletePanel.SetActive(false);
        messagePanel.SetActive(false);
        inputField.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);

        SpawnNextCard();
    }

    // 🃏 Spawns the next country card into the UI
    void SpawnNextCard()
    {
        if (currentCardIndex >= levelCountries.Count)
        {
            levelCompletePanel.SetActive(true);
            return;
        }

        CountryData data = levelCountries[currentCardIndex];
        currentCard = Instantiate(countryCardPrefab, cardSpawnArea);
        currentCard.GetComponent<Image>().sprite = data.countryImage;

        // Assign country data to the card
        var dragScript = currentCard.GetComponent<DraggableCountry>();
        dragScript.data = data;
    }

    // 🟩 Called by SlotManager when card is dropped into slot
    public void ShowInputField(DraggableCountry card)
    {
        inputField.text = "";
        inputField.gameObject.SetActive(true);
        submitButton.gameObject.SetActive(true);

        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(() => CheckAnswer(card));
    }

    // ✅ Check if the player's input matches the country's name
    void CheckAnswer(DraggableCountry card)
    {
        string input = inputField.text.Trim().ToLower();
        string answer = card.data.countryName.ToLower();

        if (input == answer)
        {
            score++;
            scoreText.text = "Score: " + score;
            ShowMessage("Correct!\n\n" + card.data.funFact, true);
        }
        else
        {
            ShowMessage("Wrong answer.", false);
        }
    }

    // 💬 Display message on screen, whether correct or wrong
    void ShowMessage(string message, bool correct)
    {
        messageText.text = message;
        messagePanel.SetActive(true);

        if (correct)
        {
            submitButton.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);

            StartCoroutine(DelayedNextCard());
        }
        else
        {
            submitButton.gameObject.SetActive(true);
            inputField.gameObject.SetActive(true);

            StartCoroutine(HideMessageAfterDelay(3f));
        }
    }

    // ✅ Hide message after 3 seconds (for wrong answers)
    IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messagePanel.SetActive(false);
    }

    // ✅ Wait after correct answer, then spawn next
    IEnumerator DelayedNextCard()
    {
        yield return new WaitForSeconds(10f); // show fact for 10 seconds
        messagePanel.SetActive(false);

        Destroy(currentCard);
        slotManager.ClearSlot();

        currentCardIndex++;
        SpawnNextCard();
    }
}