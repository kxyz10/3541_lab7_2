using System.Collections;
using UnityEngine;


public class RaycastShoot : MonoBehaviour
{
    public Transform shipNose;
    private Camera camera;                                           
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer lineReader;                                        
    private float fireTime;
    public float fireRate = 0.10f;
    public float weaponRange = 1000f;
    public GameObject statTrackerObject;
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
            fireTime = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 shotOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            lineReader.SetPosition(0, shipNose.position);
            lineReader.SetPosition(1, shotOrigin + (camera.transform.forward * weaponRange));
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
        lineReader.enabled = true;
        yield return shotDuration;
        lineReader.enabled = false;
    }
}
