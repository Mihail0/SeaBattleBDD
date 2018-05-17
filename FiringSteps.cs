using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SeaBattleBDD
{
    [Binding]
    public class FiringSteps
    {
        private byte X = 0;
        private byte Y = 0;
        private bool[,] actualMap;
        private bool[,] expectMap;
        private GameEngine gameEngine = new GameEngine();

        [Given(@"I have a map of shots")]
        public void GivenIHaveAMapOfShots()
        {
            actualMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
        }
        
        [Given(@"the map of shots is empty")]
        public void GivenTheMapOfShotsIsEmpty()
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
        
        [When(@"I'm shooting at origin")]
        public void WhenIMShootingAtOrigin()
        {
            gameEngine.putShot(actualMap, 0, 0);
        }
        
        [Then(@"map of shots should contains one shot at origin")]
        public void ThenMapOfShotsShouldContainsOneShotAtOrigin()
        {
            expectMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectMap[i, j] = Globals.EMPTY;
                }
            }
            expectMap[0, 0] = Globals.SHOT;
            Assert.AreEqual(expectMap, actualMap);
        }

        [Given(@"I have a random point")]
        public void GivenIHaveARandomPoint()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I'm shooting at random point")]
        public void WhenIMShootingAtRandomPoint()
        {
            X = Globals.getRandom(0, 10);
            Y = Globals.getRandom(0, 10);
            gameEngine.putShot(actualMap, X, Y);
        }

        [Then(@"map of shots should contains one shot at target point")]
        public void ThenMapOfShotsShouldContainsOneShotAtTargetPoint()
        {
            expectMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectMap[i, j] = Globals.EMPTY;
                }
            }
            expectMap[X, Y] = Globals.SHOT;
            Assert.AreEqual(expectMap, actualMap);
        }

        [Given(@"ships map contains single ship at the random point")]
        public void GivenShipsMapContainsSingleShipAtTheRandomPoint()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I'm shooting at the random point via new function")]
        public void WhenIMShootingAtTheRandomPointViaNewFunction()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"map of shots should contains explosion around the target")]
        public void ThenMapOfShotsShouldContainsExplosionAroundTheTarget()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
