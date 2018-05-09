using System;
using TechTalk.SpecFlow;

namespace SeaBattleBDD
{
    [Binding]
    public class ShipsPlacementSteps
    {
        [Given(@"I have a sea battle map")]
        public void GivenIHaveASeaBattleMap()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the map is empty")]
        public void GivenTheMapIsEmpty()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I put a ship at origin")]
        public void WhenIPutAShipAtOrigin()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"map should contains one ship at origin")]
        public void ThenMapShouldContainsOneShipAtOrigin()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
