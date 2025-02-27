using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kumo")
        {
            door.SetBool("isOpening", true);
            Destroy(this.gameObject);
        }
		
		if( gameObject.CompareTag( "heartOfEarth" ) )
		{
			GameManager.Instance.gotHeartOfEarth = true;
		}
		else if( gameObject.CompareTag( "eyeOfSky" ) )
		{
			GameManager.Instance.gotEyeOfSky = true;
		}
    }
}
