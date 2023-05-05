using ConcertApp.Business.Concerts.Handlers;
using ConcertApp.Business.Concerts.Queries;
using ConcertApp.Data;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using ConcertApp.Data.Models.Users;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System.Text.Json;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Tests.Business.Users.Handlers
{
    [TestFixture]
    public class GetUpcomingConcertsQueryHandlerTests
    {
        private Mock<ConcertAppContext> _context;
        private GetUpcomingConcertsQueryHandler _handler;
        private GetUpcomingConcertsQuery _request;

        [SetUp]
        public void Init()
        {
            _context = new Mock<ConcertAppContext>();
            _handler = new GetUpcomingConcertsQueryHandler(_context.Object);

            CreateRequest();
            SetupContext();
        }

        [TearDown]
        public void Clean()
        {
            _context = null;
            _handler = null;
        }

        [Test]
        public Task WhenEmailNotFound_ShouldReturnError()
        {
            _request.Email = "dudeeee@gmail.com";
            var expectedResult = JsonSerializer.Serialize(new
            {
                ErrorCode = (int)ErrorCodes.User_AccountNotFound,
                Message = UserErrors.NotFound
            });
            Func<Task> action = async () => await _handler.Handle(_request, new CancellationToken());
            CustomException ex = Assert.ThrowsAsync<CustomException>(async () => await action());

            Assert.AreEqual(ex.Message, expectedResult);
            return Task.CompletedTask;
        }

        private void SetupContext()
        {
            var appConcerts = new List<Concert>
            {
                new Concert
                {
                    Id = 1,
                    Capacity = 1,
                    Description = "Test",
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(10),
                    Genre = MusicGenre.Rock,
                    Location = "somewhere",
                    Name = "Test",
                    UserConcerts = new List<UserConcert>
                    {
                        new UserConcert
                        {
                            Id = 1,
                            ConcertId = 1,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                            User = new User
                            {
                                Id = 1,
                                Email = "hehe@gmail.com"
                            }
                        }
                    }

                },
                new Concert
                {
                    Id = 2,
                    Capacity = 0,
                    Description = "Test",
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(10),
                    Genre = MusicGenre.HeavyMetal,
                    Location = "somewhere",
                    Name = "Test",
                    UserConcerts = new List<UserConcert>
                    {
                        new UserConcert
                        {
                            Id = 2,
                            ConcertId = 2,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                            User = new User
                            {
                                Id = 1,
                                Email = "hehe@gmail.com"
                            }
                        }
                    }
                },
                new Concert
                {
                    Id = 3,
                    Capacity = 5,
                    Description = "Test",
                    StartDate = DateTime.UtcNow.AddDays(-50),
                    EndDate = DateTime.UtcNow.AddDays(-10),
                    Genre = MusicGenre.Rock,
                    Location = "somewhere",
                    Name = "Test",
                    UserConcerts = new List<UserConcert>
                    {
                        new UserConcert
                        {
                            Id = 3,
                            ConcertId = 3,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                            User = new User
                            {
                                Id = 1,
                                Email = "hehe@gmail.com"
                            }
                        }
                    }
                },
                new Concert
                {
                    Id = 4,
                    Capacity = 50,
                    Description = "Test",
                    StartDate = DateTime.UtcNow.AddDays(50),
                    EndDate = DateTime.UtcNow.AddDays(100),
                    Genre = MusicGenre.Indie,
                    Location = "somewhere",
                    Name = "Test",
                    UserConcerts = new List<UserConcert>
                    {
                        new UserConcert
                        {
                            Id = 4,
                            ConcertId = 4,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                            User = new User
                            {
                                Id = 1,
                                Email = "hehe@gmail.com"
                            }
                        },
                        new UserConcert
                        {
                            Id = 5,
                            ConcertId = 4,
                            UserId = 2,
                            UserStatus = UserStatus.Participant,
                            User = new User
                            {
                                Id = 2,
                                Email = "guy@gmail.com"
                            }
                        }
                    }
                }
            };

            var appUserConcerts = new List<UserConcert>
            {
                new UserConcert
                {
                    Id = 1,
                    ConcertId = 1,
                    UserId = 1,
                    UserStatus = UserStatus.Organizer,
                },
                new UserConcert
                {
                    Id = 2,
                    ConcertId = 2,
                    UserId = 1,
                    UserStatus = UserStatus.Organizer,
                },
                new UserConcert
                {
                    Id = 3,
                    ConcertId = 3,
                    UserId = 1,
                    UserStatus = UserStatus.Organizer,
                },
                new UserConcert
                {
                    Id = 4,
                    ConcertId = 4,
                    UserId = 1,
                    UserStatus = UserStatus.Organizer,
                },
                new UserConcert
                {
                    Id = 5,
                    ConcertId = 4,
                    UserId = 2,
                    UserStatus = UserStatus.Participant
                }
            };

            var applicationUsersDetails = new List<UserDetail>
            {
                new UserDetail
                {
                    Id = 1,
                    FirstName = "Hehe",
                    LastName = "LastHehe",
                    PhoneNumber = "1234567890"
                },
                new UserDetail
                {
                    Id = 2,
                    FirstName = "Guy",
                    LastName = "LastGuyOnEarth",
                    PhoneNumber = "5553332221"
                }
            };

            var applicationUsers = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "hehe@gmail.com",
                    Password = "123",
                    UserConcerts = new List<UserConcert>
                    {
                         new UserConcert
                        {
                            Id = 1,
                            ConcertId = 1,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                        },
                        new UserConcert
                        {
                            Id = 2,
                            ConcertId = 2,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                        },
                        new UserConcert
                        {
                            Id = 3,
                            ConcertId = 3,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                        },
                        new UserConcert
                        {
                            Id = 4,
                            ConcertId = 4,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                        },
                    },
                    Detail = new UserDetail
                    {
                        Id = 1,
                        FirstName = "Hehe",
                        LastName = "LastHehe",
                        PhoneNumber = "1234567890"
                    }
                },
                new User
                {
                    Id = 2,
                    Email = "guy@gmail.com",
                    Password = "123",
                    UserConcerts = new List<UserConcert>
                    {
                        new UserConcert
                        {
                            Id = 5,
                            ConcertId = 4,
                            UserId = 2,
                            UserStatus = UserStatus.Participant
                        }
                    },
                    Detail = new UserDetail
                    {
                    Id = 2,
                    FirstName = "Guy",
                    LastName = "LastGuyOnEarth",
                    PhoneNumber = "5553332221"
                    }
                }
            };

            _context.Setup(c => c.Concerts).ReturnsDbSet(appConcerts);
            _context.Setup(c => c.Users).ReturnsDbSet(applicationUsers);
            _context.Setup(c => c.UsersDetails).ReturnsDbSet(applicationUsersDetails);
            _context.Setup(c => c.UserConcerts).ReturnsDbSet(appUserConcerts);
        }

        private void CreateRequest()
        {
            _request = new GetUpcomingConcertsQuery
            {
                Email = "guy@gmail.com",
                CurrentDate = DateTime.UtcNow.AddDays(47)
            };
        }
    }
}
