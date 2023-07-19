using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Skills {
    public class SkillView : MonoBehaviour {
        [SerializeField] Image BackImage;
        [SerializeField] Color BaseColor;
        [SerializeField] Color LearnedColor;
        [SerializeField] Color SelectedColor;
        [SerializeField] TMP_Text SkillNameText;
        [SerializeField] Button SelectButton;

        Action<int> _onSelectButtonClicked;
        Color _commonColor;

        [field: SerializeField] 
        public int Id { get; private set; }

        public void Init(string skillName, bool isLearned, Action<int> onSelectButtonClicked) {
            _commonColor = isLearned ? LearnedColor : BaseColor;
            BackImage.color = _commonColor;

            SkillNameText.text = skillName;

            _onSelectButtonClicked = onSelectButtonClicked;
            SelectButton.onClick.AddListener(OnSelectButtonClick);
        }

        public void DeInit() {
            _onSelectButtonClicked = null;
            SelectButton.onClick.RemoveListener(OnSelectButtonClick);
        }

        public void ChangeLearned(bool isLearned, bool forceChange) {
            _commonColor = isLearned ? LearnedColor : BaseColor;

            if ( forceChange ) {
                BackImage.color = _commonColor;
            }
        }

        public void ChangeSelect(bool isSelected) {
            BackImage.color = isSelected ? SelectedColor : _commonColor;
        }

        void OnSelectButtonClick() {
            _onSelectButtonClicked?.Invoke(Id);
        }
    }
}