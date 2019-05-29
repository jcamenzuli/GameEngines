using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPlatform : MonoBehaviour
{
    public PlayerControls[] players;
    
    Dictionary<PlayerControls, bool> playerOnPlatform;

    public string nextScene;
    
    public void Start()
    {
        playerOnPlatform = new Dictionary<PlayerControls, bool>();
        for (int i = 0; i < players.Length; i++) playerOnPlatform.Add(players[i], false);
    }

    public void TriggerPlayer(PlayerControls controls, bool trigger)
    {
        playerOnPlatform[controls] = trigger;
        foreach (KeyValuePair<PlayerControls, bool> kvp in playerOnPlatform)
        {
            if (!kvp.Value) return;
        }

        // change scene
        SceneManager.LoadScene(nextScene);
        
    }
}
