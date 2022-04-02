using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Subtegral.DialogueSystem.DataContainers;


    public class DialogueParser : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Button choicePrefab;
        [SerializeField] private Button continuePrefab;
        [SerializeField] private Transform buttonContainerChoices;
        [SerializeField] private Transform buttonContainerContinue;

        private void Start()
        {
            //var narrativeData = dialogue.NodeLinks.First(); //Entrypoint node
            
            //ProceedToNarrative(narrativeData.TargetNodeGUID);
        }

        public void ProceedToNarrative(string narrativeDataGUID, DialogueContainer dialogue)
        {
            var text = dialogue.DialogueNodeData.Find(x => x.NodeGUID == narrativeDataGUID).DialogueText;
            dialogueText.text = ProcessProperties(text, dialogue);

            var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGUID == narrativeDataGUID);
            var buttons = buttonContainerChoices.GetComponentsInChildren<Button>();
            var buttons2 = buttonContainerContinue.GetComponentsInChildren<Button>();

            for (int i = 0; i < buttons.Length; i++)
            {
                Destroy(buttons[i].gameObject);
            }
            for (int i = 0; i < buttons2.Length; i++)
            {
                Destroy(buttons2[i].gameObject);
            }

            if(choices.ToArray().Count() <= 1 ){
                //no hay opciones, mostrar el botón next
                foreach (var choice in choices){
                    var button = Instantiate(continuePrefab, buttonContainerContinue);
                    //button.GetComponentInChildren<Text>().text = ProcessProperties(choice.PortName);
                    Debug.Log("on click?");
                    button.onClick.AddListener(() => ProceedToNarrative(choice.TargetNodeGUID, dialogue));
                }
            }

            foreach (var choice in choices)
            {
                //hay varias opciones, mostrar las opciones
                var button = Instantiate(choicePrefab, buttonContainerChoices);
                button.GetComponentInChildren<Text>().text = ProcessProperties(choice.PortName, dialogue);
                button.onClick.AddListener(() => ProceedToNarrative(choice.TargetNodeGUID, dialogue));
            }
        }

        private string ProcessProperties(string text, DialogueContainer dialogue)
        {
            foreach (var exposedProperty in dialogue.ExposedProperties)
            {
                text = text.Replace($"[{exposedProperty.PropertyName}]", exposedProperty.PropertyValue);
            }
            return text;
        }
    }
