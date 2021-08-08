using System;


namespace Mod7
{
  public class Client
  {
    private string FirstName;
    private string LastName;
    private string Phone;
    private string Address;
    internal Client(string firstName)
    {
      FirstName = firstName;

    }
    internal Client(string firstName, string phone)
    {
      FirstName = firstName;
      Phone = phone;
    }
    internal Client(string firstName, string phone, string address)
    {
      FirstName = firstName;
      Phone = phone;
      Address = address;
    }
    internal Client(string firstName, string lastName, string phone, string address)
    {
      FirstName = firstName;
      LastName = lastName;
      Phone = phone;
      Address = address;
    }

    public void getInfo()
    {
      Console.WriteLine($"{this.FirstName} {this.LastName}: {this.Phone}, {this.Address}");
    }

  }
}
