using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destroyedVersion;
    bool canBeDestroyed = true;

    void TakeDamage(float damage)
    {
        if(canBeDestroyed == true)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            canBeDestroyed  = false;
        }

    }
}
