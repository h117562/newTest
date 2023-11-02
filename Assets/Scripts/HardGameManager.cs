using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HardGameManager : MonoBehaviour
{
    public static HardGameManager I;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endPanel;
    public Text timeTxt;
    public GameObject minusTxt;
    float time = 30.0f;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        //4x4 ��� ������� �� ī�� �ѹ��� ��� ��ġ
        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);


            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
            //ī�� �ѹ��� �°� �̹��� ���ҽ� ��ġ
            
        }
    }

    void Update()
    {

        //Ÿ�̸Ӱ� 0�ʵ�����
        time -= Time.deltaTime;
        if (time < 10)
        {

            timeTxt.color = Color.red;
        }
        if (time < 0)
        {
            time = 0;
            endPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        timeTxt.text = time.ToString("N2");
        //0�ʷ� �ʱ�ȭ��Ű�� �޴� Ȱ��ȭ
    }



    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<card1>().destroyCard();
            secondCard.GetComponent<card1>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endPanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.GetComponent<card1>().closeCard();
            secondCard.GetComponent<card1>().closeCard();

            //Ʋ���� ��� 1�� �����ϸ� �ؽ�Ʈ ���
            time -= 1.0f;
            Instantiate(minusTxt);

        }

        firstCard = null;
        secondCard = null;
    }

    public void checkMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<card1>().destroyCard();
            secondCard.GetComponent<card1>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
        }
        else
        {
            firstCard.GetComponent<card1>().closeCard();
            secondCard.GetComponent<card1>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
