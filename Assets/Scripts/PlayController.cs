using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayController : MonoBehaviour
{
    public void LoadLevel()
    {
        Debug.Log("hey");
        SceneManager.LoadScene(1);
    }
}
