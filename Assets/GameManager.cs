using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform cards;
    public GameObject card;

    public Card firstCard;
    public Card secondCard;

    public int CardCount = 0;


    public GameObject GameOverText;


    public Text TimeText;
    public float TimeTest;

    public void isMatched()
    {
     
        if (firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            CardCount -= 2;

            if (CardCount == 0)
            {
                GameOverText.SetActive(true);
                Time.timeScale = 0;
            }

        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;

    }



    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();
        CardCount = arr.Length;

        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

    }

    private void Update()
    {
        TimeTest += Time.deltaTime;
        TimeText.text = "Time :" + TimeTest.ToString("F1");
    }


}
