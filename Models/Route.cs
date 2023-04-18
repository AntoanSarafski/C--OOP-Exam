using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double length;
        private int routeId;
        private bool isLocked;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;
        }

        public string StartPoint { get => startPoint; private set => startPoint = value; }

        public string EndPoint { get => endPoint; private set => endPoint = value; }

        public double Length { get => length; private set => length = value; }

        public int RouteId { get => routeId; private set => routeId = value; }

        public bool IsLocked { get => isLocked; private set => isLocked = value; }

        public void LockRoute()
        {
            throw new NotImplementedException();
        }
    }
}
