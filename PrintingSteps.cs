using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SeaBattleBDD
{
    [Binding]
    public class PrintingSteps
    {
        private byte X = 0;
        private byte Y = 0;
        private byte L = 0;
        private bool D = Globals.HRZT;

        private bool[,] actualShipsMap;
        private bool[,] actualShotsMap;
        private char[,] actualResulMap;

        private bool[,] expectShotsMap;
        private bool[,] expectShipsMap;
        private char[,] expectResulMap;

        private GameEngine gameEngine = new GameEngine();

        [Given(@"I have a ships map")]
        public void GivenIHaveAShipsMap()
        {
            actualShipsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
        }

        [Given(@"ships map is empty")]
        public void GivenShipsMapIsEmpty()
        {
            actualShipsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    actualShipsMap[i, j] = Globals.EMPTY;
                }
            }
        }

        [Given(@"I have a shots map")]
        public void GivenIHaveAShotsMap()
        {
            actualShotsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
        }

        [Given(@"shots map is empty")]
        public void GivenShotsMapIsEmpty()
        {
            actualShotsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    actualShotsMap[i, j] = Globals.EMPTY;
                }
            }
        }
        
        [When(@"I make the result map")]
        public void WhenIMakeTheResultMap()
        {
            actualResulMap = gameEngine.makeResult(actualShipsMap, actualShotsMap);
        }
        
        [When(@"I print the result map")]
        public void WhenIPrintTheResultMap()
        {
            gameEngine.print(actualResulMap);
        }
        
        [Then(@"the output should be all water")]
        public void ThenTheOutputShouldBeAllWater()
        {
            expectResulMap = new char[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectResulMap[i, j] = Globals.WATER;
                }
            }
            Assert.AreEqual(expectResulMap, actualResulMap);
        }

        [Given(@"shots map contains one shot at random point")]
        public void GivenShotsMapContainsOneShotAtRandomPoint()
        {
            actualShotsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    actualShotsMap[i, j] = Globals.EMPTY;
                }
            }
            X = Globals.getRandom(0, 10);
            Y = Globals.getRandom(0, 10);
            actualShotsMap[X, Y] = Globals.SHOT;
        }

        [Then(@"the output should be all water except target point that should be miss")]
        public void ThenTheOutputShouldBeAllWaterExceptTargetPointThatShouldBeMiss()
        {
            expectResulMap = new char[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectResulMap[i, j] = Globals.WATER;
                }
            }
            expectResulMap[X, Y] = Globals.MISS;
            Assert.AreEqual(expectResulMap, actualResulMap);
        }

        [Given(@"ships map contains one big ship at random point")]
        public void GivenShipsMapContainsOneBigShipAtRandomPoint()
        {
            X = Globals.getRandom(0, 10);
            Y = Globals.getRandom(0, 10);
            D = Convert.ToBoolean(Globals.getRandom(0, 2));
            byte Z = 0; if (!D) Z = X; else Z = Y;
            L = Globals.getRandom(1, Convert.ToByte(11 - Z));
            gameEngine.putShip(actualShipsMap, X, Y, L, D);
        }

        [Given(@"shots map all opened")]
        public void GivenShotsMapAllOpened()
        {
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    actualShotsMap[i, j] = Globals.SHOT;
                }
            }
        }

        [Then(@"the output should be similar to ships map")]
        public void ThenTheOutputShouldBeSimilarToShipsMap()
        {
            expectResulMap = new char[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    if (!actualShipsMap[i, j])
                        expectResulMap[i, j] = Globals.MISS;
                    else
                        expectResulMap[i, j] = Globals.DEAD;
                }
            }
            Assert.AreEqual(expectResulMap, actualResulMap);
        }
    }
}
