using UnityEngine;


public interface ICollectible
{
    public bool Ready { get; }
    public GameObject Collect();
}