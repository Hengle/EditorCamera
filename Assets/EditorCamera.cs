using UnityEngine;
using System.Collections;

public class EditorCamera : MonoBehaviour {
	float zoomCoefficient      = 0.05f;
	float ratateCoefficient    = 3.0f;
	float transrateCoefficient = 0.5f;
	
	void Start () {
		
	}
	
	void Update () { 
		zoom ();
		
		rotate();
		
		transrate();
	}
	
	void zoom() {
		float value = Input.mouseScrollDelta.y;
		if ( value != 0.0f ) {
			transform.position = transform.position + ( transform.forward.normalized * value * zoomCoefficient );
		}
	}
	
	void rotate() {
		bool rotating = Input.GetMouseButton (1);
		if ( rotating ) {
			float deltaX = Input.GetAxis( "Mouse X" ) * ratateCoefficient;
			float deltaY = Input.GetAxis( "Mouse Y" ) * ratateCoefficient;
			
			transform.Rotate ( Vector3.up , deltaX * 10.0f, Space.World );
			transform.Rotate ( Vector3.left , deltaY * 10.0f, Space.Self );
		}
	}
	
	void transrate() {
		bool transrating = Input.GetMouseButton (2);
		if ( transrating ) {
			transform.Translate ( Input.GetAxis( "Mouse X" ) * -transrateCoefficient,
			                     Input.GetAxis( "Mouse Y" ) * -transrateCoefficient,
			                     0.0f);
		}
	}
	
}
