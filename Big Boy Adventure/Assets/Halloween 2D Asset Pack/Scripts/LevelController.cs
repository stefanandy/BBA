using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour {

	public void LoadScene (string sceneN) {
		SceneManager.LoadScene (sceneN);
	}
}