﻿using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using MoonSharp.Interpreter.REPL;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LuaConsole : MonoBehaviour
{
	public InputField inputField;
	public GameObject chatPanel, textObject;
	public Scrollbar verticleScrollBar;
	public GameObject panel;
	Script script;
	List<string> prevCommands;
	int prevCommandsIter;
	List<string> helpMessageList = new List<string>();
	List<Message> messageList = new List<Message>();
	Color errColor = new Color(255 / 255f, 20 / 255f, 147 / 255f);

	// Use this for initialization
	void Start()
	{
		setUpScript();
		// invoke all object's start function
		//foreach (var obj in (script.Globals["gameObjects"] as Table).Values)
		//{
		//	var foo = obj.Table["start"];
		//	if (foo != null)
		//		script.Call(foo);
		//}
		panel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		handleCommand();
		//(script.Globals["timer"] as Table)["deltaTime"] = DynValue.NewNumber(Time.deltaTime);
		//foreach (var obj in (script.Globals["gameObjects"] as Table).Values)
		//{
		//	if (obj.IsNil())
		//		continue;
		//	script.Call(obj.Table["upDate"]);
		//}
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			panel.SetActive(!panel.activeInHierarchy);
		}
	}

	void setUpScript()
	{
		prevCommands = new List<string>();
		prevCommandsIter = 0;

		script = new Script();
		script.Options.DebugPrint = s => printMessage(s);
		script.Globals["gameObjects"] = DynValue.NewTable(script);
		script.Options.ScriptLoader = new ReplInterpreterScriptLoader();
		setUpScriptConstant();
		setUpScriptFunc();
	}

	void setUpScriptFunc()
	{
		script.Globals["keyPress"] = (Func<int, bool>)((kcode) =>
		{
			if (panel.activeInHierarchy)
				return false;
			if (Input.GetKey((KeyCode)kcode))
				return true;
			return false;
		});
	}

	void setUpScriptConstant()
	{
		script.Globals["KeyCode"] = new Table(script);
		foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			(script.Globals["KeyCode"] as Table).Set(kcode.ToString(), DynValue.NewNumber((int)kcode));
		}
	}
	/// <summary>
	/// using script to do lua file
	/// </summary>
	/// <param name="path">path to lua file</param>
	void doFile(string path)
	{
		printMessage("ℒ Loading " + path);
		try
		{
			script.DoFile(path);
		}
		catch (InterpreterException luaExcept)
		{
			printMessage("LUA ERROR: " + luaExcept.Message, errColor);
		}
		catch (Exception exception)
		{
			printMessage("C# ERROR: " + exception, errColor);
		}
		printMessage("ℒ Loading finish.");
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="path">path to Mod folder</param>
	void loadMod(string path)
	{
		script.Options.ScriptLoader = new ReplInterpreterScriptLoader();
		((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new string[]
		{
			path + "/?",
			path + "/?.lua",
		};
		printMessage("ℒ Loading " + path);
		try
		{
			script.DoFile(path + "/control.lua");
		}
		catch (InterpreterException luaExcept)
		{
			printMessage("LUA ERROR: " + luaExcept.Message, errColor);
		}
		catch (Exception exception)
		{
			printMessage("C# ERROR: " + exception, errColor);
		}
		printMessage("ℒ Loading finish.");
	}

	/// <summary>
	/// decode macro in path which is from lua code
	/// </summary>
	/// <param name="path">path to be decode</param>
	/// <returns></returns>
	string deMacroPath(string path)
	{
		string[] subStrings = path.Split('/');
		string newPath = new string(new char[] { });
		/// find pattern __<folder-name>__ and replace it with absolute path
		/// it works a bit like macro in C
		Match m = Regex.Match(subStrings[0], "__[^_]+__");
		if (m.Length > 0)
			newPath += Application.streamingAssetsPath + "/scripts/" + m.Groups[0].ToString().Split('_')[2];
		else
			newPath += subStrings[0];
		for (int i = 1; i < subStrings.Length; ++i)
		{
			newPath += "/" + subStrings[i];
		}
		return newPath;
	}

	void handleCommand()
	{
		if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
		{
			if (inputField.text != "")
			{
				prevCommands.Add(inputField.text);
				prevCommandsIter = prevCommands.Count;
			}

			if (inputField.text == "clear") // magic words
			{
				while (messageList.Count > 0)
				{
					Destroy(messageList[0].textObject.gameObject);
					messageList.Remove(messageList[0]);
				}
			}
			else if (inputField.text == "help")
			{
				printMessage("> help");
				foreach (string msg in helpMessageList)
				{
					printMessage(msg, Color.yellow);
				}
			}
			else // execute lua
			{
				printMessage("> " + inputField.text);
				try
				{
					script.DoString(inputField.text);
				}
				catch (Exception err)
				{
					printMessage("Error: " + err.Message, errColor);
				}
			}
			inputField.text = "";
			inputField.ActivateInputField();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (prevCommands.Count == 0)
				return;
			inputField.text = prevCommands[prevCommandsIter == 0 ? 0 : --prevCommandsIter];
			inputField.selectionAnchorPosition = inputField.text.Length;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (prevCommands.Count == 0)
				return;
			inputField.text = ++prevCommandsIter >= prevCommands.Count ? "" : prevCommands[prevCommandsIter];
			inputField.selectionAnchorPosition = inputField.text.Length;
		}
	}
	/// <summary>
	/// print message to lua console
	/// </summary>
	/// <param name="msg">message to print</param>
	void printMessage(string msg)
	{
		Message newMessage = new Message(msg);
		GameObject newText = Instantiate(textObject, chatPanel.transform);
		newMessage.textObject = newText.GetComponent<Text>();
		newMessage.textObject.text = newMessage.text;
		messageList.Add(newMessage);
		verticleScrollBar.value = 0f;
		Debug.Log(newMessage.textObject.rectTransform.sizeDelta.x);
	}
	/// <summary>
	/// print message to lua console
	/// </summary>
	/// <param name="msg">message to print</param>
	/// <param name="color">color of message</param>
	void printMessage(string msg, Color color)
	{
		Message newMessage = new Message(msg);
		GameObject newText = Instantiate(textObject, chatPanel.transform);
		newMessage.textObject = newText.GetComponent<Text>();
		newMessage.textObject.text = newMessage.text;
		newMessage.textObject.color = color;
		messageList.Add(newMessage);
		verticleScrollBar.value = 0f;
	}
}

public class Message
{
	public Message()
	{
	}
	public Message(string text)
	{
		this.text = text;
	}
	public string text;
	public Text textObject;
}