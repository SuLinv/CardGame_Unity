using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public Text enemyHealth;
    private int enemyHP;

    public Card buttonCard;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP = int.Parse(enemyHealth.text);
        this.GetComponent<Button>().onClick.AddListener(ButtonGo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonGo()
    {
        enemyHP = enemyHP - 2;
        enemyHealth.text = enemyHP.ToString();
    }
}
