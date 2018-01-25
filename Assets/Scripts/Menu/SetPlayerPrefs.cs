using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPlayerPrefs : MonoBehaviour {

	public void SetPrefs(int controllerMode) {
        // 0 = steady walk;
        // 1 = teleport;
        // 2 = tunneling
        PlayerPrefs.SetInt("controllerMode", controllerMode);
    }
    
}