using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DreamTokenCollecting : MonoBehaviour {
	
	#region
    public Text countToken;
    private static int dreamTokenCount;
	#endregion

	void Start()
	{
		dreamTokenCount = 0;
		SetTokenText();
	}


	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dream Token"))
        {
            other.gameObject.SetActive(false);
            dreamTokenCount += 1;
            SetTokenText();
        }
	}

	void SetTokenText()
    {
        countToken.text = ": " + dreamTokenCount.ToString();
    }

	public static int returnTokenCount()
    {
        return dreamTokenCount;
    }
}
