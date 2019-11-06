﻿using System;
using System.Collections.Generic;
using System.Text;
using T2FSv1.Controller;
using T2FSv1.Entity;

namespace RiskScore.Controller
{
    class RiskRules
    {
        T2FS t2FS;
        List<Rule> ruleList;
        public RiskRules()
        {
            Init();
        }

        public double Calculete(double[] inputs)
        {
            t2FS = new T2FS(ruleList, inputs);
            return t2FS.Calculete();
        }

        private void Init()
        {
            //vulnerabilityLittle vulnerabilityModerate vulnerabilityMax
            IMemFunc vulnerabilityLittle = new TrapezeMF(0, 0, 2, 3.5, 0, 0, 1.5, 2.5);
            IMemFunc vulnerabilityModerate = new TrapezeMF(2.5, 3.5, 6.5, 7.5, 3.5, 4, 6, 6.5);
            IMemFunc vulnerabilityMax = new TrapezeMF(6, 9, 10, 10, 7.5, 9, 10, 10);

            //threatsLittle threatsSome threatsModeerate threatsLarge threatsMax
            IMemFunc threatsLittle = new TrapezeMF(0, 0, 2.5, 3.5, 0, 0, 1.5, 2.5);
            IMemFunc threatsSome = new TrapezeMF(1, 2.5, 3.5, 5, 2, 3, 3, 4);
            IMemFunc threatsModeerate = new TrapezeMF(2.5, 4, 6, 7.5, 3.5, 4, 6, 6.5);
            IMemFunc threatsLarge = new TrapezeMF(5, 6.5, 8.5, 10, 6, 7, 8, 9);
            IMemFunc threatsMax = new TrapezeMF(6, 9, 10, 10, 7.5, 9, 10, 10);

            //techDamageNegligble techDamageModerate techDamageCritical
            IMemFunc techDamageNegligble = new TrapezeMF(0, 0, 2, 3.5, 0, 0, 1.5, 2.5);
            IMemFunc techDamageModerate = new TrapezeMF(2.5, 3.5, 6.5, 7.5, 3.5, 4, 6, 6.5);
            IMemFunc techDamageCritical = new TrapezeMF(6, 9, 10, 10, 7.5, 9, 10, 10);

            //bizDamageNeglible bizDamageMinor bizDamageModerate bizDamageCritical bizDamageCatastrophic
            IMemFunc bizDamageNeglible = new TrapezeMF(0, 0, 2.5, 3.5, 0, 0, 1.5, 2.5);
            IMemFunc bizDamageMinor = new TrapezeMF(1, 2.5, 3.5, 5, 2, 3, 3, 4);
            IMemFunc bizDamageModerate = new TrapezeMF(2.5, 4, 6, 7.5, 3.5, 4, 6, 6.5);
            IMemFunc bizDamageCritical = new TrapezeMF(5, 6.5, 8.5, 10, 6, 7, 8, 9);
            IMemFunc bizDamageCatastrophic = new TrapezeMF(6, 9, 10, 10, 7.5, 9, 10, 10);

            IMemFunc rezultLow = new TrapezeMF(0, 0, 1.5, 3.5, 0, 0, 1.5, 2.5);
            IMemFunc rezultMedium = new TrapezeMF(1, 2.5, 4.5, 6.5, 2, 3, 4, 5.5);
            IMemFunc rezultHigh = new TrapezeMF(4, 5.5, 7.5, 9, 5, 6, 7, 8);
            IMemFunc rezultExtreme = new TrapezeMF(7, 8.5, 10, 10, 8, 8.5, 10, 10);
            
            ruleList = new List<Rule>();
            
            //vulnerabilityLittle                           vulnerabilityModerate                       vulnerabilityMax
            //threatsLittle         threatsSome             threatsModeerate        threatsLarge        threatsMax
            //techDamageNegligble                           techDamageModerate                          techDamageCritical
            //bizDamageNeglible     bizDamageMinor          bizDamageModerate       bizDamageCritical   bizDamageCatastrophic
            t2FS = new T2FS();
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageNegligble, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageNegligble, bizDamageModerate }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageNegligble, bizDamageCatastrophic }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageModerate, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageModerate, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageModerate, bizDamageModerate }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageModerate, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageModerate, bizDamageCatastrophic }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageCritical, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageCritical, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageCritical, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageCritical, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLittle, techDamageCritical, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageNegligble, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageNegligble, bizDamageModerate }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageNegligble, bizDamageCatastrophic }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageModerate, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageModerate, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageModerate, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageCritical, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageCritical, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageCritical, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsSome, techDamageCritical, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageNegligble, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageNegligble, bizDamageModerate }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageNegligble, bizDamageCatastrophic }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageModerate, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageModerate, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageModerate, bizDamageCatastrophic }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageCritical, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageCritical, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageCritical, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsModeerate, techDamageCritical, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageNegligble, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageModerate, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageCritical, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageCritical, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsLarge, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageNegligble, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageNegligble, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageModerate, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageCritical, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageCritical, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityLittle, threatsMax, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageNegligble, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageModerate, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageModerate, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageModerate, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageCritical, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageCritical, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLittle, techDamageCritical, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageNegligble, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageModerate, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageCritical, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageCritical, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsSome, techDamageCritical, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageNegligble, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageModerate, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageModerate, bizDamageCatastrophic }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageCritical, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageCritical, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsModeerate, techDamageCritical, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageNegligble, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageNegligble, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageNegligble, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageModerate, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageCritical, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageCritical, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsLarge, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageNegligble, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageNegligble, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageNegligble, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageModerate, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageCritical, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageCritical, bizDamageCritical }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityModerate, threatsMax, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageNegligble, bizDamageMinor }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageNegligble, bizDamageCatastrophic }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageModerate, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageCritical, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageCritical, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLittle, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageNegligble, bizDamageNeglible }, rezultLow, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageNegligble, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageNegligble, bizDamageCritical }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageModerate, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageModerate, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageModerate, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageModerate, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageCritical, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageCritical, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageCritical, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageCritical, bizDamageCritical }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsSome, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageNegligble, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageNegligble, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageNegligble, bizDamageModerate }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageNegligble, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageModerate, bizDamageMinor }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageModerate, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageModerate, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageModerate, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageCritical, bizDamageNeglible }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageCritical, bizDamageMinor }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageCritical, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageCritical, bizDamageCritical }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsModeerate, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageNegligble, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageNegligble, bizDamageMinor }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageNegligble, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageNegligble, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageNegligble, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageModerate, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageModerate, bizDamageMinor }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageModerate, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageModerate, bizDamageCritical }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageModerate, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageCritical, bizDamageNeglible }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageCritical, bizDamageMinor }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageCritical, bizDamageModerate }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageCritical, bizDamageCritical }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsLarge, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageNegligble, bizDamageNeglible }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageNegligble, bizDamageMinor }, rezultMedium, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageNegligble, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageNegligble, bizDamageCritical }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageNegligble, bizDamageCatastrophic }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageModerate, bizDamageNeglible }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageModerate, bizDamageMinor }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageModerate, bizDamageModerate }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageModerate, bizDamageCritical }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageModerate, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageCritical, bizDamageNeglible }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageCritical, bizDamageMinor }, rezultHigh, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageCritical, bizDamageModerate }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageCritical, bizDamageCritical }, rezultExtreme, ref ruleList);
            t2FS.AddRule(new IMemFunc[] { vulnerabilityMax, threatsMax, techDamageCritical, bizDamageCatastrophic }, rezultExtreme, ref ruleList);
        }
    }
}
