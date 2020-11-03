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
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job job1 = new Job("Web developer", "Skyward", "Cubicle", "Software engineer", "Front-end");
            Job job2 = new Job("Web developer", "Skyward", "Cubicle", "Software engineer", "Front-end");
            Assert.IsFalse(job1.Equals(job2));
        }
    }
}
