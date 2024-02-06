using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes {

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class RequiringConventionAttribute : Attribute {
        public RequiringConventionAttribute(DeploymentTarget target, Status status) : base() {
            Target = target;
            Status = status;
        }

        public DeploymentTarget Target { get; }
        public Status Status { get; }
    }
}
