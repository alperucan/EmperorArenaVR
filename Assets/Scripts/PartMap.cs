  using System;
  using System.Collections;
  using System.Collections.Generic;
    [Serializable]
  public class PartMap : IEnumerable
  {
      public List<PartList> partLists;

      public PartList this[PartType type]
      {
          get => partLists.Find(part => part.type == type);
          set
          {
              int index = partLists.FindIndex(part => part.type == type);
              if (index == -1)
                  partLists[index] = value;
              else
              {
                  partLists.Add(value);
              }
          }
      }

      public IEnumerator GetEnumerator()
      {
          return partLists.GetEnumerator();
      }
  }
  
