using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFiles
{
    public class RegisterDependency :Attribute
    {

        public ServiceLifetime Scope { get; set; }

        public RegisterDependency(ServiceLifetime serviceLifetime)
        {
            Scope = serviceLifetime;
        }


        public class RegisterSingletonAttribute :RegisterDependency
        {
            public RegisterSingletonAttribute() : base(ServiceLifetime.Singleton)
            {
            }
        }
        public class RegisterScopedAttribute : RegisterDependency
        {
            public RegisterScopedAttribute() : base(ServiceLifetime.Scoped)
            {
            }
        }

        public class RegisterTrasientAttribute : RegisterDependency
        {
            public RegisterTrasientAttribute() : base(ServiceLifetime.Transient) 
            {
            }
        }
    }
}
