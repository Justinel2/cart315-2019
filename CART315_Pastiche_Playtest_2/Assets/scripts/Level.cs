using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


namespace TMPro.Examples
{

	public class Level : MonoBehaviour
	{
		public enum objectType { TextMeshPro = 0, TextMeshProUGUI = 1 };

		public objectType ObjectType;
		public bool isStatic;

		private TMP_Text m_text;

		private const string k_label = "Serotonin level (ng/mL): <#0080ff>{0}</color>";

		private GameObject receptor;
		private int levelSerotonin;

		void Start()
		{	
			// Find the other game object
			receptor = GameObject.Find("receptor_serotonin");

			// Get a reference to the TMP text component.
			m_text = GetComponent<TextMeshProUGUI>();

			// Set the size of the font.
			m_text.fontSize = 18;

			// Set the text
			m_text.text = "A <#0080ff>simple</color> line of text.";

			// Get the preferred width and height based on the supplied width and height as opposed to the actual size of the current text container.
			Vector2 size = m_text.GetPreferredValues(Mathf.Infinity, Mathf.Infinity);

			// Set the size of the RectTransform based on the new calculated values.
			m_text.rectTransform.sizeDelta = new Vector2(size.x, size.y);

		}


		void Update()
		{
			if (!isStatic)
			{
				// Get the current score
				levelSerotonin = receptor.GetComponent<ReceiveBalls> ().level;
				// Set text
				m_text.SetText(k_label, levelSerotonin);
			}
		}

	}
}