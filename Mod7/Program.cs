using System;


namespace Mod7
{


  class Program
  {
    static void Main(string[] args)
    {
      // Order order = new Order();
      // order.DisplayAddress();
      Client cl1 = new Client("John", "Doe", "+12345678963", "Fake address");
      cl1.getInfo();
    }
  }
}
