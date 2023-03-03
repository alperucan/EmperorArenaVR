using System;
using UnityEngine;
using UnityEngine.UI;


public class QuestGiver : MonoBehaviour
    {
      
        public Quest quest;

        public GameObject questWindow;
        public Text titleText;
        public Text descriptionText;
        public Text expText;
        public Text goldText;
        public Player player;
    
        public void Start()
        {
            player = Player.Instance.GetComponent<Player>();
        }

        public void OpenQuestWindow()
        {
            questWindow.SetActive(true);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            expText.text = quest.expReward.ToString();
            goldText.text = quest.goldReward.ToString();
            
        }

        public void AcceptQuest()
        {
            questWindow.SetActive(false);
            quest.isActive = true;
            player.questList.Add(quest);
        }
    }
