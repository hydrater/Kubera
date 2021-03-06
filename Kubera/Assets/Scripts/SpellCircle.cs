﻿using UnityEngine;
using System.Collections;

public class SpellCircle : MonoBehaviour {

	void Start () 
	{
		StartCoroutine(DeathTimer());
	}

	void Update ()
    {
        transform.Rotate(Vector3.up, 20 * Time.deltaTime);
    }

	IEnumerator DeathTimer()
	{
		Vector3 final = new Vector3(0.8f,0.8f,0.8f);
		float t = 0;
     
	    while(t <= 1)
	    {
			transform.localScale = Vector3.Lerp(transform.localScale, final, t);
	        t += Time.deltaTime;
	        yield return null;
	    }
		transform.localScale = final;
		yield return new WaitForSeconds(0.5f);
		for (t = 0.0f; t < 1; t += Time.deltaTime/2)
	    {
	        Color newColor = new Color(1, 1, 1, Mathf.Lerp(1,0,t));
	        transform.GetComponent<Renderer>().material.color = newColor;
			transform.GetChild(0).GetComponent<Renderer>().material.color = newColor;
	        yield return null;
	    }
	    Destroy(gameObject);
	}
}
