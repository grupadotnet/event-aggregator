﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Aggregator
{
     public static class Hashing
{
    public static string Hash(string value)
    {
        return Convert.ToBase64String(
            System.Security.Cryptography.SHA256.Create()
            .ComputeHash(Encoding.UTF8.GetBytes(value))
            );
    }

}
}
