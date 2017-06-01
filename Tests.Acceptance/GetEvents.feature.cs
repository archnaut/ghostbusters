﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.Acceptance
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GetEventsFeature : Xunit.IClassFixture<GetEventsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetEvents.feature"
#line hidden
        
        public GetEventsFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetEvents", "\tIn order to browse upcoming events\r\n\tAs api consumer \r\n\tI want to be given avail" +
                    "able events", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(GetEventsFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Upcoming Event")]
        [Xunit.TraitAttribute("FeatureTitle", "GetEvents")]
        [Xunit.TraitAttribute("Description", "Get Upcoming Event")]
        [Xunit.TraitAttribute("Category", "mytag")]
        public virtual void GetUpcomingEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Upcoming Event", new string[] {
                        "mytag"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "On Sale Date",
                        "Doors Open Date",
                        "Event Start Date",
                        "Event End Date"});
            table1.AddRow(new string[] {
                        "1",
                        "Annual Charity Event",
                        "30 days ago",
                        "4 days 13 hours from now",
                        "5 days 14 hours from now",
                        "5 days 17 hours from now"});
#line 8
 testRunner.Given("upcoming event", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Port",
                        "Method",
                        "Path"});
            table2.AddRow(new string[] {
                        "53735",
                        "GET",
                        "api/Events"});
#line 11
 testRunner.When("I make a  call to", ((string)(null)), table2, "When ");
#line 14
 testRunner.Then("the response status code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("the response body contains the event", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetEventsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetEventsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
