using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Bindings;

namespace Games.Specs.Hooks
{
    [Binding]
    public class PlayerCharacterHooks
    {

        static ExtentReportUtils ReportUtils;

        [BeforeFeature]
        public static void PreSetup(FeatureContext featureContext)
        {
            ReportUtils = new ExtentReportUtils("C:/Users/SAURABH/source/repos/GamesSolution1/Games.Specs/Reports/test.html");

            ReportUtils.CreateFeature(featureContext.FeatureInfo.Title);

        }

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            ReportUtils.CreateScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void Cleanup(ScenarioContext scenarioContext)
        {
            var testError = scenarioContext.TestError;

            if (testError != null)
            {
                ReportUtils.MarkScenarioFail(testError.Message);
            }
        }

        [AfterStep]
        public void ReportSatusUpdate(ScenarioContext scenarioContext)
        {
            
            var stepDefinitionType = scenarioContext.StepContext.StepInfo.StepDefinitionType;

            var stepTextName = scenarioContext.StepContext.StepInfo.Text;

            if (stepDefinitionType == StepDefinitionType.Given)
            {
                ReportUtils.CreateGivenStep(stepTextName);
            } 
            else if (stepDefinitionType == StepDefinitionType.Then)
            {
                ReportUtils.CreateWhenStep(stepTextName);
            }
            else 
            {
                ReportUtils.CreateThenStep(stepTextName);
            }

            var testError = scenarioContext.StepContext.TestError;

            if(testError != null)
            {
                ReportUtils.MarkTestStepFail(testError.Message);


            }

        }

        [AfterFeature]
        public static void PostCleanup()
        {
            ReportUtils.FlushReport();
        }
    }
}
