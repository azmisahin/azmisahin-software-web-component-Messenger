using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace @as.Messenger.Tests
{
    [TestClass]
    public class ClientManagerTest
    {
        [TestMethod]
        public void sendSignalTest()
        {
            ClientManager client = new ClientManager();
            client.sendSignal(new Models.SignalModel { id = "1", account = "test", data = DateTime.Now, message = "hi", type = 0 });
        }
    }
}
