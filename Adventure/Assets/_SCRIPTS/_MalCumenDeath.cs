using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MalCumenDeath : MonoBehaviour
{
    Animator animator;
    [SerializeField] private int hp;
    private bool isDead = false;
    _PlayerAttack damage = new _PlayerAttack();
    private Vector3 off1;
    private Vector3 off2;
    private Vector3 off3;
    //[SerializeField] private GameObject[] objects;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Awake()
    {
        off1 = new Vector3(Random.Range(-3, 3), 1);
        off2 = new Vector3(Random.Range(-3, 3), 1);
        off3 = new Vector3(Random.Range(-3, 3), 1);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AttackHitBox")
        {
            SetEnemy(gameObject);
            //animator.Play("SlizenDamaged");
            Debug.Log(damage.PlayerDamage);
            hp -= damage.PlayerDamage;

        }
    }
    void FixedUpdate()
    {
        DeathCheck();
    }
    [SerializeField] private GameObject Enemy;
    void DeathCheck()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
        if (isDead == true)
        {
            StartCoroutine(DoDeath());
        }
    }
    IEnumerator DoDeath()
    {
        _PatrolingEnemy script3 = Enemy.GetComponent<_PatrolingEnemy>();
        script3.enabled = false;
        animator.Play("MalCumenDeathAnimation");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        script3.enabled = true;
        DropGoldCoin();
        DropSilverCoin();
    }
    public void SetEnemy(GameObject enemy)
    {
        Enemy = enemy;
    }
    [SerializeField] private GameObject GoldCoin;
    [SerializeField] private Transform transform1;
    [SerializeField] private GameObject SilverCoin;
    [SerializeField] private Transform transform2;
    [SerializeField] private int minGold, maxGold, minSilver, maxSilver;
    void DropGoldCoin()
    {
        if (isDead == true)
        {
            int countOfCoin = Random.Range(minGold, maxGold);
            for (int i = 0; i < countOfCoin; i++)
            {
                Vector3 position = transform.position;
                GameObject coin = Instantiate(GoldCoin, position + off1 + new Vector3(i, 0, 0), Quaternion.identity);
                coin.SetActive(true);
            }
        }
    }
    void DropSilverCoin()
    {
        if (isDead == true)
        {
            int countOfCoin = Random.Range(minSilver, maxSilver);
            for (int i = 0; i < countOfCoin; i++)
            {
                Vector3 position = transform.position;
                GameObject coin = Instantiate(SilverCoin, position + off2 + new Vector3(i, 0, 0), Quaternion.identity);
                coin.SetActive(true);
            }
        }
    }
    //void IsDead()
    //{

    //    if(isDead == true)
    //    {
    //        Instantiate(objects[1], objects[1].transform.position, Quaternion.identity);
    //    }
    //}
}