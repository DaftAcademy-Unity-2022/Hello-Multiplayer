using Elympics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : ElympicsMonoBehaviour, IUpdatable, IInputHandler
{
	private ElympicsInt pointsValue = new ElympicsInt(0);
	public int PointsValue => pointsValue.Value;

	private bool buttonPressed = false;

	public void ProcessButtonPressed()
	{
		//referenced by Unity
		buttonPressed = true;
	}

	public void OnInputForBot(IInputWriter inputSerializer)
	{
		//...
	}

	public void OnInputForClient(IInputWriter inputSerializer)
	{
		inputSerializer.Write(buttonPressed);

		buttonPressed = false;
	}

	public void ElympicsUpdate()
	{
		for (int playerId = 0; playerId < 2; playerId++)
			if (ElympicsBehaviour.TryGetInput(ElympicsPlayer.FromIndex(playerId), out IInputReader inputReader))
			{
				inputReader.Read(out bool buttonPressed);

				if (buttonPressed)
				{
					pointsValue.Value++;
				}
			}
	}
}
