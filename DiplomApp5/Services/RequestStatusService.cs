using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomApp5.Models;

namespace DiplomApp5.Services
{
    public class RequestStatusService
    {
        private readonly ApplicationContext _context;

        public RequestStatusService(ApplicationContext context)
        {
            _context = context;
        }
    }
}
