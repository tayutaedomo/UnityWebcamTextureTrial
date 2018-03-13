using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebcamController : MonoBehaviour {

	WebCamTexture _webCam;
	Material _material;

	// Use this for initialization
	IEnumerator Start () {
		_material = GetComponent<MeshRenderer> ().material;

		yield return Application.RequestUserAuthorization (UserAuthorization.WebCam);
		if (Application.HasUserAuthorization (UserAuthorization.WebCam) == false) {
			yield break;
		}

		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices == null || devices.Length == 0) {
			yield break;
		}

		_webCam = new WebCamTexture (devices [0].name, Screen.width, Screen.height, 12);
		_webCam.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_webCam != null) {
			Texture texture = _webCam as Texture;
			_material.mainTexture = texture;
		}
	}
}
