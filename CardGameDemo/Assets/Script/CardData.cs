using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CardData : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();
    public GameObject cardPrefab;
    Card c;

    private Random rd;
    // Start is called before the first frame update
    void Awake()
    {
        cardList.Add(new Card(0,"对敌人造成一点伤害"));
        cardList.Add(new Card(1,"对敌人造成两点伤害"));
        rd = new Random();
    }
    
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject temp = cardPrefab;
            c = cardList[rd.Next(0,cardList.Count)];
            temp.transform.GetComponentInChildren<Text>().text = c.cardStr;
            temp.transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().cID = c.cardID;
            CardDisplay(temp,i);
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
