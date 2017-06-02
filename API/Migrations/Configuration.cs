using System;
using System.Data.Entity.Migrations;
using API.Domain;
using API.Infrastructure;

namespace API.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<API.Infrastructure.DataContext>
    {
        private readonly Event[] _events;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "API.Infrastructure.DataContext";

            _events = CreateEvents();
        }

        protected override void Seed(DataContext context)
        {
            SeedEvent(context);
            SeedTickets(context);
        }

        private void SeedEvent(DataContext context)
        {
            context.Events.AddRange(_events);
            context.SaveChanges();
        }

        private void SeedTickets(DataContext context)
        {
            context.Tickets.AddRange(new[]
            {
                new Ticket(57, "VIP", 57),
                new Ticket(33, "VIP", 79),
                new Ticket(13, "VIP", 79),
                new Ticket(38, "General Admission", 118),
                new Ticket(88, "VIP", 145),
                new Ticket(19, "VIP", 122),
                new Ticket(32, "VIP", 59),
                new Ticket(53, "VIP", 101),
                new Ticket(11, "VIP", 54),
                new Ticket(43, "VIP", 136),
                new Ticket(37, "General Admission", 66),
                new Ticket(30, "VIP", 65),
                new Ticket(85, "General Admission", 119),
                new Ticket(96, "General Admission", 131),
                new Ticket(48, "VIP", 68),
                new Ticket(57, "VIP", 149),
                new Ticket(91, "General Admission", 122),
                new Ticket(93, "VIP", 63),
                new Ticket(46, "General Admission", 126),
                new Ticket(1, "VIP", 142),
                new Ticket(39, "General Admission", 112),
                new Ticket(93, "General Admission", 101),
                new Ticket(62, "General Admission", 96),
                new Ticket(77, "General Admission", 131),
                new Ticket(65, "General Admission", 106),
                new Ticket(1, "General Admission", 99),
                new Ticket(93, "General Admission", 137),
                new Ticket(73, "General Admission", 59),
                new Ticket(15, "General Admission", 148),
                new Ticket(41, "VIP", 77),
                new Ticket(26, "General Admission", 114),
                new Ticket(38, "General Admission", 80),
                new Ticket(60, "VIP", 128),
                new Ticket(54, "VIP", 109),
                new Ticket(55, "VIP", 63),
                new Ticket(32, "General Admission", 149),
                new Ticket(100, "VIP", 114),
                new Ticket(34, "General Admission", 138),
                new Ticket(74, "General Admission", 112),
                new Ticket(69, "General Admission", 106),
                new Ticket(74, "General Admission", 132),
                new Ticket(79, "VIP", 88),
                new Ticket(93, "VIP", 117),
                new Ticket(74, "General Admission", 141),
                new Ticket(94, "VIP", 132),
                new Ticket(1, "VIP", 77),
                new Ticket(10, "General Admission", 132),
                new Ticket(2, "General Admission", 80),
                new Ticket(43, "General Admission", 73),
                new Ticket(16, "VIP", 96),
                new Ticket(14, "VIP", 82),
                new Ticket(63, "General Admission", 70),
                new Ticket(4, "VIP", 146),
                new Ticket(57, "General Admission", 130),
                new Ticket(56, "VIP", 143),
                new Ticket(2, "VIP", 107),
                new Ticket(98, "VIP", 113),
                new Ticket(70, "VIP", 143),
                new Ticket(24, "General Admission", 95),
                new Ticket(15, "General Admission", 54),
                new Ticket(8, "VIP", 147),
                new Ticket(22, "VIP", 77),
                new Ticket(32, "General Admission", 113),
                new Ticket(81, "General Admission", 127),
                new Ticket(28, "VIP", 88),
                new Ticket(18, "General Admission", 96),
                new Ticket(20, "General Admission", 149),
                new Ticket(23, "General Admission", 50),
                new Ticket(26, "VIP", 87),
                new Ticket(79, "VIP", 106),
                new Ticket(23, "VIP", 114),
                new Ticket(51, "VIP", 88),
                new Ticket(35, "VIP", 92),
                new Ticket(65, "VIP", 94),
                new Ticket(16, "General Admission", 118),
                new Ticket(17, "VIP", 121),
                new Ticket(1, "General Admission", 86),
                new Ticket(2, "General Admission", 118),
                new Ticket(34, "VIP", 64),
                new Ticket(57, "General Admission", 70),
                new Ticket(70, "VIP", 57),
                new Ticket(49, "VIP", 61),
                new Ticket(100, "General Admission", 148),
                new Ticket(83, "VIP", 100),
                new Ticket(48, "VIP", 91),
                new Ticket(96, "VIP", 106),
                new Ticket(37, "VIP", 121),
                new Ticket(32, "VIP", 58),
                new Ticket(60, "VIP", 95),
                new Ticket(93, "General Admission", 54),
                new Ticket(5, "VIP", 62),
                new Ticket(51, "General Admission", 90),
                new Ticket(6, "VIP", 130),
                new Ticket(18, "General Admission", 138),
                new Ticket(57, "General Admission", 50),
                new Ticket(66, "General Admission", 129),
                new Ticket(20, "General Admission", 71),
                new Ticket(42, "VIP", 99),
                new Ticket(97, "VIP", 146),
                new Ticket(72, "VIP", 100)
            }
                );

            context.SaveChanges();
        }

        private static Event[] CreateEvents()
        {
            return new[]
            {
                new Event
                    (
                    "interdum.",
                    DateTime.Parse("2017-05-20T02:50:48-07:00"),
                    DateTime.Parse("2016-08-23T05:20:44-07:00"),
                    DateTime.Parse("2017-12-07T01:33:35-08:00"),
                    DateTime.Parse("2017-04-08T02:49:39-07:00")
                    ),
                new Event
                    (
                    "fermentum",
                    DateTime.Parse("2017-04-06T16:11:37-07:00"),
                    DateTime.Parse("2018-01-18T05:01:31-08:00"),
                    DateTime.Parse("2017-03-27T19:25:58-07:00"),
                    DateTime.Parse("2017-09-13T07:02:08-07:00")
                    ),
                new Event
                    (
                    "interdum libero dui",
                    DateTime.Parse("2017-11-30T09:57:30-08:00"),
                    DateTime.Parse("2017-09-03T09:37:29-07:00"),
                    DateTime.Parse("2018-01-29T10:11:40-08:00"),
                    DateTime.Parse("2017-06-06T03:48:02-07:00")
                    ),
                new Event
                    (
                    "porttitor tellus non",
                    DateTime.Parse("2018-04-25T01:44:57-07:00"),
                    DateTime.Parse("2016-12-03T08:45:29-08:00"),
                    DateTime.Parse("2016-07-17T14:53:23-07:00"),
                    DateTime.Parse("2018-03-15T12:14:21-07:00")
                    ),
                new Event
                    (
                    "ac",
                    DateTime.Parse("2017-07-08T22:47:40-07:00"),
                    DateTime.Parse("2016-07-08T03:33:48-07:00"),
                    DateTime.Parse("2018-04-19T18:31:00-07:00"),
                    DateTime.Parse("2017-07-24T06:57:58-07:00")
                    ),
                new Event
                    (
                    "Cras dictum",
                    DateTime.Parse("2017-06-30T14:42:02-07:00"),
                    DateTime.Parse("2017-02-04T12:42:29-08:00"),
                    DateTime.Parse("2017-02-16T04:01:36-08:00"),
                    DateTime.Parse("2018-03-30T15:20:04-07:00")
                    ),
                new Event
                    (
                    "accumsan",
                    DateTime.Parse("2017-06-20T06:34:38-07:00"),
                    DateTime.Parse("2016-07-01T12:50:20-07:00"),
                    DateTime.Parse("2017-08-12T22:29:10-07:00"),
                    DateTime.Parse("2016-07-14T00:18:23-07:00")
                    ),
                new Event
                    (
                    "enim. Suspendisse aliquet,",
                    DateTime.Parse("2016-11-06T17:29:53-08:00"),
                    DateTime.Parse("2017-09-19T04:42:11-07:00"),
                    DateTime.Parse("2017-01-05T23:27:33-08:00"),
                    DateTime.Parse("2017-05-10T16:40:48-07:00")
                    ),
                new Event
                    (
                    "tempor erat",
                    DateTime.Parse("2016-11-03T04:30:42-07:00"),
                    DateTime.Parse("2018-05-19T02:05:19-07:00"),
                    DateTime.Parse("2017-12-24T17:14:57-08:00"),
                    DateTime.Parse("2017-06-13T13:38:45-07:00")
                    ),
                new Event
                    (
                    "ultricies ligula.",
                    DateTime.Parse("2016-08-24T16:38:21-07:00"),
                    DateTime.Parse("2017-09-26T10:33:44-07:00"),
                    DateTime.Parse("2017-07-30T18:35:13-07:00"),
                    DateTime.Parse("2018-02-19T20:24:12-08:00")
                    ),
                new Event
                    (
                    "orci",
                    DateTime.Parse("2017-06-15T03:33:37-07:00"),
                    DateTime.Parse("2016-07-30T15:00:56-07:00"),
                    DateTime.Parse("2016-08-13T17:10:45-07:00"),
                    DateTime.Parse("2016-06-19T01:35:10-07:00")
                    ),
                new Event
                    (
                    "mauris, rhoncus id,",
                    DateTime.Parse("2017-06-26T19:33:45-07:00"),
                    DateTime.Parse("2016-11-27T20:16:53-08:00"),
                    DateTime.Parse("2016-07-29T08:41:47-07:00"),
                    DateTime.Parse("2018-03-29T08:14:20-07:00")
                    ),
                new Event
                    (
                    "ante,",
                    DateTime.Parse("2017-08-29T20:34:50-07:00"),
                    DateTime.Parse("2016-08-21T20:29:05-07:00"),
                    DateTime.Parse("2017-03-05T08:22:11-08:00"),
                    DateTime.Parse("2017-12-15T11:59:22-08:00")
                    ),
                new Event
                    (
                    "lectus, a",
                    DateTime.Parse("2018-04-09T05:08:27-07:00"),
                    DateTime.Parse("2016-07-16T04:18:41-07:00"),
                    DateTime.Parse("2017-11-11T16:07:04-08:00"),
                    DateTime.Parse("2018-02-15T09:26:01-08:00")
                    ),
                new Event
                    (
                    "orci.",
                    DateTime.Parse("2016-06-13T20:13:58-07:00"),
                    DateTime.Parse("2018-05-13T21:21:57-07:00"),
                    DateTime.Parse("2018-01-03T03:32:03-08:00"),
                    DateTime.Parse("2018-02-21T03:22:31-08:00")
                    ),
                new Event
                    (
                    "sed",
                    DateTime.Parse("2017-06-04T15:19:23-07:00"),
                    DateTime.Parse("2016-06-27T07:56:36-07:00"),
                    DateTime.Parse("2017-08-30T10:46:50-07:00"),
                    DateTime.Parse("2016-10-17T23:09:19-07:00")
                    ),
                new Event
                    (
                    "enim. Nunc",
                    DateTime.Parse("2016-11-12T21:36:53-08:00"),
                    DateTime.Parse("2018-04-05T07:56:21-07:00"),
                    DateTime.Parse("2016-08-29T20:58:15-07:00"),
                    DateTime.Parse("2016-08-22T10:28:53-07:00")
                    ),
                new Event
                    (
                    "quis turpis vitae",
                    DateTime.Parse("2017-07-25T20:05:28-07:00"),
                    DateTime.Parse("2017-09-24T17:27:56-07:00"),
                    DateTime.Parse("2016-06-27T08:49:15-07:00"),
                    DateTime.Parse("2016-06-16T23:17:46-07:00")
                    ),
                new Event
                    (
                    "bibendum ullamcorper. Duis",
                    DateTime.Parse("2017-08-05T14:18:13-07:00"),
                    DateTime.Parse("2018-01-28T04:27:19-08:00"),
                    DateTime.Parse("2016-12-07T10:02:36-08:00"),
                    DateTime.Parse("2018-02-21T06:59:52-08:00")
                    ),
                new Event
                    (
                    "aliquet, sem ut",
                    DateTime.Parse("2016-07-20T15:06:24-07:00"),
                    DateTime.Parse("2016-10-28T10:24:22-07:00"),
                    DateTime.Parse("2016-12-25T05:21:47-08:00"),
                    DateTime.Parse("2017-03-19T07:31:33-07:00")
                    ),
                new Event
                    (
                    "lacus.",
                    DateTime.Parse("2017-01-24T06:00:18-08:00"),
                    DateTime.Parse("2017-09-20T01:02:54-07:00"),
                    DateTime.Parse("2017-11-28T19:51:48-08:00"),
                    DateTime.Parse("2017-12-30T01:08:37-08:00")
                    ),
                new Event
                    (
                    "libero et",
                    DateTime.Parse("2017-03-20T03:25:11-07:00"),
                    DateTime.Parse("2016-07-08T17:51:56-07:00"),
                    DateTime.Parse("2016-11-11T04:28:03-08:00"),
                    DateTime.Parse("2016-12-15T11:59:41-08:00")
                    ),
                new Event
                    (
                    "tellus",
                    DateTime.Parse("2017-04-01T00:26:58-07:00"),
                    DateTime.Parse("2016-10-17T09:08:56-07:00"),
                    DateTime.Parse("2017-04-27T15:26:47-07:00"),
                    DateTime.Parse("2016-06-03T05:18:22-07:00")
                    ),
                new Event
                    (
                    "ipsum",
                    DateTime.Parse("2017-04-19T11:57:04-07:00"),
                    DateTime.Parse("2016-12-20T03:03:25-08:00"),
                    DateTime.Parse("2017-08-14T10:26:07-07:00"),
                    DateTime.Parse("2018-03-31T04:06:10-07:00")
                    ),
                new Event
                    (
                    "ut nisi",
                    DateTime.Parse("2017-08-31T08:20:04-07:00"),
                    DateTime.Parse("2017-12-26T06:34:33-08:00"),
                    DateTime.Parse("2016-09-20T05:13:52-07:00"),
                    DateTime.Parse("2017-05-30T04:36:02-07:00")
                    ),
                new Event
                    (
                    "pede. Cum sociis",
                    DateTime.Parse("2017-06-13T01:19:23-07:00"),
                    DateTime.Parse("2016-07-17T06:23:49-07:00"),
                    DateTime.Parse("2017-10-05T09:18:15-07:00"),
                    DateTime.Parse("2016-10-29T03:14:45-07:00")
                    ),
                new Event
                    (
                    "Integer aliquam adipiscing",
                    DateTime.Parse("2017-03-24T10:36:27-07:00"),
                    DateTime.Parse("2017-07-13T03:53:40-07:00"),
                    DateTime.Parse("2016-07-20T22:15:45-07:00"),
                    DateTime.Parse("2017-07-09T06:12:57-07:00")
                    ),
                new Event
                    (
                    "Donec",
                    DateTime.Parse("2016-10-22T13:22:09-07:00"),
                    DateTime.Parse("2016-09-22T06:24:07-07:00"),
                    DateTime.Parse("2016-09-26T06:20:19-07:00"),
                    DateTime.Parse("2016-10-05T20:42:32-07:00")
                    ),
                new Event
                    (
                    "Proin vel",
                    DateTime.Parse("2018-05-26T08:55:29-07:00"),
                    DateTime.Parse("2017-04-25T06:25:44-07:00"),
                    DateTime.Parse("2017-08-11T07:30:13-07:00"),
                    DateTime.Parse("2017-10-03T12:50:01-07:00")
                    ),
                new Event
                    (
                    "ornare, lectus",
                    DateTime.Parse("2017-11-29T01:05:49-08:00"),
                    DateTime.Parse("2018-04-15T22:24:09-07:00"),
                    DateTime.Parse("2017-10-01T16:47:58-07:00"),
                    DateTime.Parse("2016-12-10T00:03:32-08:00")
                    ),
                new Event
                    (
                    "egestas",
                    DateTime.Parse("2017-12-25T10:31:58-08:00"),
                    DateTime.Parse("2017-11-26T03:11:42-08:00"),
                    DateTime.Parse("2016-12-02T22:23:27-08:00"),
                    DateTime.Parse("2018-03-31T13:40:58-07:00")
                    ),
                new Event
                    (
                    "est. Nunc laoreet",
                    DateTime.Parse("2018-01-24T00:33:37-08:00"),
                    DateTime.Parse("2016-09-05T12:20:44-07:00"),
                    DateTime.Parse("2016-11-06T00:26:47-07:00"),
                    DateTime.Parse("2016-10-14T01:37:52-07:00")
                    ),
                new Event
                    (
                    "volutpat. Nulla facilisis.",
                    DateTime.Parse("2016-10-19T09:13:31-07:00"),
                    DateTime.Parse("2017-05-14T07:49:52-07:00"),
                    DateTime.Parse("2016-09-19T12:59:47-07:00"),
                    DateTime.Parse("2017-05-19T11:38:53-07:00")
                    ),
                new Event
                    (
                    "id, libero. Donec",
                    DateTime.Parse("2018-03-17T12:14:31-07:00"),
                    DateTime.Parse("2017-03-20T14:59:58-07:00"),
                    DateTime.Parse("2016-08-21T14:30:23-07:00"),
                    DateTime.Parse("2017-12-19T05:02:46-08:00")
                    ),
                new Event
                    (
                    "inceptos hymenaeos. Mauris",
                    DateTime.Parse("2017-10-31T10:37:13-07:00"),
                    DateTime.Parse("2017-07-20T00:50:34-07:00"),
                    DateTime.Parse("2017-12-12T05:21:29-08:00"),
                    DateTime.Parse("2017-06-15T16:45:05-07:00")
                    ),
                new Event
                    (
                    "penatibus et magnis",
                    DateTime.Parse("2017-09-16T15:25:00-07:00"),
                    DateTime.Parse("2018-02-16T14:48:29-08:00"),
                    DateTime.Parse("2016-10-22T11:19:55-07:00"),
                    DateTime.Parse("2016-10-16T17:41:52-07:00")
                    ),
                new Event
                    (
                    "mollis.",
                    DateTime.Parse("2017-07-13T15:11:50-07:00"),
                    DateTime.Parse("2017-06-19T17:41:47-07:00"),
                    DateTime.Parse("2016-12-06T01:45:51-08:00"),
                    DateTime.Parse("2017-09-23T06:07:38-07:00")
                    ),
                new Event
                    (
                    "enim.",
                    DateTime.Parse("2016-09-01T03:41:10-07:00"),
                    DateTime.Parse("2018-04-24T11:30:52-07:00"),
                    DateTime.Parse("2017-01-03T22:02:06-08:00"),
                    DateTime.Parse("2016-10-26T17:27:04-07:00")
                    ),
                new Event
                    (
                    "Nam",
                    DateTime.Parse("2017-11-30T08:54:35-08:00"),
                    DateTime.Parse("2016-11-13T03:55:01-08:00"),
                    DateTime.Parse("2018-04-27T20:28:46-07:00"),
                    DateTime.Parse("2016-09-16T08:13:29-07:00")
                    ),
                new Event
                    (
                    "felis. Donec tempor,",
                    DateTime.Parse("2018-04-10T01:25:48-07:00"),
                    DateTime.Parse("2016-09-10T03:51:51-07:00"),
                    DateTime.Parse("2018-01-18T08:28:10-08:00"),
                    DateTime.Parse("2016-10-28T14:12:08-07:00")
                    ),
                new Event
                    (
                    "tellus. Suspendisse sed",
                    DateTime.Parse("2017-12-28T21:41:40-08:00"),
                    DateTime.Parse("2017-05-23T10:00:19-07:00"),
                    DateTime.Parse("2017-12-20T22:01:47-08:00"),
                    DateTime.Parse("2016-11-29T09:19:02-08:00")
                    ),
                new Event
                    (
                    "nec",
                    DateTime.Parse("2018-05-11T21:25:37-07:00"),
                    DateTime.Parse("2018-01-09T15:15:41-08:00"),
                    DateTime.Parse("2017-01-23T18:21:10-08:00"),
                    DateTime.Parse("2016-09-04T11:43:05-07:00")
                    ),
                new Event
                    (
                    "interdum feugiat. Sed",
                    DateTime.Parse("2017-04-23T15:29:26-07:00"),
                    DateTime.Parse("2017-05-24T03:01:01-07:00"),
                    DateTime.Parse("2017-05-04T16:52:24-07:00"),
                    DateTime.Parse("2017-01-31T01:23:36-08:00")
                    ),
                new Event
                    (
                    "mauris.",
                    DateTime.Parse("2017-02-20T05:51:47-08:00"),
                    DateTime.Parse("2016-06-01T14:28:54-07:00"),
                    DateTime.Parse("2018-02-28T16:53:32-08:00"),
                    DateTime.Parse("2017-07-30T12:38:44-07:00")
                    ),
                new Event
                    (
                    "orci. Donec nibh.",
                    DateTime.Parse("2017-11-30T22:31:16-08:00"),
                    DateTime.Parse("2017-07-30T23:24:56-07:00"),
                    DateTime.Parse("2016-08-12T13:54:53-07:00"),
                    DateTime.Parse("2017-03-11T13:23:29-08:00")
                    ),
                new Event
                    (
                    "ac",
                    DateTime.Parse("2016-09-10T09:39:45-07:00"),
                    DateTime.Parse("2016-11-07T10:58:03-08:00"),
                    DateTime.Parse("2017-02-12T19:39:12-08:00"),
                    DateTime.Parse("2016-07-21T05:56:21-07:00")
                    ),
                new Event
                    (
                    "fermentum convallis",
                    DateTime.Parse("2017-07-08T17:27:51-07:00"),
                    DateTime.Parse("2017-12-16T03:50:01-08:00"),
                    DateTime.Parse("2016-09-27T04:31:24-07:00"),
                    DateTime.Parse("2017-05-05T05:25:49-07:00")
                    ),
                new Event
                    (
                    "risus. Quisque libero",
                    DateTime.Parse("2017-12-03T20:13:28-08:00"),
                    DateTime.Parse("2016-08-24T02:08:53-07:00"),
                    DateTime.Parse("2017-02-08T11:25:58-08:00"),
                    DateTime.Parse("2017-06-06T18:05:45-07:00")
                    ),
                new Event
                    (
                    "consequat enim diam",
                    DateTime.Parse("2018-04-11T19:40:26-07:00"),
                    DateTime.Parse("2018-03-01T19:32:04-08:00"),
                    DateTime.Parse("2016-08-28T22:26:06-07:00"),
                    DateTime.Parse("2016-11-18T02:35:39-08:00")
                    ),
                new Event
                    (
                    "Aliquam gravida mauris",
                    DateTime.Parse("2016-12-15T20:53:01-08:00"),
                    DateTime.Parse("2017-09-25T09:11:23-07:00"),
                    DateTime.Parse("2016-11-16T12:09:35-08:00"),
                    DateTime.Parse("2018-01-29T22:01:31-08:00")
                    ),
                new Event
                    (
                    "augue,",
                    DateTime.Parse("2016-10-05T19:52:37-07:00"),
                    DateTime.Parse("2016-11-03T08:09:48-07:00"),
                    DateTime.Parse("2017-12-12T20:38:21-08:00"),
                    DateTime.Parse("2017-08-29T18:43:55-07:00")
                    ),
                new Event
                    (
                    "non, cursus",
                    DateTime.Parse("2017-09-01T06:09:32-07:00"),
                    DateTime.Parse("2016-09-13T23:12:28-07:00"),
                    DateTime.Parse("2016-10-26T13:54:42-07:00"),
                    DateTime.Parse("2017-05-20T10:31:35-07:00")
                    ),
                new Event
                    (
                    "urna.",
                    DateTime.Parse("2018-03-10T13:16:47-08:00"),
                    DateTime.Parse("2018-04-02T10:28:33-07:00"),
                    DateTime.Parse("2016-12-15T03:22:33-08:00"),
                    DateTime.Parse("2018-04-17T07:43:26-07:00")
                    ),
                new Event
                    (
                    "consequat auctor,",
                    DateTime.Parse("2017-10-28T15:09:14-07:00"),
                    DateTime.Parse("2017-01-02T00:16:47-08:00"),
                    DateTime.Parse("2017-10-20T21:45:43-07:00"),
                    DateTime.Parse("2017-11-26T15:59:00-08:00")
                    ),
                new Event
                    (
                    "natoque penatibus et",
                    DateTime.Parse("2016-06-01T17:58:24-07:00"),
                    DateTime.Parse("2017-02-26T21:56:12-08:00"),
                    DateTime.Parse("2016-07-23T18:44:40-07:00"),
                    DateTime.Parse("2017-05-20T16:49:19-07:00")
                    ),
                new Event
                    (
                    "risus.",
                    DateTime.Parse("2018-03-12T05:07:38-07:00"),
                    DateTime.Parse("2017-04-06T10:27:57-07:00"),
                    DateTime.Parse("2018-05-10T16:03:04-07:00"),
                    DateTime.Parse("2017-03-19T00:49:43-07:00")
                    ),
                new Event
                    (
                    "Phasellus vitae",
                    DateTime.Parse("2017-07-03T14:39:50-07:00"),
                    DateTime.Parse("2018-02-01T17:03:16-08:00"),
                    DateTime.Parse("2018-02-19T08:16:22-08:00"),
                    DateTime.Parse("2017-06-26T11:20:12-07:00")
                    ),
                new Event
                    (
                    "ac",
                    DateTime.Parse("2018-02-01T17:50:43-08:00"),
                    DateTime.Parse("2016-09-27T06:25:19-07:00"),
                    DateTime.Parse("2017-03-10T11:48:41-08:00"),
                    DateTime.Parse("2017-10-29T09:12:41-07:00")
                    ),
                new Event
                    (
                    "nunc sed libero.",
                    DateTime.Parse("2018-01-25T14:50:22-08:00"),
                    DateTime.Parse("2016-10-19T16:27:19-07:00"),
                    DateTime.Parse("2016-06-03T19:55:06-07:00"),
                    DateTime.Parse("2017-06-01T12:07:34-07:00")
                    ),
                new Event
                    (
                    "vulputate ullamcorper",
                    DateTime.Parse("2017-01-26T12:48:27-08:00"),
                    DateTime.Parse("2018-01-25T01:29:45-08:00"),
                    DateTime.Parse("2017-07-16T16:31:19-07:00"),
                    DateTime.Parse("2017-01-11T05:19:58-08:00")
                    ),
                new Event
                    (
                    "mattis. Cras eget",
                    DateTime.Parse("2016-07-25T16:04:19-07:00"),
                    DateTime.Parse("2016-07-08T05:54:59-07:00"),
                    DateTime.Parse("2017-11-30T02:27:03-08:00"),
                    DateTime.Parse("2016-09-03T16:05:16-07:00")
                    ),
                new Event
                    (
                    "nibh",
                    DateTime.Parse("2018-03-01T18:29:48-08:00"),
                    DateTime.Parse("2017-11-05T09:06:27-08:00"),
                    DateTime.Parse("2017-04-11T18:11:30-07:00"),
                    DateTime.Parse("2017-03-09T23:04:01-08:00")
                    ),
                new Event
                    (
                    "facilisis vitae, orci.",
                    DateTime.Parse("2016-11-15T11:15:07-08:00"),
                    DateTime.Parse("2017-10-19T18:34:42-07:00"),
                    DateTime.Parse("2017-11-20T19:49:31-08:00"),
                    DateTime.Parse("2017-07-07T05:54:03-07:00")
                    ),
                new Event
                    (
                    "laoreet posuere, enim",
                    DateTime.Parse("2017-06-19T02:42:40-07:00"),
                    DateTime.Parse("2016-06-02T06:57:49-07:00"),
                    DateTime.Parse("2017-04-05T06:39:45-07:00"),
                    DateTime.Parse("2016-09-27T13:35:36-07:00")
                    ),
                new Event
                    (
                    "sollicitudin adipiscing ligula.",
                    DateTime.Parse("2016-06-24T07:39:28-07:00"),
                    DateTime.Parse("2017-04-02T19:44:36-07:00"),
                    DateTime.Parse("2017-11-05T06:04:28-08:00"),
                    DateTime.Parse("2016-06-05T20:06:29-07:00")
                    ),
                new Event
                    (
                    "cursus",
                    DateTime.Parse("2018-03-22T17:16:38-07:00"),
                    DateTime.Parse("2017-05-17T05:41:48-07:00"),
                    DateTime.Parse("2017-12-12T19:02:33-08:00"),
                    DateTime.Parse("2017-03-17T23:02:30-07:00")
                    ),
                new Event
                    (
                    "dolor. Quisque",
                    DateTime.Parse("2017-05-19T22:37:49-07:00"),
                    DateTime.Parse("2018-01-27T17:00:42-08:00"),
                    DateTime.Parse("2017-04-08T15:44:04-07:00"),
                    DateTime.Parse("2016-09-21T12:38:49-07:00")
                    ),
                new Event
                    (
                    "sed",
                    DateTime.Parse("2016-07-12T10:30:42-07:00"),
                    DateTime.Parse("2017-08-05T09:34:18-07:00"),
                    DateTime.Parse("2017-05-02T19:58:59-07:00"),
                    DateTime.Parse("2017-11-26T00:35:49-08:00")
                    ),
                new Event
                    (
                    "in, hendrerit",
                    DateTime.Parse("2017-07-05T14:04:35-07:00"),
                    DateTime.Parse("2016-09-12T18:29:34-07:00"),
                    DateTime.Parse("2017-10-18T23:24:40-07:00"),
                    DateTime.Parse("2017-09-15T10:03:11-07:00")
                    ),
                new Event
                    (
                    "pede. Praesent eu",
                    DateTime.Parse("2017-06-27T14:28:28-07:00"),
                    DateTime.Parse("2016-09-03T00:00:47-07:00"),
                    DateTime.Parse("2017-12-03T03:32:49-08:00"),
                    DateTime.Parse("2017-05-23T19:23:04-07:00")
                    ),
                new Event
                    (
                    "eget, venenatis",
                    DateTime.Parse("2017-02-11T10:35:45-08:00"),
                    DateTime.Parse("2017-05-12T00:04:40-07:00"),
                    DateTime.Parse("2018-02-12T16:12:14-08:00"),
                    DateTime.Parse("2017-02-06T16:03:37-08:00")
                    ),
                new Event
                    (
                    "congue a,",
                    DateTime.Parse("2018-01-26T09:36:20-08:00"),
                    DateTime.Parse("2017-10-05T22:54:55-07:00"),
                    DateTime.Parse("2018-04-16T18:21:21-07:00"),
                    DateTime.Parse("2016-10-28T20:12:49-07:00")
                    ),
                new Event
                    (
                    "ornare",
                    DateTime.Parse("2016-08-12T02:05:49-07:00"),
                    DateTime.Parse("2017-07-28T16:00:56-07:00"),
                    DateTime.Parse("2018-04-09T06:57:11-07:00"),
                    DateTime.Parse("2017-10-07T00:13:30-07:00")
                    ),
                new Event
                    (
                    "Donec",
                    DateTime.Parse("2016-10-25T08:44:33-07:00"),
                    DateTime.Parse("2018-05-18T09:35:51-07:00"),
                    DateTime.Parse("2018-04-28T12:24:40-07:00"),
                    DateTime.Parse("2016-12-29T01:46:51-08:00")
                    ),
                new Event
                    (
                    "nec",
                    DateTime.Parse("2018-03-27T01:48:56-07:00"),
                    DateTime.Parse("2017-07-22T04:42:16-07:00"),
                    DateTime.Parse("2017-09-18T07:21:08-07:00"),
                    DateTime.Parse("2018-02-06T00:57:40-08:00")
                    ),
                new Event
                    (
                    "Nunc ullamcorper, velit",
                    DateTime.Parse("2017-12-18T12:26:54-08:00"),
                    DateTime.Parse("2016-11-10T16:39:36-08:00"),
                    DateTime.Parse("2017-12-27T19:09:52-08:00"),
                    DateTime.Parse("2016-07-20T01:36:46-07:00")
                    ),
                new Event
                    (
                    "Donec consectetuer",
                    DateTime.Parse("2016-10-18T12:45:48-07:00"),
                    DateTime.Parse("2017-11-28T20:35:29-08:00"),
                    DateTime.Parse("2018-02-14T12:53:24-08:00"),
                    DateTime.Parse("2018-02-13T23:19:55-08:00")
                    ),
                new Event
                    (
                    "mi enim, condimentum",
                    DateTime.Parse("2016-12-25T01:41:07-08:00"),
                    DateTime.Parse("2016-06-24T18:00:29-07:00"),
                    DateTime.Parse("2016-08-25T10:59:10-07:00"),
                    DateTime.Parse("2016-06-28T01:52:39-07:00")
                    ),
                new Event
                    (
                    "massa. Integer",
                    DateTime.Parse("2016-07-11T17:38:22-07:00"),
                    DateTime.Parse("2016-08-09T21:25:44-07:00"),
                    DateTime.Parse("2016-11-16T14:06:19-08:00"),
                    DateTime.Parse("2017-06-05T06:57:39-07:00")
                    ),
                new Event
                    (
                    "est ac facilisis",
                    DateTime.Parse("2018-01-31T16:31:01-08:00"),
                    DateTime.Parse("2017-09-19T00:29:32-07:00"),
                    DateTime.Parse("2016-08-03T10:04:06-07:00"),
                    DateTime.Parse("2017-03-04T09:24:30-08:00")
                    ),
                new Event
                    (
                    "Donec",
                    DateTime.Parse("2016-07-03T02:59:14-07:00"),
                    DateTime.Parse("2017-12-07T18:35:06-08:00"),
                    DateTime.Parse("2016-09-02T17:26:00-07:00"),
                    DateTime.Parse("2017-03-07T23:22:30-08:00")
                    ),
                new Event
                    (
                    "Maecenas malesuada fringilla",
                    DateTime.Parse("2017-03-26T20:38:49-07:00"),
                    DateTime.Parse("2018-03-18T14:20:47-07:00"),
                    DateTime.Parse("2017-01-19T17:45:55-08:00"),
                    DateTime.Parse("2017-04-08T00:51:54-07:00")
                    ),
                new Event
                    (
                    "nec, malesuada",
                    DateTime.Parse("2017-06-12T23:52:48-07:00"),
                    DateTime.Parse("2017-10-08T07:10:59-07:00"),
                    DateTime.Parse("2018-05-26T00:11:31-07:00"),
                    DateTime.Parse("2016-12-28T20:15:54-08:00")
                    ),
                new Event
                    (
                    "sapien. Nunc",
                    DateTime.Parse("2017-11-23T23:35:04-08:00"),
                    DateTime.Parse("2017-04-16T06:25:27-07:00"),
                    DateTime.Parse("2016-10-26T09:15:25-07:00"),
                    DateTime.Parse("2017-09-29T11:48:36-07:00")
                    ),
                new Event
                    (
                    "tempor lorem,",
                    DateTime.Parse("2017-01-13T15:01:57-08:00"),
                    DateTime.Parse("2016-10-10T01:52:08-07:00"),
                    DateTime.Parse("2017-12-21T03:01:43-08:00"),
                    DateTime.Parse("2018-01-21T20:45:36-08:00")
                    ),
                new Event
                    (
                    "cursus. Integer mollis.",
                    DateTime.Parse("2017-03-08T14:30:43-08:00"),
                    DateTime.Parse("2018-03-28T16:17:21-07:00"),
                    DateTime.Parse("2017-03-11T05:37:58-08:00"),
                    DateTime.Parse("2016-08-28T04:54:33-07:00")
                    ),
                new Event
                    (
                    "vulputate",
                    DateTime.Parse("2018-03-19T14:05:00-07:00"),
                    DateTime.Parse("2017-11-29T14:32:05-08:00"),
                    DateTime.Parse("2017-01-11T07:30:54-08:00"),
                    DateTime.Parse("2017-11-13T21:48:46-08:00")
                    ),
                new Event
                    (
                    "nec tempus",
                    DateTime.Parse("2017-07-16T03:35:55-07:00"),
                    DateTime.Parse("2017-10-12T21:00:38-07:00"),
                    DateTime.Parse("2017-01-05T14:09:21-08:00"),
                    DateTime.Parse("2017-01-15T04:16:15-08:00")
                    ),
                new Event
                    (
                    "leo. Morbi neque",
                    DateTime.Parse("2016-06-03T08:01:13-07:00"),
                    DateTime.Parse("2017-08-29T06:08:47-07:00"),
                    DateTime.Parse("2018-05-29T07:54:43-07:00"),
                    DateTime.Parse("2018-05-05T15:01:24-07:00")
                    ),
                new Event
                    (
                    "ligula",
                    DateTime.Parse("2016-07-07T18:08:50-07:00"),
                    DateTime.Parse("2018-02-27T07:54:03-08:00"),
                    DateTime.Parse("2018-03-27T14:17:16-07:00"),
                    DateTime.Parse("2017-02-21T15:59:48-08:00")
                    ),
                new Event
                    (
                    "Aenean gravida nunc",
                    DateTime.Parse("2016-08-01T19:52:15-07:00"),
                    DateTime.Parse("2017-06-28T03:46:07-07:00"),
                    DateTime.Parse("2017-12-21T08:03:32-08:00"),
                    DateTime.Parse("2016-09-20T22:17:32-07:00")
                    ),
                new Event
                    (
                    "et",
                    DateTime.Parse("2017-09-12T16:51:02-07:00"),
                    DateTime.Parse("2017-08-25T01:51:28-07:00"),
                    DateTime.Parse("2017-09-23T17:18:09-07:00"),
                    DateTime.Parse("2016-06-01T04:43:13-07:00")
                    ),
                new Event
                    (
                    "Quisque tincidunt",
                    DateTime.Parse("2017-07-12T11:34:15-07:00"),
                    DateTime.Parse("2017-05-28T10:49:29-07:00"),
                    DateTime.Parse("2018-04-23T04:45:58-07:00"),
                    DateTime.Parse("2016-07-02T01:12:29-07:00")
                    ),
                new Event
                    (
                    "vitae mauris sit",
                    DateTime.Parse("2016-11-16T04:54:35-08:00"),
                    DateTime.Parse("2017-12-01T15:36:11-08:00"),
                    DateTime.Parse("2017-01-27T19:35:00-08:00"),
                    DateTime.Parse("2016-07-29T21:34:05-07:00")
                    ),
                new Event
                    (
                    "Vivamus nibh",
                    DateTime.Parse("2018-01-11T02:34:31-08:00"),
                    DateTime.Parse("2017-02-07T11:07:38-08:00"),
                    DateTime.Parse("2016-12-23T10:42:51-08:00"),
                    DateTime.Parse("2016-07-16T07:27:46-07:00")
                    ),
                new Event
                    (
                    "erat",
                    DateTime.Parse("2017-09-18T13:38:18-07:00"),
                    DateTime.Parse("2017-09-10T01:30:02-07:00"),
                    DateTime.Parse("2016-09-25T13:17:07-07:00"),
                    DateTime.Parse("2016-08-06T12:13:03-07:00")
                    ),
                new Event
                    (
                    "metus vitae",
                    DateTime.Parse("2017-06-28T16:11:21-07:00"),
                    DateTime.Parse("2017-06-23T21:28:28-07:00"),
                    DateTime.Parse("2017-10-09T14:32:08-07:00"),
                    DateTime.Parse("2018-02-07T01:09:03-08:00")
                    ),
                new Event
                    (
                    "felis",
                    DateTime.Parse("2017-01-01T12:21:20-08:00"),
                    DateTime.Parse("2017-08-24T18:46:26-07:00"),
                    DateTime.Parse("2017-04-01T12:56:15-07:00"),
                    DateTime.Parse("2017-02-25T14:56:47-08:00")
                    ),
                new Event
                    (
                    "Donec",
                    DateTime.Parse("2018-04-13T22:48:17-07:00"),
                    DateTime.Parse("2017-10-10T12:02:28-07:00"),
                    DateTime.Parse("2017-07-11T01:13:28-07:00"),
                    DateTime.Parse("2017-02-02T05:40:09-08:00")
                    ),
                new Event
                    (
                    "Mauris vestibulum, neque",
                    DateTime.Parse("2016-10-07T13:07:56-07:00"),
                    DateTime.Parse("2016-12-10T10:38:31-08:00"),
                    DateTime.Parse("2017-03-27T11:44:35-07:00"),
                    DateTime.Parse("2016-12-16T20:12:14-08:00"))
            };
        }
    }
}
