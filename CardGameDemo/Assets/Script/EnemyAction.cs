using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAction : MonoBehaviour
{
    public Text enemyHealth;
    public Text playerHealth;
    public Button turnEndBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyAttack()
    {
        int enemyHP = int.Parse(enemyHealth.text);
        int playerHP = int.Parse(playerHealth.text);
        enemyHealth.text = (enemyHP + 1).ToString();
        playerHealth.text = (playerHP - 2).ToString();
        Invoke("CardPrefabsIns",2f);
    }

    void CardPrefabsIns()
    {
        CardData.CardPrefabIns();
        turnEndBtn.gameObject.SetActive(true);
    }
}
