using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CardData : MonoBehaviour
{
    private static CardData cdInstance;
    public List<Card> cardList = new List<Card>();
    public GameObject cardPrefab;
    public int startCardNum = 5;
    public int attackNum = 0;
    public Animator eAnim;
    public Animation pAnim;

    private Random rd;
    // Start is called before the first frame update
    void Awake()
    {
        if (cdInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        cdInstance = this;
        DontDestroyOnLoad(this);
    }
    
    void Start()
    {
        cardList.Add(new Card(0,"斩钢闪：对敌人造成一点伤害（施放两次后会幻化成斩钢闪·三段）"));
        cardList.Add(new Card(1,"斩钢闪·三段:对所有敌人造成两点伤害，并击晕一回合（施放后幻化为斩钢闪）"));
        rd = new Random();
        CardPrefabIns();
    }

    public static void CardPrefabIns()
    {
        for (int i = 0; i < cdInstance.startCardNum; i++)
        {
            GameObject temp = cdInstance.cardPrefab;
            // Card c = cdInstance.cardList[cdInstance.rd.Next(0,cdInstance.cardList.Count)];
            Card c = cdInstance.cardList[0];
            temp.transform.GetComponentInChildren<Text>().text = c.cardStr;
            temp.transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().cID = c.cardID;
            temp.transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().enAnim =
                cdInstance.eAnim;
            temp.transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().pAnim =
                cdInstance.pAnim;
            temp.tag = "PlayerCard";
            cdInstance.CardDisplay(temp,i);
        }
    }

    void CardDisplay(GameObject gObj,int time)
    {
        if(time==0) Instantiate(gObj,transform);
        if (time > 0 && (time+1) % 2 == 0)
        {
            GameObject a = Instantiate(gObj,transform);
            a.transform.position = new Vector3(a.transform.position .x + 120*(time/2+1), a.transform.position .y,
                a.transform.position .z);
        }else if (time > 0 && time % 2 == 0)
        {
            GameObject a = Instantiate(gObj,transform);
            a.transform.position = new Vector3(a.transform.position .x - 120*time/2, a.transform.position .y,
                a.transform.position .z);
        }

    }

    public static void AttackCardChange(int cardID)
    {
        if (cardID == 0)
        {
            cdInstance.attackNum++;
            if (cdInstance.attackNum == 2)
            {
                cdInstance.cardList[0] = cdInstance.cardList[1];
                GameObject[] playerCards = GameObject.FindGameObjectsWithTag("PlayerCard");
                for (int i = 0; i < playerCards.Length; i++)
                {
                    Card c = cdInstance.cardList[0];
                    playerCards[i].transform.GetComponentInChildren<Text>().text = c.cardStr;
                    playerCards[i].transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().cID = c.cardID;
                }
                cdInstance.attackNum = 0;
            }
        }else if (cardID == 1)
        {
            cdInstance.cardList[0] = new Card(0, "斩钢闪：对敌人造成一点伤害（施放两次后会幻化成斩钢闪·三段）");
            GameObject[] playerCards = GameObject.FindGameObjectsWithTag("PlayerCard");
            for (int i = 0; i < playerCards.Length; i++)
            {
                Card c = cdInstance.cardList[0];
                playerCards[i].transform.GetComponentInChildren<Text>().text = c.cardStr;
                playerCards[i].transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().cID = c.cardID;
            }
        }

    }
}
