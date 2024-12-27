namespace poznaemwpf;
using System;
using System.Collections.Generic;
using System.IO;

public static class ID
{
    public static string GenerateId()
    {
        List<string> ids = new List<string>();
        using (StreamReader streamReader = new StreamReader("id.txt"))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                ids.Add(line);
            }
        }
            
        Random random = new Random();
            
            
        var id = random.Next(0, 1000000);
        while (ids.Contains(id.ToString()))
        {
            id = random.Next(0, 1000000);
        }            
            
        return id.ToString();
    }
}