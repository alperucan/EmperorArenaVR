﻿using System;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class CharacterSelectionUI : BaseUI
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
        
        [SerializeField] private ModularCharacterController modularCharacterController;
        [SerializeField] private Stats stats;
        [SerializeField] private List<TextMeshProUGUI> statLabelTexts;
        [SerializeField] private List<TextMeshProUGUI> statValueTexts;
        [SerializeField] private TextMeshProUGUI hairText;
        [SerializeField] private TextMeshProUGUI faceText;
        [SerializeField] private TextMeshProUGUI facialHairText;
        
        [SerializeField] private Button prevFaceButton;
        [SerializeField] private Button nextFaceButton;
        [SerializeField] private Button prevHairButton;
        [SerializeField] private Button nextHairButton;
        [SerializeField] private Button prevFacialHairButton;
        [SerializeField] private Button nextFacialHairButton;
        
        [SerializeField] private Button maleButton;
        [SerializeField] private Button femaleButton;
        
        [SerializeField] private Transform facialHairParent;
        
        [SerializeField] private Button blackHairButton;
        [SerializeField] private Button blondHairButton;
        [SerializeField] private Button redHairButton;
        [SerializeField] private Button brownHairButton;
        
        [SerializeField] private Button paleSkinButton;
        [SerializeField] private Button lightSkinButton;
        [SerializeField] private Button tannedSkinButton;
        [SerializeField] private Button darkSkinButton;

        [SerializeField] private Button randomStatsButton;
        [SerializeField] private Button acceptButton;
        [SerializeField] private GameObject mirror;
        
        
        private int hairId;

        public int HairId
        {
            get { return this.hairId; }
            set
            {
                hairId = value;
                if(modularCharacterController.activeParts[PartType.Hair].id !=-1)
                    modularCharacterController.DeactivatePart(PartType.Hair,modularCharacterController.activeParts[PartType.Hair].id);
                modularCharacterController.ActivatePart(PartType.Hair, hairId);
                hairText.text = $"Hair {hairId}";
            }
        }

        private int faceId;
        public int FaceId
        {
            get { return this.faceId; }
            set
            {
                faceId = value;
                modularCharacterController.DeactivatePart(PartType.Head,modularCharacterController.activeParts[PartType.Head].id);
                modularCharacterController.ActivatePart(PartType.Head,faceId);
                faceText.text = $"Face {faceId}";
            }
        }

        private int facialHairId;

        public int FacialHairId
        {
            get { return this.facialHairId; }
            set
            {
                facialHairId = value;
                modularCharacterController.DeactivatePart(PartType.FacialHair,modularCharacterController.activeParts[PartType.FacialHair].id);
                modularCharacterController.ActivatePart(PartType.FacialHair, facialHairId);
                facialHairText.text = $"Facial Hair {facialHairId}";
            }
        }

        public override void Show()
        {
            base.Show();
            if (virtualCamera)
                virtualCamera.Priority = 1;
        }
        public override void Hide()
        {
            base.Hide();
            if (virtualCamera)
                virtualCamera.Priority = -1;
        }
        public void Awake()
        {
                base.Awake();
               randomStatsButton.onClick.AddListener(RandomizeStats);
               acceptButton.onClick.AddListener(Accept);
               prevFaceButton.onClick.AddListener(PreviousFace);
               nextFaceButton.onClick.AddListener(NextFace);
               prevHairButton.onClick.AddListener(PreviousHair);
               nextHairButton.onClick.AddListener(NextHair);
               prevFacialHairButton.onClick.AddListener(PreviousFacialHair);
               nextFacialHairButton.onClick.AddListener(NextFacialHair);
               maleButton.onClick.AddListener(delegate { ChangeGender(Gender.Male); });
               femaleButton.onClick.AddListener(delegate { ChangeGender(Gender.Male); });
               blackHairButton.onClick.AddListener(delegate { ChangeHairColor(new Color(0f, 0f, 0f)); });
               blondHairButton.onClick.AddListener(delegate { ChangeHairColor( new Color(139f / 255, 109f / 255, 55f / 255)); });
               brownHairButton.onClick.AddListener(delegate { ChangeHairColor( new Color(63f / 255, 45f / 255, 13f / 255)); });
               redHairButton.onClick.AddListener(delegate { ChangeHairColor(new Color(197f / 255, 87f / 255, 18f / 255)); });
               paleSkinButton.onClick.AddListener(delegate { ChangeSkinColor( new Color(241f / 255, 210f / 255, 192f / 255)); });
               lightSkinButton.onClick.AddListener(delegate { ChangeSkinColor(new Color(1f, 204f / 255, 174f / 255)); });
               tannedSkinButton.onClick.AddListener(delegate { ChangeSkinColor(new Color(180f / 255, 127f / 255, 94f / 255)); });
               darkSkinButton.onClick.AddListener(delegate { ChangeSkinColor(new Color(91f / 255, 50f / 255, 26f / 255)); });
        }
        /// <summary>
        /// TODO Stats duzelince yap
        /// </summary>
        private void Start()
        {
           // RandomizeStats();
        }

        private void NextFace()
        {
            FaceId = modularCharacterController.GetGender() == Gender.Female
                ? (FaceId + 1) % modularCharacterController.femaleParts[PartType.Head].parts.Length
                : (FaceId + 1) % modularCharacterController.maleParts[PartType.Head].parts.Length;
        }

        private void PreviousFace()
        {
            if (FaceId == 0)
            {
                FaceId = modularCharacterController.GetGender()==Gender.Female
                    ? (FaceId + 1) % modularCharacterController.femaleParts[PartType.Head].parts.Length-1
                    : (FaceId + 1) % modularCharacterController.maleParts[PartType.Head].parts.Length-1;
            }
            else
            {
                FaceId--;
            }
        }

        private void PreviousHair()
        {
            HairId = HairId == 0
                ? modularCharacterController.genderNeutralParts[PartType.Hair].parts.Length - 1
                : HairId - 1;
        }

        private void NextHair()
        {
            HairId = (HairId + 1) % modularCharacterController.genderNeutralParts[PartType.Hair].parts.Length;
        }

        private void NextFacialHair()
        {
            FacialHairId = (FacialHairId + 1) % modularCharacterController.maleParts[PartType.FacialHair].parts.Length;
            
        }

        private void PreviousFacialHair()
        {
            FacialHairId = FacialHairId == 0
                ? modularCharacterController.maleParts[PartType.FacialHair].parts.Length - 1
                : FacialHairId - 1;
        }

        private void ChangeGender(Gender gender)
        {
            modularCharacterController.ChangeGender(gender);
            if (gender == Gender.Male)
            {
                facialHairParent.gameObject.SetActive(true);
            }
            else
            {
                facialHairParent.gameObject.SetActive(false);
            }
        }

        private void ChangeHairColor(Color color)
        {
            modularCharacterController.ChangeColor("_Color_Hair",color);
        }
        private void ChangeSkinColor(Color color)
        {
            modularCharacterController.ChangeColor("_Color_Skin",color);
        }
        private void RandomizeStats()
        {
            foreach (var stat in statValueTexts)
            {
                stat.text = "1";
            }

            stats.Initialize();
            while (stats.AvailablePoints>0)
            {
                int index = Random.Range(0, 6);
                int points = Random.Range(1, stats.AvailablePoints);
                stats.SpendPoints(points,statLabelTexts[index].text.ToLower());
                statValueTexts[index].text = $"{stats[statLabelTexts[index].text.ToLower()].BaseValue}";
            }
        }

        private void Accept()
        {
            Hide();
        }
        
    }