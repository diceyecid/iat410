using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			return _instance;
		}
	}

	public int currentLevel;
	public int kumoHealth;
	public int oniHealth;



/********** life cycle hooks **********/ 



	// Awake is called when the script instance is being loaded
	private void Awake()
	{
		// prevent more than one game manager initiates
		if( _instance == null )
			_instance = this;
		else if( _instance != this )
			Destroy( gameObject );

		// make this game manager stay consistent across scene loads
		DontDestroyOnLoad( gameObject );
	}
	
    // Start is called before the first frame update
    private void Start()
    {
       currentLevel = 0;
	   kumoHealth = 5;
	   oniHealth = 5;
    }

    // Update is called once per frame
    private void Update()
    {
        GameObject kumo = GameObject.Find("Kumo");
        PlayerHealth kumoHealth = kumo.GetComponent<PlayerHealth>();

        GameObject oni = GameObject.Find("Oni (bigger scale reference)");
        PlayerHealth oniHealth = oni.GetComponent<PlayerHealth>();

        if(oniHealth.health <= 0 && kumoHealth.health <= 0)
        {
            print("Gameover");
            GameOver();
        }
    }



/********** public methods **********/



	// initialize game from level 1
	public void Init()
	{
		SceneLoader.LoadLevel1();
		currentLevel = 1;
	}

	// players died, game over
	public void GameOver()
	{
		SceneLoader.LoadGameOver();
	}

	// finishes level
	public void FinishLevel1()
	{
		// save health stats 
		kumoHealth = GameObject.FindWithTag( "Kumo" ).GetComponent<PlayerHealth>().health;
		oniHealth = GameObject.FindWithTag( "Oni" ).GetComponent<PlayerHealth>().health;
		
		SceneLoader.LoadLevel2();
		currentLevel = 2;
	}
}
