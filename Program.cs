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
            Dictionary<DependencyVulnerabilityDB,int> riskScoreEntities = new Dictionary<DependencyVulnerabilityDB, int>();
            if (dependencyVulnerabilityDBs.First() != null)
            {
                dateTime = dependencyVulnerabilityDBs.First().dateTime;
                riskScoreEntities.Add(new RiskScoreEntity(dateTime));
            }
               
            foreach (DependencyVulnerabilityDB dependencyVulnerabilityDB in dependencyVulnerabilityDBs)
            {
                if(dependencyVulnerabilityDB.dateTime == dateTime)
                {
                    riskScoreEntities.Add
                }
                else
                {

                }


            }



            double vulnerability = 10.0;
            double threats = 1.0;
            double techDamage = 1.0;
            double bizDamage = 1.0;

            Console.WriteLine("vulnerability : " + vulnerability);
            Console.WriteLine("threats : " + threats);
            Console.WriteLine("Tech Damage : " + techDamage);
            Console.WriteLine("Biz Damage : " + bizDamage);

            RiskRules riskScore = new RiskRules();
            double rezult = riskScore.Calculete(new double[] { vulnerability, threats, techDamage, bizDamage });
            Console.WriteLine(rezult);
            Console.ReadLine();

        }
    }
}
