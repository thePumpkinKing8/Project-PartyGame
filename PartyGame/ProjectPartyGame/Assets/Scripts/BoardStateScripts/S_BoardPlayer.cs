using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BoardPlayer : MonoBehaviour
{
    [SerializeField] private int _travelDelay = 1; 

    private S_Space _currentSpace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveToNextSpace(1));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(MoveToNextSpace(2));
        }
    }

    public void MovePlayer(S_Space targetSpace)
    {
        transform.Translate(new Vector3(targetSpace.transform.position.x - transform.position.x, 0, targetSpace.transform.position.z - transform.position.z) * .5f);
    }

    public void GameStart()
    {
        transform.position = new Vector3(S_BoardManager.Instance.startingSpace.transform.position.x, transform.position.y, S_BoardManager.Instance.startingSpace.transform.position.z);
        _currentSpace = S_BoardManager.Instance.startingSpace;
    }

    IEnumerator MoveToNextSpace(int spaces)
    {
        //Debug.Log(_currentSpace.GiveNextSpace());
        S_Space targetSpace = _currentSpace.GiveNextSpace();
        for(int i = 0; i < spaces; i++)
        {
            targetSpace = _currentSpace.GiveNextSpace();
            while ((Mathf.Round(transform.position.x) != Mathf.Round(targetSpace.transform.position.x)) || (Mathf.Round(transform.position.z) != Mathf.Round(targetSpace.transform.position.z)))
            {
                MovePlayer(targetSpace);
                yield return new WaitForSeconds(.1f);
                Debug.Log(targetSpace);
            }
            _currentSpace = targetSpace;
            yield return new WaitForSeconds(_travelDelay);
        }
        _currentSpace = targetSpace;
        _currentSpace.SpaceLandedOn();
        yield return null;
    }
}
