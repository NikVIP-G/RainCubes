using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class SpawnedCube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _minDelay = 2f;
    [SerializeField] private float _maxDelay = 5f;

    private bool _collided= false;
    private Coroutine _coroutine;
    private Color _defautColor = Color.white;

    public event Action<SpawnedCube> OnCollision;
    public event Action<SpawnedCube> OnReleased;

    public Material Material => _renderer.material;
    public Rigidbody Rigidbody => _rigidbody;

    public void Reset()
    {
        _collided = false;
        Material.color = _defautColor;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_collided)
            return;

       if (collision.gameObject.TryGetComponent<Platform>(out Platform _))
        {
            _collided = true;

            if (_collided == false)
                _collided = true;

            OnCollision?.Invoke(this);

            _coroutine = StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        float delay = UnityEngine.Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);
        OnReleased?.Invoke(this);
    }
}
