namespace Book_Reading_Event_DAO.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Book_Reading_Event_DAO.BookReadingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Book_Reading_Event_DAO.BookReadingContext context)
        {
            var users = new List<User>
            {
                new User{ UserName = "aakash", UserEmail = "aakash.tyagi@nagarro.com", UserPassword = "Passw0rd@123", UserRole = "A", },
                new User { UserName = "test", UserEmail = "19aakash33@gmail.com", UserPassword = "Passw0rd@123", UserRole = "U", }
            };

            users.ForEach(s=>context.user.AddOrUpdate(p => p.UserEmail, s));
            context.SaveChanges();
            
            var events = new List<Event> {
                new Event
                {
                    EventName = "Gandhi Jayanti", EventDate = DateTime.Parse("2020-02-20"), EventLocation = "Delhi",
                    EventStartTime = "12:00", EventType = 1, EventDuration = 4, EventDescription = "Gandhi Birthday",
                    EventOtherDetails = "Happy bday", UserId = 1, EventActive = 1,
                }
            };

            events.ForEach(s=>context.events.AddOrUpdate(p => p.EventName, s));
            context.SaveChanges();

            var invitations = new List<Invitation> {
                new Invitation{ InvitationActive = 1, EventId = 1, UserId = 2}
            };
            invitations.ForEach(s=>context.invitation.AddOrUpdate(s));
            context.SaveChanges();

            var comment = new List<Comment> {
                new Comment{ UserComment = "Nice Event", UserId = 2, EventId = 1}
            };

            comment.ForEach(s => context.comment.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}