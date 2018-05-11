using System;
using TechTalk.SpecFlow;

namespace SeaBattleBDD
{
    [Binding]
    public class PrintingSteps
    {
        [Given(@"I have a ships map")]
        public void GivenIHaveAShipsMap()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"ships map is empty")]
        public void GivenShipsMapIsEmpty()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have a shots map")]
        public void GivenIHaveAShotsMap()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"shots map is empty")]
        public void GivenShotsMapIsEmpty()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I make the result map")]
        public void WhenIMakeTheResultMap()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I print the result map")]
        public void WhenIPrintTheResultMap()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the output should be all water")]
        public void ThenTheOutputShouldBeAllWater()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
