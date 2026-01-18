using UnityEngine;

[RequireComponent(typeof(PoolCube))]

public class SpawnerCubeInDefineZone : Spawner<SpawnedCube>
{
    [SerializeField] private Transform _platform;

    public override void Spawn(SpawnedCube @object)
    {
        int valueDivision = 2;
        float offsetFromBorder = 2.0f;
        float halfWidthPlatform = _platform.transform.localScale.x / valueDivision;
        float halfHeigthPlatform = _platform.transform.localScale.z / valueDivision;

        float leftBorderPlatform = -halfWidthPlatform + offsetFromBorder + transform.position.x;
        float rightBorderPlatform = halfWidthPlatform - offsetFromBorder + transform.position.x;

        float forwardBorderPlatform = -halfHeigthPlatform + offsetFromBorder + transform.position.z;
        float backBorderPlatform = halfHeigthPlatform - offsetFromBorder + transform.position.z;

        float randomX = Random.Range(leftBorderPlatform, rightBorderPlatform);
        float randomZ = Random.Range(forwardBorderPlatform, backBorderPlatform);
        
        @object.transform.position = new Vector3(randomX, transform.position.y, randomZ);
    }
}
