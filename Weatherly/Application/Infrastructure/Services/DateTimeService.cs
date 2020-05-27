using System;
using Weatherly.AppLogic.Common.Interfaces;

namespace Weatherly.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
