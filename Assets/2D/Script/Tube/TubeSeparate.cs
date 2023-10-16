using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSeparate : MonoBehaviour
{
    public GameObject bottomTube;
    public GameObject topTube;

    public GameObject PointCollider;

    public void Separation(int minSeparation, int maxSeparation)
    {
        float distance = Random.Range(minSeparation, maxSeparation);
        while (Mathf.Abs(Vector3.Distance(topTube.transform.position, bottomTube.transform.position)) <=
            distance)
        {
            bottomTube.transform.Translate(0, -0.1f, 0);
        }
        PointCollider.transform.localPosition = new Vector3(PointCollider.transform.localPosition.x, (bottomTube.transform.localPosition.y + topTube.transform.localPosition.y) / 2, PointCollider.transform.localPosition.z);

        PointCollider.transform.localScale = new Vector3(PointCollider.transform.localScale.x, Mathf.Abs((bottomTube.transform.localPosition.y + bottomTube.transform.localScale.y) - (topTube.transform.localPosition.y - topTube.transform.localScale.y)), PointCollider.transform.localScale.z);
    }
}
