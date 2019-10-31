using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPositionChanger : MonoBehaviour
{
    BoxCollider2D coli;
    // Start is called before the first frame update
    void Start()
    {
        coli = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       // if (!other.gameObject.CompareTag("Laser"))
       // {
            if (other.gameObject.transform.position.y > coli.bounds.max.y)
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, coli.bounds.min.y);
            if (other.gameObject.transform.position.y < coli.bounds.min.y)
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, coli.bounds.max.y);

            if (other.gameObject.transform.position.x > coli.bounds.max.x)
                other.gameObject.transform.position = new Vector2(coli.bounds.min.x, other.gameObject.transform.position.y);
            if (other.gameObject.transform.position.x < coli.bounds.min.x)
                other.gameObject.transform.position = new Vector2(coli.bounds.max.x, other.gameObject.transform.position.y);
        //  }
    }
}
