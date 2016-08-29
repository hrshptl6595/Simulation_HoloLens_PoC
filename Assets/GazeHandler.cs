using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class GazeHandler : Singleton<GazeHandler>
{
    private Color startColor;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGazeEnter()
    {
        var com = gameObject.GetComponent<Renderer>();
        startColor = com.material.color;
        com.material.color = Color.cyan;
        Debug.Log("In the OnGazeEnter function");
    }

    void OnGazeLeave()
    {
        var com = gameObject.GetComponent<Renderer>();
        com.material.color = Color.red;

    }
	
}
