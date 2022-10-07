using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitManager : MonoBehaviour
{

    [SerializeField]
    float hitPoints = 25f;

    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        if(hitPoints <= 0)
        {
            Invoke("SelfTerminate", 0f);
        }
    }

    void SelfTerminate()
    {
        Destroy(gameObject);
    }

}
