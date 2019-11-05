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

            dependencyVulnerabilityDBs = dependencyVulnerabilityDBs.Where(x => x.fileScaning == pathToProject+projectName)
                .OrderBy(x => x.dateTime).ToList();

            RiskRules riskRules = new RiskRules();
            DateTime dateTime = new DateTime();
            List<RiskScoreEntities> riskScoreEntities = new List<RiskScoreEntities>();

            ProcessDepend processDepend = new ProcessDepend(riskRules);
            foreach (DependencyVulnerabilityDB dependencyVulnerabilityDB in dependencyVulnerabilityDBs.ToList())
            {
                List<VulnerabilityDB> vulnerabilitiesNew = new List<VulnerabilityDB>();
                double sum = 0;
                foreach(VulnerabilityDB vulnerability in dependencyVulnerabilityDB.vulnerabilityDBs)
                {
                    vulnerabilitiesNew.Add(processDepend.SetParamsConsole(vulnerability));
                    sum += vulnerability.rezult.GetValueOrDefault();
                }                   

                dependencyVulnerabilityDB.vulnerabilityDBs = vulnerabilitiesNew;
                cdv.Save(dependencyVulnerabilityDB);

                if (dependencyVulnerabilityDB.dateTime != dateTime)
                {
                    RiskScoreEntities risk = new RiskScoreEntities(dateTime);
                    riskScoreEntities.Add(risk);
                }

                riskScoreEntities.Find(x => x.dateTime == dateTime).AddDependencyVulnerabilityDBs(dependencyVulnerabilityDB);
                riskScoreEntities.Find(x => x.dateTime == dateTime).score += sum;
            }

            Console.WriteLine(riskScoreEntities);
            Console.ReadLine();

        }
    }
}
