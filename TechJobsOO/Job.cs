using System;
namespace TechJobsNS
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public Job ()
        {
            Id = nextId;
            nextId++;
        }

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        /*        Code a second constructor that takes 5 parameters and assigns values to name, employerName, employerLocation, jobType, and jobCoreCompetency.Also, this constructor should call the first in order to initialize the id field.
        */
        public Job(string jobName, string erName, string erLocation, string jobType, string jobCoreCompetency) : this()
        {
            Name = jobName;
            EmployerName = new Employer(erName);
            EmployerLocation = new Location(erLocation);
            JobType = new PositionType(jobType);
            JobCoreCompetency = new CoreCompetency(jobCoreCompetency);
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


        // TODO: Generate Equals() and GetHashCode() methods.
    }
}
