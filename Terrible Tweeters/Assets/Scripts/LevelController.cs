using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName = "outro level";


    Monster[] _monsters;
    //GameObject[] _monsters;
    //GameObject _monsters;

    void onEnable()
    {
    	_monsters = FindObjectsOfType<Monster>();
    	//_monsters = GameObject.FindGameObjectsWithTag("Respawn");
    	//_monsters = GameObject.Find("Monster");
    }

    bool MonstersAreAllDead()
    {
    	foreach (var monster in _monsters)
    	{
    		if(monster.gameObject.activeSelf)
    			return false;
    	}
    	
    	return true;
    }

    void GoToNextLevel()
    {
    	Debug.Log("Go to level " + _nextLevelName);
    	SceneManager.LoadScene(_nextLevelName);
    }

    // Update is called once per frame
    void Update()
    {
    	onEnable();
        if(MonstersAreAllDead())
        	GoToNextLevel();
    }

    

}
