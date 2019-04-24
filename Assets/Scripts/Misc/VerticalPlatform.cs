using UnityEngine;

public class VerticalPlatform : MonoBehaviour {


    private PlatformEffector2D effector;
    public float waitTime;

	void Start () {

        effector = GetComponent<PlatformEffector2D>();
	}
	void Update () {

        if (Input.GetKey(KeyCode.S))
        {
            waitTime = 0.4f;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
       
        effector.rotationalOffset = waitTime > 0 ? 180 : 0;

    }
}
