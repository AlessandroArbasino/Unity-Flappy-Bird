using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem explosion;
    private void Awake()
    {
        EventManager.Death += Dead;
        EventManager.NewGame += StopCoru;
    }
    private void OnDestroy()
    {
        EventManager.Death -= Dead;
        EventManager.NewGame -= StopCoru;
    }

    private void Dead()
    {
        Instantiate<ParticleSystem>(explosion, transform);

        StartCoroutine(VanishCouroutine());
    }

    private IEnumerator VanishCouroutine()
    {
        yield return new WaitForSecondsRealtime(explosion.main.duration);
        gameObject.SetActive(false);
    }

    private void StopCoru()
    {
        StopAllCoroutines();
    }
}
