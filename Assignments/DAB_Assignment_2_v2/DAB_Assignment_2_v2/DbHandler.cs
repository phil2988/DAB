using DAB_Assignment_2_v2.Architecture;
using DAB_Assignment_2_v2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAB_Assignment_2_v2
{
    public class DbHandler
    {
        private readonly DatabaseContext dbContext;
        public DbHandler(DatabaseContext context)
        {
            this.dbContext = context;
        }

        public void SeedData()
        {
            dbContext.Database.EnsureCreated();
            try
            {
                dbContext.Key.RemoveRange(dbContext.Key);
                dbContext.Member.RemoveRange(dbContext.Member);
                dbContext.Municipality.RemoveRange(dbContext.Municipality);
                dbContext.RoomBooking.RemoveRange(dbContext.RoomBooking);
                dbContext.RoomProperties.RemoveRange(dbContext.RoomProperties);
                dbContext.Room.RemoveRange(dbContext.Room);
                dbContext.Activity.RemoveRange(dbContext.Activity);
                dbContext.Society.RemoveRange(dbContext.Society);
            }
            catch { }

            #region Data

            #region Member

            dbContext.Member.AddRange(
                new Member
                {
                    Name = "Devon L. Dixon",
                    Address = "1316 School Street",
                    Cpr = "2969192632",
                    IsChairman = true,
                    PhoneNumber = "51485238",
                    PassportNumber = "845123697",
                },
                new Member
                {
                    Name = "Carol J. Duerr",
                    Address = "1054 Chapel Street",
                    Cpr = "4681254972",
                    IsChairman = false,
                    PhoneNumber = "",
                    PassportNumber = ""
                },
                new Member
                {
                    Name = "Brian B. Brooks",
                    Address = "2361 Randolph Street",
                    Cpr = "8553214958",
                    IsChairman = true,
                    PhoneNumber = "8526491883",
                    PassportNumber = "888415275",

                },
                new Member
                {
                    Name = "Dot S. Martinez",
                    Address = "590 Wolf Pen Road",
                    Cpr = "7415286593",
                    IsChairman = false,
                    PhoneNumber = "",
                    PassportNumber = ""
                },
                new Member
                {
                    Name = "Michal C. Hale",
                    Address = "4801 Walnut Street",
                    Cpr = "8547185963",
                    IsChairman = false,
                    PhoneNumber = "",
                    PassportNumber = ""
                },
                new Member
                {
                    Name = "Thomas C. Montano",
                    Address = "2199 Pineview Drive",
                    Cpr = "9964885712",
                    IsChairman = false,
                    PhoneNumber = "",
                    PassportNumber = ""
                },
                new Member
                {
                    Name = "Roy C. Contreras",
                    Address = "1257 Oak Lane",
                    Cpr = "8844842659",
                    IsChairman = false,
                    PhoneNumber = "",
                    PassportNumber = ""
                }
            );

            dbContext.SaveChanges();

            #endregion Member

            #region Activity
            dbContext.Activity.AddRange(
                new Activity { AcitivtyName = "Football" },
                new Activity { AcitivtyName = "Golf" },
                new Activity { AcitivtyName = "Chess" }
            );
            dbContext.SaveChanges();

            #endregion Activity

            #region Municipality 

            dbContext.Municipality.AddRange(
                new Municipality
                {
                    Societies = dbContext.Society.ToList()
                }
            );
            dbContext.SaveChanges();

            #endregion Municipality

            #region Society

            dbContext.Society.AddRange(
                new Society {
                    
                    Cvr = 11111111,
                    Address = "Manchester alé 231",
                    ActivityId = dbContext.Activity
                        .FirstOrDefault(e => e.AcitivtyName == "Football")
                        .ActivityId,
                    ChairmanName = "Devon L. Dixon",
                    //MunicipalityId = dbContext.Municipality.First().MunicipalityId
                },
                new Society
                {
                    Cvr = 22222222,
                    Address = "Washington Street 11",
                    ActivityId = dbContext.Activity
                        .FirstOrDefault(e => e.AcitivtyName == "Football")
                        .ActivityId,
                    ChairmanName = "Brian B. Brooks",
                    //MunicipalityId = dbContext.Municipality.First().MunicipalityId
                },
                new Society
                {
                    Cvr = 33333333,
                    Address = "No Creativity street 69",
                    ActivityId = dbContext.Activity
                        .FirstOrDefault(e => e.AcitivtyName == "Chess")
                        .ActivityId,
                    //MunicipalityId = dbContext.Municipality.First().MunicipalityId
                });

            dbContext.SaveChanges();

            #endregion Society

            #region SMR 

            dbContext.SocietyMemberRelations.AddRange(
                new SocietyMemberRelations{
                    MemberId = dbContext.Member.FirstOrDefault(m => m.Name == "Devon L. Dixon").MemberId,
                    SocietyId = dbContext.Society.FirstOrDefault(s => s.Cvr == 11111111).SocietyId
                },
                new SocietyMemberRelations{
                    MemberId = dbContext.Member.FirstOrDefault(m => m.Name == "Brian B. Brooks").MemberId,
                    SocietyId = dbContext.Society.FirstOrDefault(s => s.Cvr == 22222222).SocietyId
                }
            );

            dbContext.SaveChanges();

            #endregion SMR

            #region RoomBooking

            dbContext.RoomBooking.AddRange(
                new RoomBooking
                {
                    BookedBy = dbContext.Member.FirstOrDefault(e => e.Name == "Devon L. Dixon"),
                    BookingStart = new DateTime(2021, 11, 15, 9, 30, 0),
                    BookingEnd = new DateTime(2021, 11, 15, 12, 0, 0),
                },
                new RoomBooking
                {
                    BookedBy = dbContext.Member.FirstOrDefault(e => e.Name == "Devon L. Dixon"),
                    BookingStart = new DateTime(2021, 11, 19, 9, 30, 0),
                    BookingEnd = new DateTime(2021, 11, 19, 12, 0, 0)
                },
                new RoomBooking
                {
                    BookedBy = dbContext.Member.FirstOrDefault(e => e.Name == "Devon L. Dixon"),
                    BookingStart = new DateTime(2021, 11, 23, 9, 30, 0),
                    BookingEnd = new DateTime(2021, 11, 23, 12, 0, 0)
                },
                new RoomBooking
                {
                    BookedBy = dbContext.Member.FirstOrDefault(e => e.Name == "Brian B. Brooks"),
                    BookingStart = new DateTime(2021, 11, 23, 9, 30, 0),
                    BookingEnd = new DateTime(2021, 11, 23, 12, 0, 0)
                },
                new RoomBooking
                {
                    BookedBy = dbContext.Member.FirstOrDefault(e => e.Name == "Brian B. Brooks"),
                    BookingStart = new DateTime(2021, 11, 17, 13, 0, 0),
                    BookingEnd = new DateTime(2021, 11, 17, 16, 0, 0)
                }
            );
            dbContext.SaveChanges();

            #endregion RoomBooking

            #region Room

            dbContext.Room.AddRange(
                new Room
                {
                    RoomKey = 1,
                    RoomAdress = "4142 Boggess Street",
                    RoomAvailabilityStart = new TimeSpan(8, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(16, 0, 0),
                    BookingIds = dbContext.RoomBooking.Where(b => b.BookedBy.Name == "Devon L. Dixon").ToList()
                },
                new Room
                {
                    RoomKey = 2,
                    RoomAdress = "4142 Boggess Street",
                    RoomAvailabilityStart = new TimeSpan(8, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(16, 0, 0)
                },
                new Room
                {
                    RoomKey = 3,
                    RoomAdress = "4142 Boggess Street",
                    RoomAvailabilityStart = new TimeSpan(8, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(16, 0, 0)
                },
                new Room
                {
                    RoomKey = 1,
                    RoomAdress = "844 Crummit Lane",
                    RoomAvailabilityStart = new TimeSpan(10, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(16, 0, 0)
                },
                new Room
                {
                    RoomKey = 2,
                    RoomAdress = "844 Crummit Lane",
                    RoomAvailabilityStart = new TimeSpan(10, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(16, 0, 0),
                    BookingIds = dbContext.RoomBooking.Where(b => b.BookedBy.Name == "Brian B. Brooks").ToList()
                },
                new Room
                {
                    RoomKey = 1,
                    RoomAdress = "368 Straford Park",
                    RoomAvailabilityStart = new TimeSpan(10, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(12, 0, 0)
                }
            );
            dbContext.SaveChanges();

            #endregion Room

            #region Key

            dbContext.AddRange(
                new Key
                {
                    RoomKey = 2,
                    RoomAdress = "844 Crummit Lane"
                },
                new Key
                {
                    RoomKey = 1,
                    RoomAdress = "4142 Boggess Street"
                },
                new Key
                {
                    RoomKey = 2,
                    RoomAdress = "4142 Boggess Street"
                },
                new Key
                {
                    RoomKey = 3,
                    RoomAdress = "4142 Boggess Street"
                }
            );
            dbContext.SaveChanges();

            dbContext.Member.FirstOrDefault(m => m.Name == "Devon L. Dixon").KeyId = dbContext.Key.FirstOrDefault(k => k.RoomAdress == "4142 Boggess Street" && k.RoomKey == 1).KeyId;
            dbContext.Member.FirstOrDefault(m => m.Name == "Devon L. Dixon").KeyId = dbContext.Key.FirstOrDefault(k => k.RoomAdress == "4142 Boggess Street" && k.RoomKey == 2).KeyId;
            dbContext.Member.FirstOrDefault(m => m.Name == "Devon L. Dixon").KeyId = dbContext.Key.FirstOrDefault(k => k.RoomAdress == "4142 Boggess Street" && k.RoomKey == 3).KeyId;


            #endregion Key

            #endregion Data
        }
    }
}
