using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    public GameObject tube;
    public float lastTubePosition;
    private GameObject tubeInstance;

    private int minOffeset;
    private int maxOffest;

    private int minHight;
    private int maxHight;

    private int minSeparation;
    private int maxSeparation;
    private void Awake()
    {
        EventManager.NewGame += ResetTubePosition;
        EventManager.ChangeDifficulty += SetOffsetAndHight;
    }
    void Start()
    {
        lastTubePosition = 0;
    }

    private void OnDestroy()
    {
        EventManager.NewGame -= ResetTubePosition;
        EventManager.ChangeDifficulty -= SetOffsetAndHight;
    }

    void Update()
    {
    //    if(lastTubePosition+ DifficultyManager.instance.RandomInt(RandomCase.TUBE_OFFSET)<= transform.position.x)
    //    {
    //        SpawnTube();
    //    }

        if (lastTubePosition + Random.Range(minOffeset,maxOffest) <= transform.position.x)
        {
            SpawnTube();
        }
    }

    private void SpawnTube()
    {
        //Vector3 spawnPosition= transform.position+new Vector3(0, DifficultyManager.instance.RandomInt(RandomCase.TUBE_HIGHT),0);
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(minHight,maxHight), 0);
        tubeInstance =Instantiate(tube, spawnPosition, Quaternion.identity);
        tubeInstance.GetComponentInChildren<TubeSeparate>().Separation(minSeparation, maxSeparation);
        lastTubePosition=tubeInstance.transform.position.x;
    }

    private void ResetTubePosition()
    {
        lastTubePosition = 0;
    }

    private void SetOffsetAndHight(DifficultyData difficulty)
    {
        minOffeset = difficulty.tubeOffestMin;
        maxOffest = difficulty.tubeOffestMax;

        minHight = difficulty.tubeHeightMin;
        maxHight = difficulty.tubeHeightMax;

        minSeparation = difficulty.tubeSeparationMin;
        maxSeparation = difficulty.tubeSeparationMax;
    }
}
