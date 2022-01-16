using AutoFixture;
using Hondenasiel.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hondenasiel.tests
{
    public abstract class BaseTest
    {
        protected Fixture? Fixture { get; private set; }

        public BaseTest()
        {
            Fixture = new Fixture();
        }

        protected virtual void CleanUp()
        {
            Fixture = null;
        }
    }
}
