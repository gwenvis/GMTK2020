using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mail", menuName = "Assets/Mail Item", order = 100)]
public class MailItem : ScriptableObject
{
	public string Name => name;
	public string Subject => subject;
	public string Message => message;

	[SerializeField] private string name;
	[SerializeField] private string subject;
	[SerializeField, Multiline] private string message;
}
