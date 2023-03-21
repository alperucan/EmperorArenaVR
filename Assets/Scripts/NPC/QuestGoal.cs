    using UnityEngine;

    [System.Serializable]
    public class QuestGoal
    {
        public GoalType goalType;
        public int requiredAmount;
        public int currentAmount;

        public int requiredWave = 3;
        public int currentWave = 0;
        public bool isReached()
        {
            return (currentAmount >= requiredAmount);
        }
        public bool isWaveReached()
        {
            return (currentWave >= requiredWave);
        }
       
    }

    public enum GoalType
    {
        Kill,
        Gathering
    }
