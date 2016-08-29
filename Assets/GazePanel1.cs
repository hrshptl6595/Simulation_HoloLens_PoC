using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class GazePanel1 : Singleton<GazePanel1> 
{
	

	// Use this for initialization
	void OnGazeEnter () 
	{
		foreach (Transform child in transform) 
		{
			child.gameObject.SetActive (true);
		}
	
	}
	
	// Update is called once per frame
	void OnGazeLeave () 
	{
		foreach (Transform child in transform) 
		{
			child.gameObject.SetActive (false);
		}
	
	}
}
