using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CoinPickUp : MonoBehaviour
{
    public int count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<_CoinController>().AddCoin(count);
            Destroy(gameObject);
        }

    }
}
