using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Specs
{
    public class ExtentReportUtils
    {

        private ExtentReports extentReports;

        private ExtentSparkReporter sparkReporter;

        private ExtentTest feature;

        private ExtentTest scenario;

        private ExtentTest testStep;

        public ExtentReportUtils(string reportFilename)
        {
            _ = reportFilename.Trim();

            extentReports = new ExtentReports();

            sparkReporter = new ExtentSparkReporter(reportFilename);

            extentReports.AttachReporter(sparkReporter);

        }

        public void CreateFeature(string featureName)
        {
            feature = extentReports.CreateTest(featureName);
        }

        public void CreateScenario(string scenarioName)
        {
            scenario = feature.CreateNode(scenarioName);
        }

        public void CreateGivenStep(string stepName)
        {
          testStep =  scenario.CreateNode<Given>(stepName);

        }

        public void CreateWhenStep(string stepName)
        {
            testStep = scenario.CreateNode<When>(stepName);
        }

        public void CreateThenStep(string stepName)
        {
            testStep=  scenario.CreateNode<Then>(stepName);
        }

        public void MarkTestStepFail(string message)
        {

            testStep.Log(Status.Fail, message);
        }

        public void MarkScenarioFail(string message)
        {

            scenario.Log(Status.Fail, message);
        }

        public void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
