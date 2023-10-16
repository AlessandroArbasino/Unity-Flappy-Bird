using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParallaxEffect : MonoBehaviour
{
	[SerializeField] private Vector2 parallaxEffectMultiplier;
	private bool cloneSpawned;


	private Transform cameraTransform;
	private Vector3 lastcameraPosition;

	private Tilemap tilemap;
	private Vector2 tilemapPixelDimension;

	[SerializeField] GameObject grid;
	void Start()
	{
		cameraTransform = Camera.main.transform;
		lastcameraPosition = cameraTransform.position;


		tilemap = GetComponent<Tilemap>();
		tilemap.CompressBounds();
		Vector3Int tilemapSize = tilemap.size;
		Vector3 cellDimension = tilemap.cellSize;
		tilemapPixelDimension = new Vector2 (tilemapSize.x * cellDimension.x, tilemapSize.y * cellDimension.y);
	
		cloneSpawned= false;
	}

	//private void LateUpdate()
	//{
	//	//infinite backgorund tiled spride 3 screen big
	//	Vector3 deltaMovement = cameraTransform.position - lastcameraPosition;
	//	transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, transform.position.z);
	//	lastcameraPosition = cameraTransform.position;

	//	if (!cloneSpawned)
	//		if (cameraTransform.position.x - transform.position.x <= tilemapPixelDimension.x/2 && transform.position.x - tilemapPixelDimension.x<cameraTransform.position.x)
	//		{
	//			float offsetPositionX = tilemapPixelDimension.x+1;

	//			Instantiate<GameObject>(gameObject, new Vector3(offsetPositionX + transform.position.x,transform.position.y, transform.position.z), Quaternion.identity, grid.transform);
 //               cloneSpawned = true;
	//		}
	//	if (transform.position.x + tilemapPixelDimension.x / 2 <= cameraTransform.position.x - Camera.main.orthographicSize && !gameObject.GetComponent<TilemapRenderer>().isVisible)
	//		Destroy(gameObject);
	//}

    private void OnBecameVisible()
    {
        if(Camera.current==Camera.main) 
		{
            float offsetPositionX = tilemapPixelDimension.x + 1;
            Instantiate<GameObject>(gameObject, new Vector3(offsetPositionX + transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, grid.transform);
        }
    }

    private void OnBecameInvisible()
    {
        if (Camera.current == Camera.main)
		{
            Destroy(gameObject);
        }
    }


}
