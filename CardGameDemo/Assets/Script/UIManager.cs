using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text enemyHealth;

    private int enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackCardGo()
    {
        enemyHP--;
        enemyHealth.text = enemyHP.ToString();
    }
}
