using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
	[SerializeField] private PointsController pointsController = null;
	[SerializeField] private TextMeshProUGUI pointsText = null;

	private void Update()
	{
		pointsText.text = pointsController.PointsValue.ToString();
	}
}
