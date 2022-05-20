using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _EnemyKill : MonoBehaviour
{
    Animator animator;
    public bool isDamaging = false;
    [SerializeField] private float timeBetweenAttack;
    private float attackCounter;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
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
                animator.SetBool("isDamaging", true);
                isDamaging = true;
                attackCounter = timeBetweenAttack;
            }
            else
            {
                animator.SetBool("isDamaging", false);
                isDamaging = false;
            }
            collision.gameObject.GetComponent<_HeartSystem>().SetEnemy(gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isDamaging", false);
        }
    }
    public void Deactive()
    {
        this.isDamaging = false;
    }
}