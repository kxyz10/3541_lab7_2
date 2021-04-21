using System.Collections;
using UnityEngine;


public class RaycastShoot : MonoBehaviour
{
    //where the lasers will shoot from
    public Transform shipNose;
    private Camera camera;                                           
    //how long a shot lasts
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    //how to draw the laser
    private LineRenderer lineReader;
    //keep track of how long until I can fire again
    private float fireTime;
    //how often I can fire
    public float fireRate = 0.10f;
    //how far the laser shoots
    public float weaponRange = 1000f;
    //object to hold the statTracker
    public GameObject statTrackerObject;
    //statTracker script
    public StatTracker statTracker;


    void Start()
    {
        lineReader = GetComponent<LineRenderer>();
        camera = Camera.main;
        statTracker = statTrackerObject.GetComponent<StatTracker>();
        DontDestroyOnLoad(statTrackerObject);
    }


    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(0)) && Time.time > fireTime)
        {
            //add to how much time you have until you can shoot again
            fireTime = Time.time + fireRate;
            //need to start coroutine so I can shoot laser while game is still running
            StartCoroutine(ShotEffect());
            //shoot ray from camera center
            Vector3 shotOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            //draw laser
            lineReader.SetPosition(0, shipNose.position);
            lineReader.SetPosition(1, shotOrigin + (camera.transform.forward * weaponRange));
            //shoot ray
            RaycastHit hit;
            if(Physics.Raycast(shotOrigin, shipNose.transform.forward, out hit, weaponRange))
            {
                Destroy(hit.transform.gameObject);
                IncreaseScore();
            }
        }
    }

    void IncreaseScore()
    {
        Debug.Log("Object Hit, Increasing Score");
        statTracker.addScore();
        return;
    }
    private IEnumerator ShotEffect()
    {
        //show laser
        lineReader.enabled = true;
        yield return shotDuration;
        lineReader.enabled = false;
    }
}
