using System;
using System.Collections.Generic;

public static class ExtensionMethods
{
	public static Dictionary<string, object> toHashTable(this ChatMessage cht) {
        Dictionary<string, object> h = new Dictionary<string, object>();
		h.Add("sender",cht.Sender);
		h.Add("text", cht.Text);
		h.Add("readed", cht.Readed);

		return h;
	}

	public static ChatMessage toChatMessage(this Dictionary<string,object> h) {
		return new ChatMessage((string)h["sender"], (string)h["text"], (bool)h["readed"]);
	}

	public static DateTime GetMessageDate(this ChatMessage msg){
        
		string msgDateTime = msg.Text.Substring(0, msg.getDateTextSeparatorIndex() );
        return DateTime.SpecifyKind(DateTime.Parse(msgDateTime), DateTimeKind.Utc);
	}

	public static int getDateTextSeparatorIndex(this ChatMessage cht) {
		return cht.Text.IndexOf('#');
	}

	public static string stringArrayToString(this string[] arr) {
		string result = "[";
		for (int i = 0; i < arr.Length; i++) {
			result += arr[i] + (i == arr.Length-1 ? "]" : ", "); 
		}
		return result;
	}
}
