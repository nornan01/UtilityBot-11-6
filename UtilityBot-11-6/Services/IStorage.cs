using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using UtilityBot_11_6.Models;

namespace UtilityBot_11_6.Services
{
    public interface IStorage
    {
        
        Session GetSession(long chatId);
    }
}
