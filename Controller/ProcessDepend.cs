using DependencyCheck.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskScore.Controller
{
    class ProcessDepend
    {
        private RiskRules riskRules;

        public ProcessDepend(RiskRules riskRules)
        {
            this.riskRules = riskRules;
        }
        public VulnerabilityDB SetParamsConsole(VulnerabilityDB vulnerability)
        {
            if (vulnerability.vulnerability == null)
            {
                Console.WriteLine("Set vulnerability:");
                vulnerability.vulnerability = Convert.ToDouble(Console.ReadLine());
            }
            if (vulnerability.threats == null)
            {
                Console.WriteLine("Set threats:");
                vulnerability.threats = Convert.ToDouble(Console.ReadLine());
            }
            if (vulnerability.techDamage == null)
            {
                Console.WriteLine("Set techDamage:");
                vulnerability.techDamage = Convert.ToDouble(Console.ReadLine());
            }
            if (vulnerability.bizDamage == null)
            {
                Console.WriteLine("Set bizDamage:");
                vulnerability.bizDamage = Convert.ToDouble(Console.ReadLine());
            }
                        
            vulnerability.rezult = vulnerability.rezult == null? riskRules.Calculete(new double[] { vulnerability.vulnerability.GetValueOrDefault(), vulnerability.threats.GetValueOrDefault()
                        , vulnerability.techDamage.GetValueOrDefault(), vulnerability.bizDamage.GetValueOrDefault() }): vulnerability.rezult;
            return vulnerability;
        }
    }
}
