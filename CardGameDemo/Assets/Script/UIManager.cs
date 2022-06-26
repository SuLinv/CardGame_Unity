using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager uimInstance;

    public Button turnEndBtn;
    // Start is called before the first frame update
    void Awake()
    {
        if (uimInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        uimInstance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnEnd()
    {
        GameObject[] playerCards;
        playerCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        for (int i = 0; i < playerCards.Length; i++)
        {
            Destroy(playerCards[i]);
        }
        turnEndBtn.gameObject.SetActive(false);
    }
    
}
