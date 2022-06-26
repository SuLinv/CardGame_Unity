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
        cardList.Add(new Card(0,"对敌人造成一点伤害"));
        cardList.Add(new Card(1,"对敌人造成两点伤害"));
        rd = new Random();
        CardPrefabIns();
    }

    public static void CardPrefabIns()
    {
        for (int i = 0; i < cdInstance.startCardNum; i++)
        {
            GameObject temp = cdInstance.cardPrefab;
            Card c = cdInstance.cardList[cdInstance.rd.Next(0,cdInstance.cardList.Count)];
            temp.transform.GetComponentInChildren<Text>().text = c.cardStr;
            temp.transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().cID = c.cardID;
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
}
