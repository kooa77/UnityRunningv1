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
        if (false == _isCreate)
            return;

        // 일정 거리로 블럭을 생성
        float distance = transform.position.x - _lastBlockObject.transform.position.x;
        //if(20 <= distance)
        if (15 <= distance)
        {
            _lastBlockObject = CreateBlock();
        }
    }

    // Create

    public GameObject BlockPrefabs;
    public GameObject VegetablePrefabs;

    GameObject _lastBlockObject;

    GameObject CreateBlock()
    {
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;

        // 코인을 생성 -> 2층에 배치
        GameObject vegetableObject = GameObject.Instantiate(VegetablePrefabs);
        vegetableObject.transform.position = new Vector2(transform.position.x,
                                                transform.position.y + 3.5f);

        int randValue = Random.Range(0, 1000);
        if(randValue < 300)
        {
            // 2층
            blockObject.transform.position = new Vector2(blockObject.transform.position.x,
                blockObject.transform.position.y + 3.5f);

            // 코인을 1층 배치로 변경
            vegetableObject.transform.position = transform.position;
        }

        return blockObject;
    }


    bool _isCreate = false;

    public void StartCreate()
    {
        _isCreate = true;
        _lastBlockObject = CreateBlock();
    }
}
