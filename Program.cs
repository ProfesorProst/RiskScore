using DependencyCheck;
using DependencyCheck.Controller;
using DependencyCheck.Models;
using RiskScore.Controller;
using RiskScore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using T2FSv1.Controller;
using T2FSv1.Entity;

namespace T2FSv1
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectName = "index";
            string pathToProject = "C:\\Users\\profe\\Desktop\\index";
            string outFromat = "JSON";
            IdentifyVulnerabilities identifyVulnerabilities = new IdentifyVulnerabilities();
            List<DependencyVulnerabilityDB> dependencyVulnerabilityDBs = identifyVulnerabilities.OWASPDependencyCheck(projectName, pathToProject, outFromat);

            ContrDepenVulnDB cdv = new ContrDepenVulnDB();
            cdv.SaveList(dependencyVulnerabilityDBs);
            //Console.Read();

            dependencyVulnerabilityDBs = cdv.GetList();

            dependencyVulnerabilityDBs = dependencyVulnerabilityDBs.Where(x => x.dependency.fileName == projectName && x.dependency.filePath == pathToProject)
                .OrderBy(x => x.dateTime).ToList();

            DateTime dateTime = DateTime.Now;
            Dictionary<DependencyVulnerabilityDB, double> riskScoreEntities = new Dictionary<DependencyVulnerabilityDB, double>();
            RiskRules riskScore = new RiskRules();

            foreach (DependencyVulnerabilityDB dependencyVulnerabilityDB in dependencyVulnerabilityDBs)
            {
                double rez = 0;
                foreach(VulnerabilityDB vulnerability1 in dependencyVulnerabilityDB.vulnerabilityDBs)
                {
                    if (vulnerability1.vulnerability != null)
                    {
                        Console.WriteLine("Set vulnerability:");
                        vulnerability1.vulnerability = Convert.ToDouble(Console.ReadLine());
                    }
                    if (vulnerability1.threats != null)
                    {
                        Console.WriteLine("Set threats:");
                        vulnerability1.threats = Convert.ToDouble(Console.ReadLine());
                    }
                    if (vulnerability1.techDamage != null)
                    {
                        Console.WriteLine("Set techDamage:");
                        vulnerability1.techDamage = Convert.ToDouble(Console.ReadLine());
                    }
                    if (vulnerability1.bizDamage != null)
                    {
                        Console.WriteLine("Set bizDamage:");
                        vulnerability1.bizDamage = Convert.ToDouble(Console.ReadLine());
                    }

                    double rezult = riskScore.Calculete(new double[] { vulnerability1.vulnerability.GetValueOrDefault(), vulnerability1.threats.GetValueOrDefault()
                        , vulnerability1.techDamage.GetValueOrDefault(), vulnerability1.bizDamage.GetValueOrDefault() });

                    rez += rezult;
                }
                riskScoreEntities.Add(dependencyVulnerabilityDB, rez);
            }

            Console.WriteLine(riskScoreEntities);
            Console.ReadLine();

        }
    }
}
