using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class API : MonoBehaviour
{
    private string URL = "https://api.thecatapi.com/v1/images/search";

    public Text nombre;
    public Text contrasenia;
    public Text correo;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PostData());
    }

    private IEnumerator PostData()
    {
        using (UnityWebRequest request = UnityWebRequest.Post(URL))
        {
            yield return request.SendWebRequest();
        }
            
    }
}
