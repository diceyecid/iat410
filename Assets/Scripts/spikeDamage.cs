using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().sprite != null && this.GetComponent<SpriteRenderer>().sprite.name == "shadow_spikes_idle_1")
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Oni (bigger scale reference)")
        {
            GameObject.Find("Oni (bigger scale reference)").GetComponent<PlayerHealth>().TakeDamage(damage);
            /*  StatsManager oniStats = GameObject.FindWithTag("oniStats").GetComponent<StatsManager>();
              oniStats.LosePoint();
  */
        }
        else if (collision.gameObject.name == "Kumo")
        {
            GameObject.Find("Kumo").GetComponent<PlayerHealth>().TakeDamage(damage);
            /*     StatsManager kumoStats = GameObject.FindWithTag("kumoStats").GetComponent<StatsManager>();
                 kumoStats.LosePoint();*/
        }
    }
}
