﻿namespace Construktion.Tests.Simple
{
    using System.Reflection;
    using Blueprints.Simple;
    using Shouldly;
    using Xunit;

    public class StringPropertyBlueprintTests
    {
        [Fact]
        public void should_prefix_property_name()
        {
            var blueprint = new StringPropertyBlueprint();
            var pi = typeof(Foo).GetProperty(nameof(Foo.Name));
            var result = (string)blueprint.Construct(new ConstruktionContext(pi), Default.Pipeline);
            
            result.ShouldStartWith("Name-");
        }

        public class Foo
        {
            public string Name { get; set; }
        }
    }
}