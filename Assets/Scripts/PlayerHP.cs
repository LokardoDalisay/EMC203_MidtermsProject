using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public float hp;
    public float maxhp;
    public Image HpBar;
    private bool isDead;
    public Manager Manager;
    
    private void Start()
    {
        maxhp = hp;
    }

    void Update()
    {
        HpBar.fillAmount = Mathf.Clamp(hp / maxhp, 0, 1);

        if (hp <= 0 && !isDead)
        {
            isDead = true;
            Manager.Restart();
            Debug.Log("Im dead");
            Time.timeScale = 0f;
        }
    }
}
