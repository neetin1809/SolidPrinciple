using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple
{
    public class DeveloperReport
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Level { get; set; }
        public int WorkingHours { get; set; }
        public double HourlyRate { get; set; }
    }

    internal class SalaryCalculatorExample
    {
        private readonly IEnumerable<DeveloperReport> _developerReports;

        public SalaryCalculatorExample(List<DeveloperReport> developerReports)
        {
            _developerReports = developerReports;
        }

        public  double CalculateSalary()
        {
            double totalSalaries = 0D;
            foreach (var devReport in _developerReports)
            {
                totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
            }
            return totalSalaries;
       }
        /*
         * var devReports = new List<DeveloperReport>
    {
        new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 160 },
        new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate  = 20, WorkingHours = 150 },
        new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 180 }
    };
    var calculator = new SalaryCalculator(devReports);
         */


        //Now Modification for Senior developers

        internal class SalaryCalculatorExample1
        {
            private readonly IEnumerable<DeveloperReport> _developerReports;

            public SalaryCalculatorExample1(List<DeveloperReport> developerReports)
            {
                _developerReports = developerReports;
            }

            public double CalculateSalary()
            {
                double totalSalaries = 0D;
                foreach (var devReport in _developerReports)
                {
                    if (devReport.Level == "Senior Developer")
                    {
                        totalSalaries += devReport.HourlyRate * devReport.WorkingHours * 1.2;
                    }
                    else
                    {
                        totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
                    }
                }
                return totalSalaries;
            }
        }

        public abstract class BaseSalaryCalculator
        {
            protected DeveloperReport DeveloperReport { get; set;    }

            public BaseSalaryCalculator(DeveloperReport developerReport)
            {
                DeveloperReport = developerReport;
            }    

            public abstract double CalculateSalary();
        }
        public class SeniorDevSalaryCalculator : BaseSalaryCalculator
        {
            public SeniorDevSalaryCalculator(DeveloperReport devReport) : base(devReport)
            {

            }

            public override double CalculateSalary()
            {
                return DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
            }
        }

        public class JuniorDevSalaryCalculator : BaseSalaryCalculator
        {
            public JuniorDevSalaryCalculator(DeveloperReport devReport) : base(devReport)
            {

            }

            public override double CalculateSalary()
            {
                return DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
            }
        }

        public class SalaryCalculator
        {
            private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;
            public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
            {
                _developerCalculation = developerCalculation;
            }
            public double CalculateTotalSalaries()
            {
                double totalSalaries = 0D;
                foreach (var devCalc in _developerCalculation)
                {
                    totalSalaries += devCalc.CalculateSalary();
                }
                return totalSalaries;
            }
        }
    }
