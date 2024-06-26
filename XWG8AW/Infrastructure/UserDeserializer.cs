﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using XWG8AW.Domain;

namespace XWG8AW.Infrastructure
{
    internal class UserDeserializer
    {
        public async Task<List<User>> UserDeserializeFromJson()
        {
            int debugFolderLength = 16;
            string fullpath = Environment.CurrentDirectory;
            string path = fullpath.Substring(0, fullpath.Length - debugFolderLength);
            string correctPath = string.Concat(path, "playersScores.json");

            try
            {
                using (var stream = File.OpenRead(correctPath))
                {

                    List<UserJson>? users = await JsonSerializer.DeserializeAsync<List<UserJson>>(stream, new JsonSerializerOptions
                    {
                        NumberHandling = JsonNumberHandling.AllowReadingFromString

                    });
                    if (users is null)
                    {
                        Console.WriteLine("Deszerializacios hiba");
                        return null;
                    }
                    /*foreach (var user in users)
                    {
                        Console.WriteLine(user);
                    }*/

                    List<User> allUser = new List<User>();

                    foreach (UserJson userJson in users)
                    {
                        allUser.Add(new User(userJson.UserName, userJson.Score));
                    }

                    return allUser;
                }

            }
            catch (Exception ex)
            {

                if (ex is IOException)
                {
                    Console.WriteLine("A playersScores.json fajl nem talalhato!\n");
                    return null;
                }
                else if (ex is JsonException)
                {
                    Console.WriteLine("Hiba a jatekosok beolvasasa soran!\nRossz JSON formatum!\n");
                    return null;
                }
                else
                {
                    Console.WriteLine("Ismeretlen hiba a kerdesek beolvasasa soran!\n");
                    return null;
                }
            }
        }
    }
}
