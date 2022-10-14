using System.Collections;
using UnityEngine;
using VolumeBox.Toolbox;

public class CubeMover : MonoCached
{
    [SerializeField] private string cubePoolName;
    [SerializeField] private Transform spawnPoint;

    [Inject] private Pooler pool;
    [Inject] private Messager msg;

    private MoveInfo info;
    private float spawnInterval;

    public override void Rise()
    {
        msg.Subscribe(Message.SET_INTERVAL, x => SetSpawnInterval((float) x));
        msg.Subscribe(Message.SET_DISTANCE, x => SetDistance((float)x));
        msg.Subscribe(Message.SET_SPEED, x => SetSpeed((float)x));

        SpawnCube().StartManual();
    }
    
    public void SetSpawnInterval(float interval)
    {
        this.spawnInterval = interval;
    }

    public void SetDistance(float distance)
    {
        info.distance = distance;
    }

    public void SetSpeed(float speed)
    {
        info.speed = speed;
    }

    private IEnumerator SpawnCube()
    {
        while ( true)
        {
            yield return spawnInterval;

            pool.Spawn(cubePoolName, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward), null, info);
        }
    }
}

public struct MoveInfo
{
    public float distance;
    public float speed;
}
