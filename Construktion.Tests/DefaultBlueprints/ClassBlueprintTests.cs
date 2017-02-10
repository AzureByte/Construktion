﻿namespace Construktion.Tests.DefaultBlueprints
{
    using Blueprints;
    using Shouldly;
    using Xunit;

    public class ClassBlueprintTests
    {
        [Fact]
        public void can_build_a_class()
        {
            var blueprint = new ClassBlueprint();

            var result = (Person)blueprint.Build(new ConstruktionContext(typeof(Person)), Default.Pipeline);

            result.ShouldNotBeNull();
            result.Name.ShouldNotBeNullOrEmpty();
            result.Age.ShouldNotBeNull();
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}