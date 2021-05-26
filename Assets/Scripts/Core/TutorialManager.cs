using System;
using DG.Tweening;
using MyBox;
using Rhodos.Mechanics.Bases;
using Rhodos.Toolkit.Extensions;
using Rhodos.UI;
using UnityEngine;

namespace Rhodos.Core
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private TutorialScreen tutorialScreen;

        public void StartTutorial(MechanicBase mechanic)
        {
            if (mechanic.HasATutorialScreen)
            {
                tutorialScreen.OnReset();
                tutorialScreen.Init(mechanic.TutorialArgs);
                tutorialScreen.PlayInAnimation().StartCoroutine();
            }
        }

        public void StopAnimation()
        {
            tutorialScreen.PlayOutAnimation().StartCoroutine().OnComplete(tutorialScreen.OnReset);
        }
    }

    public class TutorialArgs
    {
        public readonly Tween Animation;
        public readonly string Instruction;
        public TutorialArgs(Tween animation, string instruction)
        {
            Animation = animation;
            Instruction = instruction;
        }
    }
}