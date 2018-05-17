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
        private bool[,] actualShipsMap;
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
            X = Globals.getRandom(0, 10);
            Y = Globals.getRandom(0, 10);
        }

        [When(@"I'm shooting at random point")]
        public void WhenIMShootingAtRandomPoint()
        {
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
            actualShipsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    actualShipsMap[i, j] = Globals.EMPTY;
                }
            }
            actualShipsMap[X, Y] = Globals.SHIP;
        }

        [When(@"I'm shooting at the random point via new function")]
        public void WhenIMShootingAtTheRandomPointViaNewFunction()
        {
            gameEngine.putShot(actualMap, actualShipsMap, X, Y);
        }

        [Then(@"map of shots should contains explosion around the target")]
        public void ThenMapOfShotsShouldContainsExplosionAroundTheTarget()
        {
            expectMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    expectMap[i, j] = Globals.EMPTY;
                }
            }
            byte _X = 0;
            byte _Y = 0;
            if (Globals.EXPLOSIONRADIUS > X)
                _X = 0;
            else
                _X = Convert.ToByte(X - Globals.EXPLOSIONRADIUS);
            if (Globals.EXPLOSIONRADIUS > Y)
                _Y = 0;
            else
                _Y = Convert.ToByte(Y - Globals.EXPLOSIONRADIUS);
            byte X_ = 0;
            byte Y_ = 0;
            if (X + Globals.EXPLOSIONRADIUS < Globals.MAPSIZE)
                X_ = Convert.ToByte(X + Globals.EXPLOSIONRADIUS);
            else
                X_ = Globals.MAPSIZE - 1;
            if (Y + Globals.EXPLOSIONRADIUS < Globals.MAPSIZE)
                Y_ = Convert.ToByte(Y + Globals.EXPLOSIONRADIUS);
            else
                Y_ = Globals.MAPSIZE - 1;
            for (byte i = _X; i < X_; i++)
            {
                for (byte j = _Y; j < Y_; j++)
                {
                    expectMap[i, j] = Globals.SHOT;
                }
            }
            Assert.AreEqual(expectMap, actualMap);
        }
    }
}
