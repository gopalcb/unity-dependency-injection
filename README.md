## Inversion of Control: Unity Dependency Injection

### Language and Tools used:

* C#
* Unity
* Nuget

### Install Unity:

```bash
Install-Package Unity -Version 5.11.7
```

### Generated App.config:

```bash 
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
  </startup>
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
      <parameters>
        <parameter value="mssqllocaldb" />
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
</configuration>
```

## User Model:

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Unity_DI_Console_App
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
```

## Repository to inject

```C#
using System.Collections.Generic;

namespace Unity_DI_Console_App.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        public List<User> GetUsers()
        {
            var ul = new List<User>
            {
                new User {UserId = 1, Name = "Gopal", Email = "gopal@bitmascot.com"},
                new User {UserId = 2, Name = "Nayan", Email = "nayan@live.com"}
            };
            return ul;
        } 
    }
    public interface IUserRepository<User>
    {
        List<User> GetUsers();
    }
}
```

### DI implementation:

```C#
using System;
using Microsoft.Practices.Unity;
using Unity_DI_Console_App.Repository;

namespace Unity_DI_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IUserRepository<User>, UserRepository>();
            var usrRepo = container.Resolve<IUserRepository<User>>();
            var lst = usrRepo.GetUsers();
            foreach (var o in lst)
            {
                Console.Write(o.UserId + "   " + o.Name + "   " + o.Email);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
```
