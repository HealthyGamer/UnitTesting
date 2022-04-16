using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingMocks.UnitTest
{
internal class LoggerMock : ILogger
{
    public int ErrorCalls = 0;
    public int InfoCalls = 0;
    public int WarnCalls = 0;

    public void Error(string message)
    {
        ErrorCalls++;
    }

    public void Info(string message)
    {
        InfoCalls++; 
    }

    public void Warn(string message)
    {
        WarnCalls++;
    }
}
}
