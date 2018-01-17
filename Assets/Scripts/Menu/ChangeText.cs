using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeText : MonoBehaviour {

	public void changeTo(string text)
    {
		GameObject gO = gameObject.transform.Find("Text").gameObject;
        TextMesh tM = gO.GetComponent(typeof(TextMesh)) as TextMesh;
        tM.text = text;
    }
    
}