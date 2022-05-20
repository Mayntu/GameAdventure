using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FlyAngry : MonoBehaviour
{
    public _FlyMovement[] enemyArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (_FlyMovement enemy in enemyArray)
            {
                enemy.angry = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (_FlyMovement enemy in enemyArray)
            {
                enemy.angry = false;
            }
        }
    }
}