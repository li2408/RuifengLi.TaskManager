using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.ServiceInterfaces
{
    public interface ICryptoService
    {
        //one method to create a salt, and another method to hash the password+salt
        //these are independent methods
        string CreateSalt();
        string HashPassword(string password, string salt);
    }
}
