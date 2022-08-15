using System;
using System.IO;

namespace CleanUp.Model;

public static class DateienUndOrdner
{
    public static string OrdnerLoeschen(string ordner)
    {
        var dirInfo = new DirectoryInfo(ordner);
        if (!dirInfo.Exists) return $"exisitiert nicht (mehr): {ordner} \n";

        try
        {
            Directory.Delete(ordner, true);
            return $"gelöscht: {ordner}\n";
        }
        catch (Exception exp)
        {
            return $"{exp}\n";
        }
    }
}