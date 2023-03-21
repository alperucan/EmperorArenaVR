using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class QuestGiver : MonoBehaviour
    {
        [SerializeField] private float interactRange;
        
        
        public Quest quest;

        public GameObject questWindow;
        public GameObject questOverWindow;
        public Text titleText;
        public Text descriptionText;
        public Text expText;
        public Text goldText;
        public Player player;
        public List<WaveSpawner> waveSpawners;
        public Text questLogText;
        public Text currentWaveText;
        public void Start()
        {
            player = Player.Instance.GetComponent<Player>();
            
        }

        public void OpenQuestWindow()
        {
            questWindow.SetActive(true);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            expText.text ="Experience Reward: " + quest.expReward.ToString();
            goldText.text = "Gold Reward: " +quest.goldReward.ToString();
            
        }

        public void AcceptQuest()
        {
            Debug.Log("GOREV ACCEPTED");
            waveSpawners[quest.goal.currentWave].gameObject.SetActive(true);
            questWindow.SetActive(false);
            quest.isActive = true;
            player.quest=(quest);
           
            questLogText.gameObject.SetActive(true);
           
            currentWaveText.gameObject.SetActive(true);
        }

        public void OkeyButton()
        {
            questOverWindow.SetActive(false);
            waveSpawners[quest.goal.currentWave].gameObject.SetActive(false);
            questLogText.gameObject.SetActive(false);
            currentWaveText.gameObject.SetActive(false);
        }
        void Update()
        {
            
            if (Vector3.Distance(player.transform.position, this.transform.position) <= interactRange)
            {
                this.transform.LookAt(player.transform.position);
                if (!quest.isActive)
                {
                    OpenQuestWindow();
                }
                
            }

            if (quest.isActive)
            {
                currentWaveText.text = "Wave "+(quest.goal.currentWave + 1).ToString() ;
                questLogText.text = "Quest Title: " + quest.title + "\n" +"Enemies Left: " + quest.goal.currentAmount +" / " +quest.goal.requiredAmount;
                if (quest.goal.isReached())
                {
                    Debug.Log("isReached " + player.quest.goal.isReached());
                    
                    quest.goal.currentAmount = 0;
                    quest.goal.requiredAmount *= 2;

                    quest.goal.currentWave++;
              
                    
                }

                if (quest.goal.isWaveReached())
                {
                    questOverWindow.SetActive(true);
                    quest.isActive = false;
                }
                
            }
            
        }
    }
