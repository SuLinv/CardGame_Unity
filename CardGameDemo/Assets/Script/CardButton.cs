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
    public Animator enAnim;
    public Animation pAnim;
    
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
        CardData.AttackCardChange(cID);
        Invoke("SettDeathAnim",0.4f);
        transform.parent.gameObject.SetActive (false);
        pAnim.CrossFade("attack1.pie_c_11_21");
        pAnim.CrossFadeQueued("idle_01.pie_c_11_21");
    }

    void SettDeathAnim()
    {
        enAnim.SetTrigger("death");
        Destroy(transform.parent.gameObject);
    }
    
}
