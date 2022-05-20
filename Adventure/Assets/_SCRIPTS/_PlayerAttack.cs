using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerAttack : MonoBehaviour
{
    Animator animator;
    private bool isAttacking = false;
    [SerializeField] GameObject AttackHitBox;
    private int playerDamage = 10;

    public int PlayerDamage
    {
        get { return this.playerDamage; }
        set { this.playerDamage = value; }
    }
    void Start()
    {
        AttackHitBox.SetActive(false);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && isAttacking == false)
        {
            Debug.Log("Player attacked ");
            isAttacking = true;
            animator.Play("AttackAnimation");
            StartCoroutine(DoAttack());
        }
        //if (isAttacking == true)
        //{

        //}
    }
    IEnumerator DoAttack()
    {
        AttackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        AttackHitBox.SetActive(false);

        isAttacking = false;
    }
}
