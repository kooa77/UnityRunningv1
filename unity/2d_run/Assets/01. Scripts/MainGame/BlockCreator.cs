using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    // Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        // 일정 주기로 블럭을 생성
        if(_createInterval <= _createDuration)
        {
            _createDuration = 0.0f;
            CreateBlock();
        }
        _createDuration += Time.deltaTime;

    }

    // Create

    public GameObject BlockPrefabs;

    float _createInterval = 2.0f;
    float _createDuration = 0.0f;

    void CreateBlock()
    {
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;
        GameObject.Destroy(blockObject, 7.0f);
    }
}
