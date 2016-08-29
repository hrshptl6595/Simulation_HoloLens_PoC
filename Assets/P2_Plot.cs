using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class P2_Plot : MonoBehaviour 
{
	private WWW get;
	public static string getreq;
	public int resolution = 10;
	private int currentResolution;
	private ParticleSystem.Particle[] points;
	List<ParticleSystem.Particle> pt = new List<ParticleSystem.Particle>();

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		WFR2();
		StartCoroutine(Waiting());
		Debug.Log("pt.ToArray(): "+pt.ToArray()[pt.Count-1].position);
		GetComponent<ParticleSystem>().SetParticles(pt.ToArray(), pt.Count);
	
	}
	private IEnumerator Waiting()
	{
		yield return new WaitForSeconds(1);
	}
	private void WFR2()
	{
		float num = UnityEngine.Random.Range(-10.0f, 10.0f);
		string url = "http://10.42.0.1:9000/api/comments?t=" + num.ToString();
		WWW get = new WWW(url);
		while(!get.isDone)
		{
			Debug.Log("Waiting...");
		}
		getreq = get.text;
		if (get.error == null)
		{
			string json = @getreq;
			List<P2_Plot_JS> data = JsonConvert.DeserializeObject<List<P2_Plot_JS>>(json);
			int l = data.Count;
			Debug.Log("Getting data: " + data[l - 1].content);
			Debug.Log("Split data: " + data[l - 1].content.Split(',')[0]);
			//Debug.Log("Value of coord: "+x1[0]+","+y1[0]+","+x2[0]+","+y2[0]);
			string[] splitData = data[l - 1].content.Split(',');
			Debug.Log("splitData: " + splitData[0] + "," + splitData[1] + "," + splitData[2] + "," + splitData[3]);
			//Debug.Log("Counter: " + counter);
			points = new ParticleSystem.Particle[1];
			points[0].position = new Vector3(0.025f*float.Parse(splitData[0]), 0.5f*float.Parse(splitData[1]), 0.0f);
			points[0].color = new Color(255, 0, 0);
			points[0].size = 0.2f;
			pt.Add(points[0]);
			Debug.Log("Going back to update function and pt: "+pt);            
		}
		else
		{
			Debug.Log("Dayumn!-> " + get.error);
		}
	}
}
public class P2_Plot_JS
{
	public string _id;
	public string author;
	public string content;
	public string _v;
	public string date;
}