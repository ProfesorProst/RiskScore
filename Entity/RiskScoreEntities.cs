using System;
using System.Collections.Generic;
using System.Text;
using DependencyCheck.Models;

namespace RiskScore.Entity
{
    class RiskScoreEntities
    {
        DateTime dateTime { get; }

        List<DependencyVulnerabilityDB> dependencyVulnerabilityDBs { get; }

        int score { get; set; }

        public RiskScoreEntities(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

    }
}
