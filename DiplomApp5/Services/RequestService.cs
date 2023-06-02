using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomApp5.Models;

namespace DiplomApp5.Services
{
    public class RequestService
    {
        private readonly ApplicationContext _context;

        public RequestService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Request> GetRequests()
        {
            return _context.Requests.ToList();
        }

        public Request GetRequest(int id)
        {
            return _context.Requests.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteRequest(int id)
        {
            Request request = GetRequest(id);
            _context.Requests.Remove(request);
            _context.SaveChanges();
        }

        public void UpdateRequest(Request request)
        {
            _context.Requests.Update(request);
            _context.SaveChanges();
        }

        public void AddRequest(Request request)
        {
            _context.Requests.Add(request);
            request.StatusId = 1;
            _context.SaveChanges();
        }
    }
}
