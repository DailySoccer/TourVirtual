using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class RegexExtensions {
	/*
	 * Sustituir el group por una cadena
	 * 
	 * Ejemplo: (source http://stackoverflow.com/questions/6005609/replace-only-some-groups-with-regex)
	 * var input = @"[assembly: AssemblyFileVersion(""2.0.3.0"")][assembly: AssemblyFileVersion(""2.0.3.0"")]";
	 * var regex = new Regex(@"AssemblyFileVersion\(""(?<version>(\d+\.?){4})""\)");
	 * var result = regex.ReplaceGroup(input , "version", "1.2.3");
	*/
	public static string ReplaceGroup(this Regex regex, string input, string groupName, string replacement) {
		return regex.Replace(
			input,
			m => {
				var group = m.Groups[groupName];
				var sb = new StringBuilder();
				var previousCaptureEnd = 0;
				foreach (var capture in group.Captures.Cast<Capture>())	{
					var currentCaptureEnd =	capture.Index + capture.Length - m.Index;
					var currentCaptureLength = capture.Index - m.Index - previousCaptureEnd;
					sb.Append(
						m.Value.Substring(
						previousCaptureEnd, currentCaptureLength));
					sb.Append(replacement);
					previousCaptureEnd = currentCaptureEnd;
				}
				sb.Append(m.Value.Substring(previousCaptureEnd));
				return sb.ToString();
			}
		);
	}
}
