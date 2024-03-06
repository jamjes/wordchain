using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class PlayerResponseTracker
{
    private string appendFile;
    private string allWordsFile;

    public PlayerResponseTracker()
    {
        appendFile = Application.dataPath + "/responses.txt";
        allWordsFile = Application.dataPath + "/allWords.txt";
    }

    public void AppendResponse(string response)
    {
        if (!File.Exists(appendFile))
        {
            File.WriteAllText(path: appendFile, contents: response + "\n");
        }
        else
        {
            using (var writer = new StreamWriter(appendFile, append:true))
            {
                writer.WriteLine(response);
            }
        }
    }

    public bool IsRepeat(string target)
    {
        var hashSet = File.ReadAllLines(appendFile).ToHashSet();

        if (hashSet.Contains(target))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsRealWord(string target)
    {
        var hashSet = File.ReadAllLines(allWordsFile).ToHashSet();

        if (hashSet.Contains(target))
        {
            return true;
        }

        return false;
    }
}
