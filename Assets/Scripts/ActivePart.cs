using System;

[Serializable]
 public class ActivePart
 {
     public PartType type;
    
     //default is when we dont have active part -1
     public int id;

     public ActivePart(PartType type, int id)
     {
         this.type = type;
         this.id = id;
     }
 }
