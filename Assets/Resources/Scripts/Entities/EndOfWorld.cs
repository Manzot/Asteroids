using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfWorld : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            EnemyManager.Instance.DestroyEnemy(collision.gameObject);
    }
}
