using System;
using TechTalk.SpecFlow;

namespace SeaBattleBDD
{
    [Binding]
    public class FiringSteps
    {
        [Given(@"I have a map of shots")]
        public void GivenIHaveAMapOfShots()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the map of shots is empty")]
        public void GivenTheMapOfShotsIsEmpty()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I'm shooting at origin")]
        public void WhenIMShootingAtOrigin()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"map of shots should contains one shot at origin")]
        public void ThenMapOfShotsShouldContainsOneShotAtOrigin()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
