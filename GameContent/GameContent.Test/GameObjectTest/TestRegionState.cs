﻿using NUnit.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameContent.Test
{
	[TestFixture]
	public class TestRegionState
	{
		Region region;
		MouseState currentState;
		MouseState previousState;

		[TestFixtureSetUp]
		public void SetUpRegion()
		{ 
			region = new Region(45, 45, 30, 30, null);
			currentState = new MouseState(60, 60, 0, ButtonState.Pressed, ButtonState.Released,
					 ButtonState.Released, ButtonState.Released, ButtonState.Released);
			previousState = new MouseState(44,44, 0, ButtonState.Released, ButtonState.Released,
		 			 ButtonState.Released, ButtonState.Released, ButtonState.Released);
		}

		[Test]
		public void TestIfRegionIsCreatedWith0() 
		{
			Assert.That(region.state, Is.EqualTo(0));
		}

		[Test]
		public void TestIfStateChangesTo1WhenClicked()
		{
			BoardStateManager.playerState = 1;
			region.InteractWithRegionState();
			Assert.That(region.state, Is.EqualTo(1));
		}

		[Test]
		public void TestIfStateDoesNotCHangeWhenAlreadyClicked()
		{
			region.state = -1;
			region.InteractWithRegionState();
			Assert.That(region.state, Is.EqualTo(-1));
		}

		[Test]
		public void TestStringResponseForState1()
		{
			region.state = 1;
			Assert.That(region.GetSymbol(), Is.EqualTo("X"));
		}

		[Test]
		public void TestStringResponseForStateMinus1()
		{
			region.state = -1;
			Assert.That(region.GetSymbol(), Is.EqualTo("O"));
		}

		[Test]
		public void TestStringResponseForState0()
		{
			region.state = 0;
			Assert.That(region.GetSymbol(), Is.EqualTo(""));
		}
	}
}
