using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _lifespan = 3;

    private void OnEnable()
    {
        StartCoroutine(Die(_lifespan));
    }

    private IEnumerator Die(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }

}
