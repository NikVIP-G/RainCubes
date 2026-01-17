using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    public virtual void Spawn(T @object)
    {
        @object.transform.position = transform.position;
    }
}


