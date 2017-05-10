﻿using NUnit.Framework;
using System;
using GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameContent.Test
{
	[TestFixture()]
	public class StateManagerTest
	{
		Board gameBoard;
		BoardStateManager stateManager;
		MouseState currentState, previousState;

		[TestFixtureSetUp()]
		public void  StateManagerSetUp()
		{
			gameBoard = new Board();
			stateManager = new BoardStateManager();
			currentState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released,
					ButtonState.Released, ButtonState.Released, ButtonState.Released);
			previousState = new MouseState(250, 250, 0, ButtonState.Released, ButtonState.Released,
		  			ButtonState.Released, ButtonState.Released, ButtonState.Released);

		}

		[Test()]
		public void TestIfTheRegionIsClicked()
		{

			Assert.That(stateManager.ClickedRegion(gameBoard.regions, currentState, 
			                                            previousState), Is.EqualTo(4));
		}

		[Test()]
		public void TestIfClickIsOutsideRegions()
		{
			MouseState current = new MouseState(50, 50, 0, ButtonState.Pressed, ButtonState.Released,
					ButtonState.Released, ButtonState.Released, ButtonState.Released);
			Assert.That(stateManager.ClickedRegion(gameBoard.regions, current,
												previousState), Is.EqualTo(-1));
		}

		[Test()]
		public void TestIfClickInLinesRetunsNegative()
		{
			MouseState current = new MouseState(196, 101, 0, ButtonState.Pressed, ButtonState.Released,
					ButtonState.Released, ButtonState.Released, ButtonState.Released);
			Assert.That(stateManager.ClickedRegion(gameBoard.regions, current,
										previousState), Is.EqualTo(-1));
		}

		[Test()]
		public void TestIfClickedRegionHasChangedState()
		{
			int idx = stateManager.ClickedRegion(gameBoard.regions, currentState, previousState);
			stateManager.UpdateClickedRegionState(gameBoard.regions, idx);
			Assert.That(gameBoard.regions[4].state, Is.EqualTo(1));
		}

		[Test()]
		public void TestIfDifferentClickedRegionsHaveDiffStates() 
		{
			gameBoard.regions[3].InteractWithRegionState();
			Assert.That(gameBoard.regions[3].state, Is.EqualTo(1));
			gameBoard.regions[4].InteractWithRegionState();
			Assert.That(gameBoard.regions[4].state, Is.EqualTo(-1));
		}
	}
}
