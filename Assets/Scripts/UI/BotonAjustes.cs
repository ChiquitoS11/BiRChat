using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonAjustes : MonoBehaviour
{
    public void Ajustes()
    {
        Debug.Log("Ajustes");
        SceneManager.LoadScene("Ajustes");
    }
}
