using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsNS;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job job1 = new Job();
            Job job2 = new Job();
            Assert.AreEqual(job2.Id - job1.Id, 1);
            Assert.IsFalse(job1.Equals(job2));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            /*            Declare and initialize a new Job object with the following data: "Product tester" for Name, "ACME" for EmployerName, "Desert" for JobLocation, "Quality control" for JobType, and "Persistence" for JobCoreCompetency
            */
            Job job = new Job("Product tester", "ACME", "Desert", "Quality control", "Persistence");
            Assert.IsTrue(job.Name.Equals("Product tester"));
            Assert.IsTrue(job.EmployerName.Value.Equals("ACME"));
            Assert.IsTrue(job.EmployerLocation.Value.Equals("Desert"));
            Assert.IsTrue(job.JobType.Value.Equals("Quality control"));
            Assert.IsTrue(job.JobCoreCompetency.Value.Equals("Persistence"));

            Job job2 = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            Assert.IsTrue(job2.Name.Equals("Web Developer"));
            Assert.IsTrue(job2.EmployerName.Value.Equals("LaunchCode"));
            Assert.IsTrue(job2.EmployerLocation.Value.Equals("St. Louis"));
            Assert.IsTrue(job2.JobType.Value.Equals("Front-end developer"));
            Assert.IsTrue(job2.JobCoreCompetency.Value.Equals("JavaScript"));
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job job1 = new Job("Web developer", "Skyward", "Cubicle", "Software engineer", "Front-end");
            Job job2 = new Job("Web developer", "Skyward", "Cubicle", "Software engineer", "Front-end");
            Assert.IsFalse(job1.Equals(job2));

            Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsFalse(job3.Equals(job4));

        }

        Job testJob, testJob2;
        string jobToString, job2ToString;
        int outLength, out2Length;
        [TestInitialize]
        public void CreateJobObject()
        {
            testJob = new Job("Product tester", "ACME", "Desert", "Quality control", "Persistence");
            jobToString = testJob.ToString();
            outLength = jobToString.Length;
            testJob2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            job2ToString = testJob2.ToString();
            out2Length = job2ToString.Length;
        }

        [TestMethod]
        public void TestToStringFirstLastLinesBlank()
        {
            //Assert.IsTrue(outLength == 2);
            Assert.IsTrue(jobToString[0].Equals('\n')); // test for first blank line
            Assert.IsTrue(jobToString[outLength - 1].Equals('\n')); // test for last blank line
            Assert.IsTrue(job2ToString[0].Equals('\n')); // test for first blank line
            Assert.IsTrue(job2ToString[outLength - 1].Equals('\n')); // test for last blank line
        }

        [TestMethod]
        public void TestToStringJobDescription()
        {
            string correctOutput = "\nID: " + testJob.Id
                + "\nName: " + testJob.Name
                + "\nEmployer: " + testJob.EmployerName
                + "\nLocation: " + testJob.EmployerLocation
                + "\nPosition Type: " + testJob.JobType
                + "\nCore Competency: " + testJob.JobCoreCompetency + "\n";
            Assert.AreEqual(correctOutput, testJob.ToString());

            string correctOutput2 = "\nID: " + testJob2.Id
                + "\nName: " + testJob2.Name
                + "\nEmployer: " + testJob2.EmployerName
                + "\nLocation: " + testJob2.EmployerLocation
                + "\nPosition Type: " + testJob2.JobType
                + "\nCore Competency: " + testJob2.JobCoreCompetency + "\n";
            Assert.AreEqual(correctOutput2, testJob2.ToString());
        }

        [TestMethod]
        public void TestToStringEmptyField()
        {
            Job job = new Job("Product tester", "ACME", "Desert", "", "Persistence");
            string jobString = job.ToString();
            string expectedOutput = "\nID: " + job.Id
                + "\nName: " + job.Name
                + "\nEmployer: " + job.EmployerName
                + "\nLocation: " + job.EmployerLocation
                + "\nPosition Type: Data not available"
                + "\nCore Competency: " + job.JobCoreCompetency + "\n";
            Assert.AreEqual(expectedOutput, job.ToString());

            Job job2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType(), new CoreCompetency("Persistence"));
            jobString = job.ToString();
            expectedOutput = "\nID: " + job2.Id
                + "\nName: " + job2.Name
                + "\nEmployer: " + job2.EmployerName
                + "\nLocation: " + job2.EmployerLocation
                + "\nPosition Type: Data not available"
                + "\nCore Competency: " + job.JobCoreCompetency + "\n";
            Assert.AreEqual(expectedOutput, job2.ToString());
        }

        [TestMethod]
        public void TestToStringAllFieldsEmpty()
        {
            Job job = new Job();
            string jobString = job.ToString();
            string expectedOutput = "\n“OOPS! This job does not seem to exist.\n";
            Assert.AreEqual(expectedOutput, jobString);
        }
    } // class
} // namespace
