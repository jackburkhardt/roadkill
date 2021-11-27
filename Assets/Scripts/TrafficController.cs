using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class TrafficController : MonoBehaviour
{
    public bool gameActive;
    public Transform spawnHolder;
    public Transform carHolder;
    private Object[] vehiclePrefabs;
    public UIManager UIManager;
    public AudioHandler AudioHandler;

    private int ducksFound = 0;
    private int totalDucks = 10;
    
    // Start is called before the first frame update

    private void Awake()
    {

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Start()
    {
        gameActive = true;
        vehiclePrefabs = Resources.LoadAll("Prefabs/Vehicles");
        float lastSpeed = 1f;
        foreach (Transform child in spawnHolder)
        {
            lastSpeed += 0.1f;
            StartCoroutine(VehicleSpawner(child, lastSpeed));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator VehicleSpawner(Transform spawnpoint, float speed)
    {
        while (gameActive)
        {
            var car = (GameObject)Instantiate(vehiclePrefabs[Random.Range(0, 10)], spawnpoint.position, spawnpoint.rotation, carHolder);
            car.GetComponent<Vehicle>().speed = speed;
            //car.GetComponent<Rigidbody>().AddForce(transform.forward * (speed * 3));
            yield return new WaitForSeconds(5 / (speed));
        }
    }

    public void GameOver()
    {
        AudioHandler.Play("crash");
        Time.timeScale = 0;
        Cursor.visible = true;
        UIManager.EnableCanvas(true, false);
    }

    public void DuckFound()
    {
        ducksFound++;
        if (ducksFound >= totalDucks)
        {
            Win();
        }
    }

    private void Win()
    {
        AudioHandler.Play("win");
        Time.timeScale = 0;
        Cursor.visible = true;
        UIManager.EnableCanvas(true, true);
    }
}
