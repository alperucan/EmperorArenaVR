
    public enum ModifierType
    {
        Flat,
        Percent
        
    }
    public class StatModifier
    {
        public int value;
        public ModifierType type;

        public StatModifier(int value, ModifierType type)
        {
            this.value = value;
            this.type = type;

        }
    }
