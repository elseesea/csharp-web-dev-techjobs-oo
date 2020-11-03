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

        public Job(string jobName, Employer employer, Location location, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = jobName;
            EmployerName = employer;
            EmployerLocation = location;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.
        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            bool idOnly = true;
            string output = "\n";
            output += "ID: " + Id;
            output += "\nName: ";
            if (Name == null || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Name.Trim())) {
                output += "Data not available";
            } else {
                output += Name;
                idOnly = false;
            };
            output += "\nEmployer: ";
            if (EmployerName == null || String.IsNullOrEmpty(EmployerName.Value) || String.IsNullOrEmpty(EmployerName.Value.Trim())) {
                output += "Data not available";
            }
            else
            {
                output += EmployerName.Value;
                idOnly = false;
            };
            output += "\nLocation: ";
            if (EmployerLocation == null || String.IsNullOrEmpty(EmployerLocation.Value) || String.IsNullOrEmpty(EmployerLocation.Value.Trim())) {
                output += "Data not available";
            }
            else
            {
                output += EmployerLocation.Value;
                idOnly = false;
            };
            output += "\nPosition Type: ";
            if (JobType == null || String.IsNullOrEmpty(JobType.Value) || String.IsNullOrEmpty(JobType.Value.Trim())) {
                output += "Data not available";
            }
            else
            {
                output += JobType.Value;
                idOnly = false;
            };
            output += "\nCore Competency: ";
            if (JobCoreCompetency == null || String.IsNullOrEmpty(JobCoreCompetency.Value) || String.IsNullOrEmpty(JobCoreCompetency.Value.Trim())) {
                output += "Data not available";
            }
            else
            {
                output += JobCoreCompetency.Value;
                idOnly = false;
            };
            output += "\n";
            if (idOnly)
            {
                return "\n“OOPS! This job does not seem to exist.\n";
            }
            return output;
        }

    } // class
} // namespace
