using UnityEngine;
using System.Collections;

public class SpellCircle : MonoBehaviour {

	void Start () 
	{
		StartCoroutine(DeathTimer());
		transform.eulerAngles = new Vector3(transform.eulerAngles.x+90, transform.eulerAngles.y, transform.eulerAngles.z);
	}

	void Update ()
    {
        transform.Rotate(Vector3.up, 20 * Time.deltaTime);
    }

	IEnumerator DeathTimer()
	{
		Vector3 final = new Vector3(0.8f,0.8f,0.8f);
		float progress = 0;
     
	    while(progress <= 1){
			transform.localScale = Vector3.Lerp(transform.localScale, final, progress);
	        progress += Time.deltaTime;
	        yield return null;
	    }
		transform.localScale = final;
		yield return new WaitForSeconds(0.5f);
		float alpha = transform.GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1; t += Time.deltaTime)
	    {
	        Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,0,t));
	        transform.GetComponent<Renderer>().material.color = newColor;
	        yield return null;
	    }
	    Destroy(gameObject);
	}
}
