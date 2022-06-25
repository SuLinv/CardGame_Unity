using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public Text enemyHealth;
    private int enemyHP;

    // public Card buttonCard;
    public int cID;
    
    // Start is called before the first frame update

    void Awake()
    {

    }

    void Start()
    {
        enemyHealth = GameObject.FindWithTag("EnemyHP").GetComponent<Text>();
        // enemyHP = int.Parse(enemyHealth.text);
        // GetComponent<Button>().onClick.AddListener(ButtonGo);
    }

    // Update is called once per frame
    void Update()
    {
        enemyHP = int.Parse(enemyHealth.text);
    }

    public void ButtonGo()
    {
        if (cID == 0)
        {
            enemyHP = enemyHP - 1;
            enemyHealth.text = enemyHP.ToString();
        }else if (cID == 1)
        {
            enemyHP = enemyHP - 2;
            enemyHealth.text = enemyHP.ToString();
        }
        Destroy(transform.parent.gameObject);
    }
}
