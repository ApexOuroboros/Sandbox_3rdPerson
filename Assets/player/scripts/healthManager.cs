using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{

    [SerializeField]
    float hitPoints = 100f;

    void Hit(float rawDamage)
    {

        hitPoints -= rawDamage;

        Debug.Log("ouch: " + hitPoints.ToString());

        if(hitPoints <= 0)
        {
            Debug.Log("todo: game over!");
        }

    }

}
