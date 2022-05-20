using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _HeartSystem : MonoBehaviour
{
    public int health;
    public int numberOfLives;

    public Image[] lives;

    public Sprite fullLive;
    public Sprite emptyLive;
    private bool isDead = false;
    private bool godMode = false;
    
    [SerializeField] private GameObject Enemy;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    _EnemyKill dm = new _EnemyKill();
    // Update is called once per frame
    void Update()
    {
        if (health > numberOfLives)
        {
            health = numberOfLives;
        }
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }
            if (i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
            Health();
            DeathCheck();
        }
    }
    void Health()
    {
        if (Enemy != null && Enemy.gameObject.GetComponent<_EnemyKill>().isDamaging == true)
        {
            godMode = true;
            Invoke("OffGodMode",2f);
            animator.Play("PlayerGetDamageAnimation");
            Enemy.gameObject.GetComponent<_EnemyKill>().Deactive();
            health = health - 1;
        }
    }
    void OffGodMod()
    {
        godMode = false;
    }
    //public IEnumerator DoGodMod()
    //{
    //    _EnemyKill script3 = Enemy.GetComponent<_EnemyKill>();
    //    script3.enabled = false;
    //    Debug.Log("GodModOn");
    //    yield return new WaitForSeconds(10f);
    //    script3.enabled = true;
    //    Debug.Log("GodModOff");
    //}
    void DeathCheck()
    {
        if (health <= 0)
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _PlayerMovementt script1 = player.GetComponent<_PlayerMovementt>();
        script1.enabled = false;
        _PlayerAttack script2 = player.GetComponent<_PlayerAttack>();
        script2.enabled = false;
        animator.Play("PlayerDeathAnimation");
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
        script1.enabled = true;
        script2.enabled = true;

    }
    public void SetEnemy(GameObject enemy)
    {
        Enemy = enemy;
    }
}