using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : SingletonMono<LevelController>
{
    public event System.Action OnStart;
    public event System.Action OnEnd;

    public void StartLevel()
    {
        OnStart?.Invoke();
    }

    public void EndLevel()
    {
        OnEnd?.Invoke();
    }
}
