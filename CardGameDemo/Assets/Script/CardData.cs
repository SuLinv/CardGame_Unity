using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();
    public Text eHP;
    public GameObject cardPrefab;
    Card c;
    private GameObject bt;
    // Start is called before the first frame update
    void Awake()
    {
        cardList.Add(new Card(0,"对敌人造成一点伤害"));
        cardList.Add(new Card(1,"对敌人造成两点伤害"));
    }
    
    void Start()
    {
        // cardPrefab.transform.GetComponentInChildren<Button>().GetComponent<CardButton>().buttonCard;
        // bt = cardPrefab.transform.GetComponentInChildren<Button>().gameObject;
        // c = bt.GetComponent<CardButton>().buttonCard;
        c = cardList[1];
        eHP = GameObject.FindWithTag("EnemyHP").GetComponent<Text>();
        cardPrefab.transform.GetComponentInChildren<Text>().text = c.cardStr;
        cardPrefab.transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().buttonCard = c;
        cardPrefab.transform.GetComponentInChildren<Button>().gameObject.GetComponent<CardButton>().enemyHealth =
            eHP;
        CardDisplay(cardPrefab);
    }

    void CardDisplay(GameObject gObj)
    {
        Instantiate(gObj,transform);
        // newCard.transform.parent = transform;
    }
}
