using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightSlider : MonoBehaviour
{
    public GameObject Indicator;

	void Start ()
    {
        float maxWeight = GameManager.Instance.GetPlayer().GetMaxWeight();
        float goalWeight = GameManager.Instance.GetPlayer().GetGoalWeight();
        float rate = goalWeight / maxWeight;

        float sliderWidth = 500.0f;
        float posX = sliderWidth * rate - (sliderWidth/2.0f);
        Indicator.transform.localPosition = new Vector3(posX, 0.0f, 0.0f);
    }
	
	void Update ()
    {
        // 캐릭터의 체력 정보를 가져와서, UI 반영해주면 된다.
        float maxWeight = GameManager.Instance.GetPlayer().GetMaxWeight();
        float currentWeight = GameManager.Instance.GetPlayer().GetCurrentWeight();
        float rate = currentWeight / maxWeight;
        gameObject.GetComponent<Slider>().value = rate;
    }
}
