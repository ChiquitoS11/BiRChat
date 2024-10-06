using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Lobby");
    }
}
