using BusinessLogic.Services.Interfaces;
using NUnit.Framework;
using StructureMap.AutoMocking;

namespace UnitTests.BusinessLogic.Services.TestBases
{
    public class StatisticServiceTestBase
    {
        protected RhinoAutoMocker<IStatisticService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new RhinoAutoMocker<IStatisticService>();
        }
    }
}