using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailSelectableItem : SelectableItem
{
	[SerializeField] private MailItem item;
	[SerializeField] private TextMeshProUGUI sender;
	[SerializeField] private TextMeshProUGUI topic;
	[SerializeField] private Image selectedImage;
	[SerializeField] private Color textSelectedColor = Color.white;
	[SerializeField] private Color textNotSelectedColor = Color.black;

	public void Start()
	{
		if(!item) return;
		sender.text = item.Name;
		topic.text = item.Subject;
	}

	public override void Select()
	{
		base.Select();
		SetTextColor(textSelectedColor);
		selectedImage.gameObject.SetActive(true);
	}

	public override void DeSelect()
	{
		base.DeSelect();
		SetTextColor(textNotSelectedColor);
		selectedImage.gameObject.SetActive(false);
	}

	public override void DoubleClicked()
	{
		base.DoubleClicked();
		Debug.Log("Double clicked");
	}

	private void SetTextColor(Color color)
	{
		sender.color = color;
		topic.color = color;
	}
}
