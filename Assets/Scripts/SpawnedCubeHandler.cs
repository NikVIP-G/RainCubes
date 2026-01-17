using UnityEngine;

[RequireComponent(typeof(ColorChanger))]

public class SpawnedCubeHandler : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Spawner<SpawnedCube> _spawner;
    [SerializeField] private PoolCube _pool;
    [SerializeField] private float _forceMultiplier = 50;
    [SerializeField] private float _delay = 0.2f;

    private float _timer = 0.0f;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _delay)
        {
            SpawnedCube cube = _pool.Get();
            _timer = 0.0f;

            cube.OnCollision += OnCubeCollision;
            cube.OnReleased += OnCubeRelease;
            _spawner.Spawn(cube);
        }
    }

    private void OnCubeCollision(SpawnedCube cube)
    {
        cube.OnCollision -= OnCubeCollision;

        _colorChanger.ChangeColor(cube.Material);
        cube.Rigidbody.AddForce(Vector3.up * _forceMultiplier, ForceMode.Impulse);
    }

    private void OnCubeRelease(SpawnedCube cube)
    {
        cube.OnReleased -= OnCubeRelease;

        cube.Reset();
        _pool.Release(cube);
    }
}