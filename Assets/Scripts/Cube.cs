using UnityEngine;
using VolumeBox.Toolbox;

public class Cube: MonoCached, IPooled
{
    private MoveInfo info;
    private float currentDistance;
    
    public void OnSpawn(object data)
    {
        info = (MoveInfo) data;
        currentDistance = 0;
    }

    public override void Tick()
    {
        Vector3 moveDelta = transform.forward * info.speed * delta;
        transform.position += moveDelta;
        currentDistance += moveDelta.magnitude;
        
        if (currentDistance >= info.distance)
        {
            Pooler.Instance.Despawn(gameObject);
        }
    }
}