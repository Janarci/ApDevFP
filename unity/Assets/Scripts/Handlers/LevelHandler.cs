using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler _LevelHandler = null;
    [SerializeField] private bool ezDone = true;
    [SerializeField] private bool midDone = true;
    public int level = 1;
    public bool levelWin = false;
    public bool isCheating = false;

    private void Awake()
    {
        if (_LevelHandler == null)
        {
            _LevelHandler = this;
        }
        else if (_LevelHandler != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    public void checkLevels()
    {
        ezClear();
        midClear();
    }

    private void ezClear()
    {
        if(level == 1)
            ezDone = true;
    }

    private void midClear()
    {
        if (level == 2)
            midDone = true;
    }
    public bool EzDone()
    {
        return ezDone;
    }

    public bool MidDone()
    {
        return midDone;

    }
}
