using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SeaBattleBDD
{
    [Binding]
    public class ShipsPlacementSteps
    {
        private byte X = 0;
        private byte Y = 0;
        private byte L = 0;
        private bool D = Globals.HRZT;
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
            X = Globals.getRandom(0, 10);
            Y = Globals.getRandom(0, 10);
            gameEngine.putShip(actualMap, X, Y);
        }

        [Then(@"map should contains one ship at random point")]
        public void ThenMapShouldContainsOneShipAtRandomPoint()
        {
            expectMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectMap[i, j] = Globals.EMPTY;
                }
            }
            expectMap[X, Y] = Globals.SHIP;
            Assert.AreEqual(expectMap, actualMap);
        }

        [When(@"I put a big ship at random point")]
        public void WhenIPutABigShipAtRandomPoint()
        {
            X = Globals.getRandom(0, 10);
            Y = Globals.getRandom(0, 10);
            D = Convert.ToBoolean(Globals.getRandom(0, 2));
            byte Z = 0; if (!D) Z = X; else Z = Y;
            L = Globals.getRandom(1, Convert.ToByte(11 - Z));
            gameEngine.putShip(actualMap, X, Y, L, D);
        }

        [Then(@"map should contains one big ship at random point")]
        public void ThenMapShouldContainsOneBigShipAtRandomPoint()
        {
            expectMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectMap[i, j] = Globals.EMPTY;
                }
            }
            byte _X = X;
            byte _Y = Y;
            for (byte i = 0; i < L; i++)
            {
                expectMap[_X, _Y] = Globals.SHIP;
                if (!D) _X++; else _Y++;
            }
            Assert.AreEqual(expectMap, actualMap);
        }
    }
}
