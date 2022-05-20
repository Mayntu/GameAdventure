using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _EnemyKill : MonoBehaviour
{
    public bool isDamaging = false;
    [SerializeField] private float timeBetweenAttack;
    private float attackCounter;
    private void Update()
    {
        attackCounter -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (attackCounter <= 0)
            {
                isDamaging = true;
                attackCounter = timeBetweenAttack;
            }
            else
            {
                isDamaging = false;
            }
            collision.gameObject.GetComponent<_HeartSystem>().SetEnemy(gameObject);
        }
    }
    public void Deactive()
    {
        this.isDamaging = false;
    }
}