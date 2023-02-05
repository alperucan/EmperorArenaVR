using System;
using System.Collections.Generic;


    [Serializable]
    public struct StatsData
    {
        public int availablePoints;
        public List<StatData> stats;
        public List<DynamicStatData> dynamicStats;
    }
