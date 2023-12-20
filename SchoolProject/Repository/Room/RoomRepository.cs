using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext _myDbContext;

        public RoomRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Create(Room room)
        {
            _myDbContext.Rooms.Add(room);
            _myDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = (from roomObj in _myDbContext.Rooms
                               where roomObj.RoomId == id
                               select roomObj).FirstOrDefault();
            _myDbContext.Rooms.Remove(room);
            _myDbContext.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = (from roomObj in _myDbContext.Rooms
                                      select roomObj).ToList();
            return rooms;
        }
    }
}
