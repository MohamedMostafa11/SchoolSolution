using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRooms();
        public void Create(Room teacher);

        public void Delete(int id);
    }
}
