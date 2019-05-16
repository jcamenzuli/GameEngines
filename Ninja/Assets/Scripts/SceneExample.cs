using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneExample : MonoBehaviour
{
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
