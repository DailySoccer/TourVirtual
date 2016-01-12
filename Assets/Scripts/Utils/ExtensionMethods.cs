using System;
using System.Collections;
using System.Collections.Generic;

public static class ExtensionMethods
{
	public static Hashtable toHashTable(this ChatMessage cht) {
		Hashtable h = new Hashtable();
		h.Add("sender",cht.Sender);
		h.Add("text", cht.Text);
		h.Add("readed", cht.Readed);

		return h;
	}

	public static ChatMessage toChatMessage(this Hashtable h) {
		return new ChatMessage((string)h["sender"], (string)h["text"], (bool)h["readed"]);
	}

	public static DateTime GetMessageDate(this ChatMessage msg){
        
		string msgDateTime = msg.Text.Substring(0, msg.getDateTextSeparatorIndex() );
        return DateTime.SpecifyKind(DateTime.Parse(msgDateTime), DateTimeKind.Utc);
	}

	public static int getDateTextSeparatorIndex(this ChatMessage cht) {
		return cht.Text.IndexOf('#');
	}
}
