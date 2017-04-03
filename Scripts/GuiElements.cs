using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiBar {

	public float max_value;
	public float current_value;

	Image fill = null;
	Text text = null;

	public GuiBar(Image fill, Text text, float max_value){
		this.fill = fill;
		this.text = text;
		this.max_value = max_value;
		this.current_value = max_value;
	}

	public GuiBar(Image fill, Text text, float max_value, float current_value){
		this.fill = fill;
		this.text = text;
		this.max_value = max_value;
		this.current_value = current_value;
	}

	public static GuiBar operator + (GuiBar bar, float amount){

		bar.current_value += amount;

		bar.current_value = Mathf.Clamp
			(bar.current_value, 0, bar.max_value);
		
		bar.fill.fillAmount = bar.current_value / bar.max_value;

		bar.text.text = bar.current_value + " / " + bar.max_value;

		return bar;
	}

	public static GuiBar operator - (GuiBar bar, float amount){
		return bar +(-amount);
	}
}
