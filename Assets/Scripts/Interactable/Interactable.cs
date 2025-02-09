using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public const float RANGE = 1.5f;
	
	public GameObject kumoInteractionUI;
	public GameObject oniInteractionUI;

	private GameObject kumo;
	private GameObject oni;

	private GameObject popup;
	private Vector3 offset;

	// optional offset
	public Vector3 customOffset;

    // Start is called before the first frame update
    void Start()
    {
		// get Kumo and Oni
		kumo = GameObject.FindGameObjectsWithTag( "Kumo" )[0];
		oni = GameObject.FindGameObjectsWithTag( "Oni" )[0];

		// set up pop up
		popup = null;

		if( customOffset != Vector3.zero )
		{
			offset = customOffset;
		}
		else
		{
			offset = new Vector3( 0, GetComponent<SpriteRenderer>().bounds.size.y * 1.5f, 0 );
		}
    }

    // Update is called once per frame
    void Update()
    {
		if( !popup )
		{
			fadeIn();
		}
		else
		{
			fadeOut();
		}
    }


	// instantiate pop up
	void fadeIn()
	{
		if( ( kumo.transform.position - transform.position ).magnitude < RANGE )
		{
			popup = Instantiate( kumoInteractionUI, transform.position + offset, Quaternion.identity, transform );
		}

		if( ( oni.transform.position - transform.position ).magnitude < RANGE )
		{
			popup = Instantiate( oniInteractionUI, transform.position + offset, Quaternion.identity, transform );
		}
	}

	// destroy pop up
	void fadeOut()
	{
		if( ( kumo.transform.position - transform.position ).magnitude > RANGE && popup.tag == "kumoInteraction" )
		{
			Destroy( popup );
		}

		if( ( oni.transform.position - transform.position ).magnitude > RANGE && popup.tag == "oniInteraction" )
		{
			Destroy( popup );
		}
	}
}
