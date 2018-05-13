﻿using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SeaBattleBDD
{
    [Binding]
    public class ShipsPlacementSteps
    {
        private bool[,] actualMap;
        private bool[,] expectMap;
        private GameEngine gameEngine = new GameEngine();

        [Given(@"I have a sea battle map")]
        public void GivenIHaveASeaBattleMap()
        {
            actualMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
        }
        
        [Given(@"the map is empty")]
        public void GivenTheMapIsEmpty()
        {
            actualMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    actualMap[i, j] = Globals.EMPTY;
                }
            }
        }
        
        [When(@"I put a ship at origin")]
        public void WhenIPutAShipAtOrigin()
        {
            gameEngine.putShip(actualMap, 0, 0);
        }
        
        [Then(@"map should contains one ship at origin")]
        public void ThenMapShouldContainsOneShipAtOrigin()
        {
            expectMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectMap[i, j] = Globals.EMPTY;
                }
            }
            expectMap[0, 0] = Globals.SHIP;
            Assert.AreEqual(expectMap, actualMap);
        }

        [When(@"I put a ship at random point")]
        public void WhenIPutAShipAtRandomPoint()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"map should contains one ship at random point")]
        public void ThenMapShouldContainsOneShipAtRandomPoint()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
