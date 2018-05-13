using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SeaBattleBDD
{
    [Binding]
    public class PrintingSteps
    {
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
            ScenarioContext.Current.Pending();
        }

        [Then(@"the output should be all water except target point that should be miss")]
        public void ThenTheOutputShouldBeAllWaterExceptTargetPointThatShouldBeMiss()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
